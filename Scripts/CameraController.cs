using Godot;
using System;

public partial class CameraController : Camera2D
{
	[ExportCategory("Camera Settings")]
	[Export]
	private Node2D m_cameraTarget;
	[Export]
	private float m_cameraSpeed =  40.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(m_cameraTarget == null){
			m_cameraTarget = (Node2D)GetTree().GetFirstNodeInGroup("Player");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 targetPosition = GlobalPosition.DirectionTo(m_cameraTarget.GlobalPosition) * m_cameraSpeed;
		//Position += targetPosition;

	}
}
