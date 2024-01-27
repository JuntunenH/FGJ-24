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
        GD.Print($"{Name} instantiated!");
    }

    /// <summary>
    /// When car exits on screen, it starts new timer for spawning the car and destroyes the last one
    /// </summary>
    private void OnScreenExited2D()
    {
        //GD.Print("Car destroyed");
        GetNode<Timer>("/root/MainLevel/ClownCarTimer").Start();
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
            else if(collider.Name == "Enemy")           // TODO: Fix enemy to use group name
                GD.Print("Collided with enemy");
        }

    }

}
