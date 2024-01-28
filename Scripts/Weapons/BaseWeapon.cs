using Godot;
using System;


public partial class BaseWeapon : Node2D
{
	private int m_damage;
	[Export]
	public int Damage { get {return m_damage;} set {m_damage = value;} }

	private float m_cooldown;
	[Export]
	public float Cooldown { get {return m_cooldown;} set {m_cooldown = value;} }

	[Export] protected int weaponLevel = 0;
	private float m_cooldownTimer;

	public float CooldownTimer { get {return m_cooldownTimer;} protected set {m_cooldownTimer = value;} }
	public bool isActive = false;
	public virtual void Attack()
	{
		ResetTimer();
	}

	private void ResetTimer()
	{
		m_cooldownTimer = m_cooldown;
	}
    public override void _Ready()
    {
        ResetTimer();
    }
    public override void _Process(double delta)
    {
		if(!isActive) return;
		if(m_cooldownTimer >= 0) {
			m_cooldownTimer -= (float)delta;
			return;
		}
		Attack();
    }

	public virtual void IncreaseSize(float percentage)
	{
		Scale *= percentage;
		GD.Print($"Size increased to {Scale}");
	}

	public virtual void IncreaseAttackSpeed(float percentage)
	{
		m_cooldown *= percentage;
		GD.Print($"ATK SPD increased to {m_cooldown}");
	}

	public virtual void IncreaseDamage(float percentage)
	{
		float damageIncrease = Damage*percentage;
		Damage += (int)Mathf.Floor(damageIncrease);
		GD.Print($"ATK DMG increase to: {Damage}");
	}

	public virtual void UpgradeWeapon()
	{
		if(!isActive) isActive = true;
		GD.Print($"Weapon {Name} Upgraded");
		weaponLevel += 1;
	}
}
