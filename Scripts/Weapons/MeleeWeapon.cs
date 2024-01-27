using Godot;
using System;

public partial class MeleeWeapon : BaseWeapon
{

    [Export] private DirectionArrow attackDirection;
    private CollisionShape2D collider;
    private Timer fadeTime;
    private float angleInRad;
    private float radius = 20f;
    [Export]private float attackSpeed = 10f;
    private bool canAttack = false;
    public override void _Ready()
    {
        base._Ready();
        isActive = true;
        collider = GetNode<CollisionShape2D>("Collider");
        fadeTime = GetNode<Timer>("FadeTime");
        ResetAttack();
    }
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if( !canAttack ) return;
        angleInRad += (float)delta*attackSpeed;
        Position = new Vector2(Mathf.Cos(angleInRad) * radius, Mathf.Sin(angleInRad) * radius);
        Rotation = angleInRad;
    }
    public override void Attack()
    {
        base.Attack();
        EnableAttack();
        fadeTime.Start();
    }

    protected void ResetAttack()
    {
        angleInRad = 0;
        Visible = false;
        collider.Disabled = true;
        canAttack=false;
    }
    protected void EnableAttack()
    {
        canAttack = true;
        Visible = true;
        collider.Disabled = false;
        angleInRad = attackDirection.GetAttackDirection().Angle();
    }
    public void _onBodyEntered(Node2D body)
    {
        if(body.IsInGroup("Enemy"))
        {
            EnemyController enemy = (EnemyController)body;
			enemy.TakeDamage(Damage);
        }
    }

    public void _onFadeTimeTimeout()
    {
        ResetAttack();
    }

}
