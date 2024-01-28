using Godot;
using System;

public partial class GameManager : Node2D
{

    public float MoveSpeedMultp { get; set; } = 1.0f;
    public float ATKSpeedMultp { get; set; } = 1.0f;
    public float ATKSizeMultp { get; set; } = 1.0f;

    [Signal] public delegate void LevelUpEventEventHandler(string skill);
	
    public void Initialize()
    {
        MoveSpeedMultp = 1.0f;
        ATKSpeedMultp = 1.0f;
        ATKSizeMultp = 1.0f;
    }

    public void LevelUp(string skill)
    {
        EmitSignal(SignalName.LevelUpEvent, skill);
    }

}
