using Godot;
using System;

public partial class Pokemon : Resource
{
    //not all of these are used for every pokemon
    [Export]
    public string name { get; set; }
    [Export]
    public string description { get; set; }
    [Export]
    public Texture2D texture { get; set; }
    [Export]
    public float health { get; set; }
    [Export]
    public float damage { get; set; }
    [Export]
    public float speed { get; set; }

    public Pokemon() : this(null, null, null, 0f, 0f, 0f) {}

    public Pokemon(string n, string desc, Texture2D t, float h, float d, float s) {
        name = n;
        description = desc;
        texture = t;
        health = h;
        damage = d;
        speed = s;
    }
}
