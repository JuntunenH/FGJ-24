using Godot;
using System;


public partial class BaseWeapon : Area2D
{
	public int Damage { get; set; }
	public float Cooldown { get; set;	}

	public virtual void Attack()
	{
		
	}
}
