using Godot;
using System;


public partial class CharacterController : CharacterBody2D
{

	[ExportCategory("Player Variables")]
	[Export] private bool gameOver = false;
	private Sprite2D m_sprite;
	private float m_moveSpeed;
	[Export]
	public float MoveSpeed { get {return m_moveSpeed;} private set {m_moveSpeed = value; } }
	[Export]
	public int Health{get; private set;} = 100;

	private void GetMoveInput()
	{
		if(gameOver) return;
		// Get inputs to vector
		Vector2 moveVector = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");

		// Set player velocity
		Velocity = moveVector * m_moveSpeed;
	}

	private void FlipSprite()
	{
		// handle sprite orientation
		if( Velocity.X >= 0 && m_sprite.FlipH != true ) { m_sprite.FlipH = true; }
		if( Velocity.X < 0 && m_sprite.FlipH != false ) { m_sprite.FlipH = false; }
	}

	private void Die()
	{
		gameOver = true;
		m_sprite.FlipV = true;
	}
    public override void _Ready()
    {
		// fetch player sprite
        m_sprite = GetNode<Sprite2D>("Sprite");
    }
    public override void _PhysicsProcess(double delta)
    {
		GetMoveInput();
		FlipSprite();
		MoveAndSlide();
    }
	public void TakeDamage(int damage){
		Health -= damage;
		GD.Print(Health);
	}
}
