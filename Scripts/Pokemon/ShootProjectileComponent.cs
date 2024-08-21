using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public partial class ShootProjectileComponent : Node2D
{

	[Export]
	public PackedScene projectileScene;
	[Export]
	public Area2D range;
	[Export]
	public Pokemon pokeRes;
	[Export]
	public Timer timer;

	private List<Lion> targetList;
	private bool canShoot;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer.WaitTime = pokeRes.speed;
		canShoot = true;
		targetList = new List<Lion>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(canShoot && targetList.Any()) Shoot();
	}

	public void onTimeout() {
		canShoot = true;
	}

	public void onLionEntered(Area2D l) {
		if(l is LionHitbox) {
			Lion lion = (Lion) l.GetParent();
			targetList.Add(lion);
		}
	}

	public void onLionExited(Area2D l) {
		if(l is LionHitbox) {
			Lion lion = (Lion) l.GetParent();
			targetList.Remove(lion);
		}

	}

	public void Shoot() {
		canShoot = false;
		timer.Start();
		Projectile proj = projectileScene.Instantiate<Projectile>();
		proj.damage = pokeRes.damage;
		proj.speed = pokeRes.attackSpeed;
		proj.direction = (targetList[0].GlobalPosition - GlobalPosition).Normalized() * proj.speed;
		AddChild(proj);
	}


}
