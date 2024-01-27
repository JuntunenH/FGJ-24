using Godot;
using System;

public partial class waterBalloon : Projectile
{
	private AnimatedSprite2D spriteArray;
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private Vector2 originPoint;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		spriteArray = GetNode<AnimatedSprite2D>("SpriteArray");
		spriteArray.Frame = rng.RandiRange(0,4);
		Node2D parentNode = GetParent<Node2D>();
		if( parentNode != null)
		{
			originPoint = parentNode.Position;
		}

	}
}
