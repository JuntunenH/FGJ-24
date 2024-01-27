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
	[Signal]
	public delegate void GameOverEventHandler();
	private Timer damageImmunity;
	private bool is_Invulnerable = false;

	public override void _Ready()
    {
		// fetch player sprite
        m_sprite = GetNode<Sprite2D>("Sprite");
		damageImmunity = GetNode<Timer>("ImmunityTimer");
		damageImmunity.Timeout += OnTimerTimeout;
    }

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
		EmitSignal(SignalName.GameOver);
		GetTree().Paused = true;
	}
    public override void _PhysicsProcess(double delta)
    {
		GetMoveInput();
		FlipSprite();
		MoveAndSlide();
    }
	public void TakeDamage(int damage){
		if(!is_Invulnerable)
		{
			Health -= damage;
			is_Invulnerable = true;
			// This needs effect! glow or something
			damageImmunity.Start();
			GD.Print("Player health left: ",Health);
			if(Health<=0)
			{
				Die();
			}
		}
	}
	public void OnTimerTimeout()
	{
		is_Invulnerable = false;
		// glow effect should end here
	}
	public void _on_area_2d_body_entered(Node2D body)
	{
		if(body.IsInGroup("Enemy")){
			EnemyController enemy = (EnemyController)body;
			TakeDamage(enemy.Damage);
		}
	}
}
