using Godot;
using System;

public enum EnemyVariant
{
	Melee = 1,
	Range = 2
}
public partial class EnemyController : CharacterBody2D
{
	// Enemy stats
	[ExportCategory("Enemy Variables")]
	//public const uint MaxLifepoints = 100; 

 	[Export]
	public int Hitpoints { get; set; } = 10;

	[Export]
	public int Damage { get; set; } = 5;

	[Export]
	public float MovementSpeed = 40;
	[Export]
	public PackedScene Pickup;

	private Timer _attackCooldown;
	private CharacterController _player;
	private AudioStreamPlayer2D _sound;
	[Signal] public delegate void EnemyDeathEventHandler(PackedScene pickup, Vector2 position, EnemyController enemy);

	public override void _Ready()
	{
		_player = GetNode<CharacterController>("/root/World/PlayerCharacter");
		_sound = GetNode<AudioStreamPlayer2D>("/root/World/AudioStreamPlayer2D2");
		_sound.Stream = GD.Load<AudioStream>("res://Audio/cartoon-splat-6086.mp3");
	}
	public override void _PhysicsProcess(double delta)
	{
		//base._PhysicsProcess(delta);
		var playerPos = _player.GlobalPosition;
		var direction = (playerPos - GlobalPosition).LimitLength();
		Velocity = direction * MovementSpeed;
		MoveAndSlide();
	}
	public void TakeDamage(int amount){
		GD.Print("Enemy take damage ",amount);
		Hitpoints-= amount;
		if(Hitpoints<=0)
		{
			_sound.Play();
			CallDeferred("_death");
		}
	}
	private void _death()
	{
		EmitSignal(SignalName.EnemyDeath, Pickup, GlobalPosition, this);
		// This instantiate causes issues here
		//Node2D lootNode = (Node2D)Pickup.Instantiate();
		//lootNode.Position = GlobalPosition;
		// Add the loot item to the scene
		//GetParent().AddChild(lootNode);
		QueueFree();
	}
}