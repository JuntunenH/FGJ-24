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
		_sound = GetNode<AudioStreamPlayer2D>("/root/World/AudioStreamPlayer2D");
		_sound.Stream = GD.Load<AudioStream>("res://Audio/BananaSound.mp3");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_body_entered(Node2D body)
	{
			if(body.IsInGroup("Player"))
			{
				_sound.Play();
				_player.AddMoney(1);
				GD.Print("Player money: ", _player.money);
				QueueFree();
			}
	}
}
