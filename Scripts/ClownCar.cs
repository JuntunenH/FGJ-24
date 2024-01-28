using Godot;
using System;
using System.Linq;

public partial class ClownCar : RigidBody2D
{

    /// <summary>
    /// When shop car comes to the scene, it can be only accessed once.
    /// </summary>
    private PackedScene blood = GD.Load<PackedScene>("res://Prefabs/UI/Blood.tscn");
    private bool _shopUsed = false;
    private bool _isCarStopped = false;

    public override void _Ready()
    {
        //GD.Print($"{Name} instantiated!");
    }

    /// <summary>
    /// When car exits on screen, it starts new timer for spawning the car and destroyes the last one
    /// </summary>
    private void OnScreenExited2D()
    {
        GD.Print("Car destroyed");
        var root = GetTree().CurrentScene;
        root.GetNode<Timer>("ClownCarTimer").Start();
        QueueFree();
    }

    public override void _PhysicsProcess(double delta)
    {
        foreach (var collider in GetCollidingBodies())
        {
            if (collider.IsInGroup("Player"))
            {
                GD.Print("Colliding with player!");
                //var player = collider.GetNode<CharacterBody2D>("PlayerCharacter");
            }                    
        }
        GD.Print(LinearVelocity);
        if (LinearVelocity.X > -4.0f && LinearVelocity.X < 4.0f)
            _isCarStopped = true;
        if (_isCarStopped)
            ApplyForce(new Vector2(50000.0f, 0.0f)); // WRUUUUUUUM :D
    }

    private void _OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            GD.Print("Player in the area");
            if (!_shopUsed) {
                var gameManager = GetNode<GameManager>("/root/GameManager");
                gameManager.SpawnShopScene();                
            }
        }
        else if (body.IsInGroup("Enemy"))
        {
            Node2D splatter = (Node2D)blood.Instantiate();
            splatter.Position = body.Position;
            GetParent().AddChild(splatter);
            body.QueueFree();
        }
    }

    private void _OnBodyExited(Node2D body)
    {
        if (body.IsInGroup("Player"))
        {
            _shopUsed = true;
        }
    }
}
