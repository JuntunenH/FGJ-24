using Godot;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

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
	public int Experience { get; private set; } = 1;

	private Timer _attackCooldown;
	private CharacterController _player;
	Sprite2D e_sprite;
	
	public EnemyController _thisEnemy;

	public override void _Ready()
	{
		_player = GetNode<CharacterController>("/root/World/PlayerCharacter");
		// fetch player sprite
		e_sprite = GetNode<Sprite2D>("Sprite2D");
		var _thisEnemy = this;
	}
	public override void _PhysicsProcess(double delta)
	{
		//base._PhysicsProcess(delta);
		var playerPos = _player.GlobalPosition;
		var direction = (playerPos - GlobalPosition).LimitLength();
		Velocity = direction * MovementSpeed;
		MoveAndSlide();
        for (int i = 0; i < GetSlideCollisionCount(); i++)
        {
            var collision = GetSlideCollision(1);
            GD.Print("I collided with ", ((Node)collision.GetCollider()).Name);
            //_player.TakeDamage(Damage);
            // Damagecooldown?
        }
	}
	public void TakeDamage(int amount){
		GD.Print("Enemy take damage");
		GD.Print(amount);
		Hitpoints-= amount;
		if(Hitpoints<=0)
		{
			QueueFree();
		}
	}
}



