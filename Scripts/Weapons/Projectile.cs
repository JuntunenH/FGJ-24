using Godot;
using System;

public partial class Projectile : BaseWeapon
{
	public Vector2 projectileDirection = Vector2.Right;
	private float m_projectileSpeed;
	[Export] public float  ProjectileSpeed { get { return m_projectileSpeed; } set {m_projectileSpeed = value;}}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition += projectileDirection* m_projectileSpeed *(float)delta;
	}
}
