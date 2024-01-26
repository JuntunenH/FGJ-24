using Godot;
using System;



public partial class WeaponHandler : Node
{

	[Export]
	public Variant armory = new Godot.Collections.Array<Area2D>();

	[Export]
	public PackedScene weaponScene;
	//public List<BaseWeapon> Armory;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{


	}


	public void AddWeapon()
	{
		Projectile weaponInstance = weaponScene.Instantiate<Projectile>();
		weaponInstance.ProjectileSpeed = 500f;
		AddChild(weaponInstance);
	}
}
