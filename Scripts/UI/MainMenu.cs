using Godot;
using System;

public partial class MainMenu : Control
{
	private void _OnButtonNewGamePressed()
	{
		GetTree().ChangeSceneToFile("res://Prefabs/GameWorld.tscn");
    }
    private void _OnButtonCreditsPressed()
    {
        GetTree().ChangeSceneToFile("res://Prefabs/UI/Credits.tscn");
    }
    private void _OnButtonQuitGamePressed()
    {
		GetTree().Quit();
    }
}
