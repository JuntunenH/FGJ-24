using Godot;
using System;

public partial class EndGameScreen : Control
{
	[Export] private Label scoreText;
	[Export] public int score;
	[Export] PackedScene MainMenu;
	[Export] Node2D playerScore;
    // Called when the node enters the scene tree for the first time.

    public override void _Ready()
	{
        GetNode<GameManager>("/root/GameManager")?.NewGame();
		ProcessMode = ProcessModeEnum.Always;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		scoreText.Text = $"Score: {score}";
	}
	public void ShowScreen(){
		this.Show();
		GetTree().Paused = true;
	}
	public void GoMainMenu(){
		GetTree().Paused = false;
		GetTree().ChangeSceneToPacked(MainMenu);
	}
	public void Quit(){
		GetTree().Quit();
	}
}
