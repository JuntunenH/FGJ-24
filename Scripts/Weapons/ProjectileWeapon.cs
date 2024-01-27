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
    [Export]
    private bool addRotation = false;
    [Export]
    private float addedRotation = 0f;

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

        if(addRotation)
        {
            weaponInstance.Rotation = Position.AngleToPoint(attackDirection);
            weaponInstance.Rotate(Mathf.DegToRad(addedRotation));
        }

        weaponInstance.Damage = Damage;
		GetTree().Root.AddChild(weaponInstance);
    }
}
