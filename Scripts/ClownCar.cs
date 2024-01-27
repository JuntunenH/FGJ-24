using Godot;
using System;
using System.Linq;

public partial class ClownCar : RigidBody2D
{

    /// <summary>
    /// When shop car comes to the scene, it can be only accessed ones.
    /// </summary>
    private bool _shopUsed = false;

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
