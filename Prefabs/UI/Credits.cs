using Godot;
using System;

public partial class Credits : Control
{
	private void _OnBackButtonPressed()
	{
        GetTree().ChangeSceneToFile("res://Prefabs/UI/MainMenu.tscn");
    }
}
