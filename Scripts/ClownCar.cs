using Godot;
using System;
using System.Linq;

public partial class ClownCar : RigidBody2D
{

    /// <summary>
    /// When shop car comes to the scene, it can be only accessed ones.
    /// </summary>
    private bool _shopUsed = false;

    private Timer _spawnTimer = null;

    public override void _Ready()
    {
        GD.Print($"{Name} instantiaded!");
    }

    private void OnScreenExited2D()
    {
        GD.Print("Car destroyed");

        QueueFree();
    }

    
}
