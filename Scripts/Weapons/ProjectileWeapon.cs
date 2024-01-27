using Godot;
using System;

public partial class ProjectileWeapon : BaseWeapon
{
	[Export]
	public PackedScene WeaponProjectile;
    [Export]
    private DirectionArrow aimDirection;
    [Export]
    private float ProjectileSpeed;

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
		weaponInstance.ProjectileSpeed = ProjectileSpeed;
        Vector2 attackDirection = aimDirection.GetAttackDirection();
        weaponInstance.projectileDirection = attackDirection;
        weaponInstance.Rotation = Position.AngleToPoint(attackDirection);
        weaponInstance.Rotate(Mathf.DegToRad(90));
		GetTree().Root.AddChild(weaponInstance);
    }
}
