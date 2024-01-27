using Godot;
using System;

public partial class DirectionArrow : Sprite2D
{

	[Export] private Node2D pivotTarget;
	[Export] private float moveSpeed = 10f;
	[Export] private float radius = 250f;
	private float sinTime = 0;

	public override void _Process(double delta)
    {

    }

    private void SetPosition(float angleInRad)
    {
        Vector2 moveTarget = new Vector2(Mathf.Cos(angleInRad) * radius, Mathf.Sin(angleInRad) * radius);

        GlobalPosition = moveTarget + pivotTarget.Position;
    }

	private void SetRotation()
	{
		float direction = pivotTarget.GlobalPosition.AngleToPoint(GlobalPosition);
		Rotation = direction;
	}

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseMotion eventMouseMotion){
			// get relative mouse position
			Vector2 relativeMousePos = eventMouseMotion.GlobalPosition - pivotTarget.GlobalPosition;
			float relativeAngle=relativeMousePos.Angle();
			SetPosition(relativeAngle);
			SetRotation();
		}
    }
}
