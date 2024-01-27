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

		sinTime = (float)delta*moveSpeed;
		Vector2 moveTarget = new Vector2(Mathf.Cos(sinTime)*radius, Mathf.Sin(sinTime)*radius);

		GlobalPosition = moveTarget+pivotTarget.Position;
		LookAt(GetGlobalMousePosition());
	}

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseMotion eventMouseMotion){
			// get relative
			Vector2 relativeMousePos = eventMouseMotion.GlobalPosition - pivotTarget.GlobalPosition;
			GD.Print(relativeMousePos);
		}
    }
}
