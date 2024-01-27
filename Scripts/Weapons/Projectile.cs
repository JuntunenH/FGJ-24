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
		DisableSelf();
	}

	public void _onBodyEntered(Node2D body)
	{
		if(body.IsInGroup("Enemy")){
			GD.Print(body.Name);
			DisableSelf();
		}
	}

	private void DisableSelf()
	{
		SetProcess(false);
		SetPhysicsProcess(false);
		SetProcessInput(false);
		Visible = false;
	}
}
