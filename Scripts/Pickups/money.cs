using Godot;
using System;

public partial class money : Area2D
{
	private CharacterController _player;
	private AudioStreamPlayer2D _sound;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetNode<CharacterController>("/root/World/PlayerCharacter");
		_sound = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		_sound.Play();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_body_entered(Node2D body)
	{
			if(body.IsInGroup("Player"))
			{
				_player.money +=1;
				GD.Print("Player money: ", _player.money);
				QueueFree();
			}
	}
}
