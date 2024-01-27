using Godot;
using System;

public partial class waterBalloon : Projectile
{
	private AnimatedSprite2D spriteArray;
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private Node2D parentNode;
	private float angleInRad;
	[Export]
    public float radius = 20f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//base._Ready();
		spriteArray = GetNode<AnimatedSprite2D>("SpriteArray");
		spriteArray.Frame = rng.RandiRange(0,4);
		parentNode = GetParent<Node2D>();
		GD.Print($"Parent Node: {parentNode}");
	}

    public override void _Process(double delta)
    {
		angleInRad += (float)delta*ProjectileSpeed;
        Vector2 moveTarget = new Vector2(Mathf.Cos(angleInRad) * radius, Mathf.Sin(angleInRad) * radius);
		Rotation = moveTarget.Angle()+1.5f;
        Position = moveTarget+parentNode.Position;
    }
}
