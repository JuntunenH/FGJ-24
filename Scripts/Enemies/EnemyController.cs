using Godot;
using System;
using System.Diagnostics;

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
    public int Hitpoints { get; set; } = 100;

    [Export]
    public int Damage { get; set; } = 5;

    [Export]
    public float MovementSpeed = 40;

    [Export]
    public int Experience { get; private set; } = 1;

    private Timer _attackCooldown;
    private CharacterController _player;
    Sprite2D e_sprite;

    public override void _Ready()
    {
        _player = GetNode<CharacterController>("/root/World/PlayerCharacter");
        // fetch player sprite
        e_sprite = GetNode<Sprite2D>("Sprite2D");
    }
    public override void _PhysicsProcess(double delta)
    {
        //base._PhysicsProcess(delta);
        var playerPos = _player.GlobalPosition;
        var direction = (playerPos - GlobalPosition).LimitLength();
        Velocity = direction * MovementSpeed;
        MoveAndSlide();
    }


    // private void Attack()
    // {
    //     if (!IsPlayerInAttackRange) return;
    //     _attackCooldown.Start();
    //     _gameManager.Player.TakeDamages(Damages);
    // }

    // internal void TakeDamage(uint damages = 1)
    // {
    //     EmitSignal(SignalName.OnEnemyHit, this, damages);
    //     Lifepoints -= (int)damages;
    //     if (Lifepoints > 0) return;
    //     QueueFree();
    // }
}
