using Godot;
using System;

public partial class GameManager : Node2D
{

    public float MoveSpeedMultp { get; set; } = 1.0f;
    public float ATKSpeedMultp { get; set; } = 1.0f;
    public float ATKSizeMultp { get; set; } = 1.0f;

    
    // PackedScenes
    private PackedScene ClownCarScene = null;
    private PackedScene ShopScene = null;

    // PlayerCamera manager
    private Camera2D _camera2D = null;

	public override void _Ready()
	{
        GD.Print("GameManager created");
        ClownCarScene = GD.Load<PackedScene>("res://Prefabs/ClownCar.tscn");
        ShopScene = GD.Load<PackedScene>("res://Prefabs/UI/Shop.tscn");
        
        NewGame();
    }

    public void NewGame() {
        //TODO: Create new game logic..
        // Timers, signals etc.
        GD.Print("Game started..");

        var root = GetTree().CurrentScene;
        if (root != null) { GD.Print($"Root Node name: {root.Name}"); }
        //_carLeftSpawn = root.GetNode<PathFollow2D>("LeftPath/LeftPathFollow");
        _camera2D = root.GetNode<Camera2D>("Camera2D");

        var clownCarTimer = root.GetNode<Timer>("ClownCarTimer");
        clownCarTimer.Timeout += SpawnClownCar;
        clownCarTimer.Start();
    }

    public void GameOver(){
        // TODO: Add necessary game over logic here
    }

    public void SpawnClownCar() {
        GD.Print("Spawning clown car!");

        // Spawn position on screen
        var topLeft = _camera2D.GetScreenCenterPosition() - _camera2D.GetViewportRect().Size / 2; // topLeft
        var bottomRight = _camera2D.GetScreenCenterPosition() + _camera2D.GetViewportRect().Size / 2; // bottomRight

        var spawnPositions = new[] { topLeft, bottomRight };

        //_carLeftSpawn.ProgressRatio = GD.Randf();
        var clownCar = ClownCarScene.Instantiate<ClownCar>();

        clownCar.Position = spawnPositions[GD.Randi() % spawnPositions.Length];

        // Randomize car sprite horizontaly
        clownCar.GetNode<Sprite2D>("Sprite2D").FlipH = GD.Randi() % 2 == 0;

        if (clownCar.Position == bottomRight)
            clownCar.LinearVelocity = new Vector2((float)GD.RandRange(200, 400), 0) * -1;
        else
            clownCar.LinearVelocity = new Vector2((float)GD.RandRange(200, 400), 0);

        AddChild(clownCar);
    }

    public void SpawnShopScene() {
        //GD.Print("Spawn shop");
        var shop = (Node2D)ShopScene.Instantiate();
        _camera2D.AddChild(shop);

        GetTree().Paused = true;
    }

}
