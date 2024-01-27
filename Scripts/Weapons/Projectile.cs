using Godot;
using System;

public partial class Projectile : BaseWeapon
{
	public Vector2 projectileDirection = Vector2.Right;
	private float m_projectileSpeed;
	[Export] public float  ProjectileSpeed { get { return m_projectileSpeed; } set {m_projectileSpeed = value;}}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition += projectileDirection* m_projectileSpeed *(float)delta;
	}

	public void _onLifeTimeout()
	{
		SetProcess(false);
		SetPhysicsProcess(false);
		SetProcessInput(false);
		Visible = false;
	}
}
