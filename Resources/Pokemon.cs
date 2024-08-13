using Godot;
using System;

[GlobalClass]
public partial class Pokemon : Resource
{
    //not all of these are used for every pokemon
    [Export]
    public string name = "";
    [Export]
    public string description = "";
    [Export]
    public Texture2D texture = null;
    [Export]
    public float health = 0f;
    [Export]
    public float damage = 0f;
    [Export]
    public float speed = 1f; //speed of attacking
    [Export]
    public string sceneName;
    [Export]
    public int cost;
    [Export]
    public Pokemon evolution;
    [Export]
    public int evoCost;
    [Export]
    public float attackSpeed; //speed of attack travel
}
