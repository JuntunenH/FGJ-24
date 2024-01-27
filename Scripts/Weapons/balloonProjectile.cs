using Godot;
using System;

public partial class balloonProjectile : Projectile
{
	[Export] public int hitsToDie = 5;
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

    protected override void DisableSelf()
    {
		if( hitsToDie > 0 ){
			hitsToDie -=1;
			return;
		}
        base.DisableSelf();
    }

    public override void _Process(double delta)
	{
		Vector2 movementDirection = projectileDirection* m_projectileSpeed *(float)delta;
		if(movementDirection.X < 0) spriteArray.FlipH = true;
		GlobalPosition += movementDirection;
	}

}
