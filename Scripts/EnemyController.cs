using Godot;
using System;
public partial class EnemyController : CharacterBody2D
{
	// Enemy stats
	[ExportCategory("Enemy Variables")]
	//public const uint MaxLifepoints = 100; 

 	[Export]
    public int Lifepoints { get; set; } = 100;//(int)MaxLifepoints;

    // [Export]
    // public uint Damage { get; set; } = 5;

    // [Export]
    // public float MovementSpeed = 4;

    // [Export]
    // public int Experience { get; private set; } = 1;

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
