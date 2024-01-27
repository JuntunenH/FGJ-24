using Godot;
using System;

public partial class GameManager : Node2D
{
    // Called when the node enters the scene tree for the first time.

    [Export] private PackedScene ClownCarScene { get; set; }
    [Export] private PackedScene ShopScene { get; set; }

    private PathFollow2D _carLeftSpawn = null;

	public override void _Ready()
	{
        GD.Print("GameManager created");
        ClownCarScene = GD.Load<PackedScene>("res://Prefabs/ClownCar.tscn");
        ShopScene = GD.Load<PackedScene>("res://Prefabs/UI/Shop.tscn");
        
        NewGame();
    }

    public void NewGame()
    {
        //TODO: Create new game logic..
        // Timers, signals etc.
        GD.Print("Game started..");

        var root = GetTree().CurrentScene;
        if (root != null) { GD.Print($"Root Node name: {root.Name}"); }
        _carLeftSpawn = root.GetNode<PathFollow2D>("LeftPath/LeftPathFollow");

        var clownCarTimer = root.GetNode<Timer>("ClownCarTimer");
        clownCarTimer.Timeout += SpawnClownCar;
        clownCarTimer.Start();
    }

    public void GameOver()
    {
        // TODO: Add necessary game over logic here
    }

    public void SpawnClownCar()
    {
        GD.Print("Spawning clown car!");
        _carLeftSpawn.ProgressRatio = GD.Randf();
        var clownCar = ClownCarScene.Instantiate<ClownCar>();
        AddChild(clownCar);
        clownCar.Position = _carLeftSpawn.Position;

        clownCar.LinearVelocity = new Vector2((float)GD.RandRange(200, 400), 0);
    }

    public void SpawnShopScene()
    {
        GD.Print("Spawn shop");
        //var shop = ShopScene.Instantiate();
        //GetTree().Paused = true;
    }


}
