using Godot;
using System;

public partial class CameraController : Camera2D
{
	[ExportCategory("Camera Settings")]
	[ExportGroup("Target")]
	[Export]
	private Node2D m_cameraTarget;
	[Export]
	private Vector2 m_offsetVector;
	[ExportGroup("Variables")]
	[Export]
	private float m_cameraDamp = 10f;
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
        SmoothFollow(delta);
    }

    private void SmoothFollow(double delta)
    {
        Vector2 targetPosition = m_cameraTarget.GlobalPosition + m_offsetVector;

        Position = new Vector2((float)Mathf.Lerp(Position.X, targetPosition.X, delta * m_cameraDamp), (float)Mathf.Lerp(Position.Y, targetPosition.Y, delta * m_cameraDamp));
    }

}
