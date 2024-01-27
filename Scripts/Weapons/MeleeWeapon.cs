using Godot;
using System;

public partial class MeleeWeapon : BaseWeapon
{

    [Export] private DirectionArrow hitDirection;
    private CollisionShape2D collider;
    private Timer attackBackSwing;
    private Timer fadeTime;
    private Timer attackWindUp;

    public override void _Ready()
    {
        base._Ready();
        isActive = true;
        collider = GetNode<CollisionShape2D>("Collider");
        attackBackSwing = GetNode<Timer>("BackSwing");
        attackWindUp = GetNode<Timer>("WindUp");
        fadeTime = GetNode<Timer>("FadeTime");
    }
    public override void Attack()
    {
        base.Attack();
        Visible = true;
        attackWindUp.Start();
    }

    protected void ResetAnimation()
    {
        RotationDegrees = 0f;
        collider.Disabled = true;
        fadeTime.Start();
    }
    protected void AttackAnimation()
    {
        collider.Disabled = false;
        RotationDegrees = 95f;
        attackBackSwing.Start();
    }

    public void _onTimerTimeout()
    {
        ResetAnimation();
    }

    public void _onFadeTimeTimeout()
    {
        Visible = false;
    }
    public void _onWindUpTimeout()
    {
        AttackAnimation();
    }
}
