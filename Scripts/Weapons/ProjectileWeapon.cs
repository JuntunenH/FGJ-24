using Godot;
using System;

public partial class ProjectileWeapon : BaseWeapon
{
	[Export]
	public PackedScene WeaponProjectile;

    public override void _Ready()
    {
        base._Ready();
		isActive = true;
    }
    public override void Attack()
    {
        base.Attack();
		Projectile weaponInstance = WeaponProjectile.Instantiate<Projectile>();
        weaponInstance.Position = GlobalPosition;
		weaponInstance.ProjectileSpeed = 500f;
        weaponInstance.projectileDirection = GlobalPosition.DirectionTo(GetGlobalMousePosition());
        weaponInstance.LookAt(GetGlobalMousePosition());
        weaponInstance.Rotate(Mathf.DegToRad(90));
		GetTree().Root.AddChild(weaponInstance);
    }
}
