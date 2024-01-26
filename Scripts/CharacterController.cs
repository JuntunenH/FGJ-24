using Godot;
using System;


public partial class CharacterController : CharacterBody2D
{

	[ExportCategory("Player Variables")]

	private float m_moveSpeed;
	[Export]
	public float MoveSpeed { get {return m_moveSpeed;} private set {m_moveSpeed = value; } }

	private void GetMoveInput()
	{
		// Get inputs to vector
		Vector2 moveVector = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");

		// Set player velocity
		Velocity = moveVector * m_moveSpeed;
	}

    public override void _PhysicsProcess(double delta)
    {
		GetMoveInput();
		MoveAndSlide();
    }
}
