using Godot;
using System;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	private void _OnButtonNewGamePressed()
	{
		GetTree().ChangeSceneToFile("res://Prefabs/GameWorld.tscn");
    }
    private void _OnButtonCreditsPressed()
    {
        //GetTree().ChangeSceneToFile("res://GameWorld.tscn");
    }
    private void _OnButtonQuitGamePressed()
    {
		GetTree().Quit();
    }
}
