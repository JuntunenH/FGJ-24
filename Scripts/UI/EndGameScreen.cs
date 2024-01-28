using Godot;
using System;

public partial class EndGameScreen : Control
{
	[Export] private Label scoreText;
	[Export] public int score;
	[Export] CharacterController playerScore;
    // Called when the node enters the scene tree for the first time.

    public override void _Ready()
	{
		ProcessMode = ProcessModeEnum.Always;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		scoreText.Text = $"Score: {score}";
	}
	public void UpdateScore(){
		score = playerScore.money;
	}
	public void ShowScreen(){
		this.Show();
		GetTree().Paused = true;
	}
	public void GoMainMenu(){
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://Prefabs/UI/MainMenu.tscn");
	}
	public void Quit(){
		GetTree().Quit();
	}
}
