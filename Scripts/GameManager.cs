using Godot;
using System;

public partial class GameManager : Node2D
{
    // Called when the node enters the scene tree for the first time.

    [Export]
    private PackedScene ClownCar {  get; set; }

    private PathFollow2D _carLeftSpawn = null;

	public override void _Ready()
	{
        _carLeftSpawn = GetNode<PathFollow2D>("LeftPath/LeftPathFollow");
        
        NewGame();
    }

    public void NewGame()
    {
        //TODO: Create new game logic..
        // Timers, signals etc.
        GD.Print("Game started..");
        GetNode<Timer>("ClownCarTimer").Start();
    }

    public void GameOver()
    {
        // TODO: Add necessary game over logic here
    }

    public void SpawnClownCar()
    {
        GD.Print("Spawning clown car!");
        _carLeftSpawn.ProgressRatio = GD.Randf();
        var clownCar = ClownCar.Instantiate<ClownCar>();
        AddChild(clownCar);
        clownCar.Position = _carLeftSpawn.Position;

        clownCar.LinearVelocity = new Vector2((float)GD.RandRange(200, 400), 0);
        //clownCar.LinearVelocity = new Vector2(1000, 0); // This is for testing :D
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        
    }
}
