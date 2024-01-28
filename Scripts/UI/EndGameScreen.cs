using Godot;
using System;

public partial class EndGameScreen : Control
{
	[Export] private Label scoreText;
	[Export] public int score;
	[Export] PackedScene MainMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		scoreText.Text = $"Score: {score}";
	}

	public void GoMainMenu(){
		GetTree().ChangeSceneToPacked(MainMenu);
	}
	public void Quit(){
		GetTree().Quit();
	}
}
