using Godot;
using System;

[GlobalClass]
public partial class LionResource : Resource
{
    [Export]
    public float health;
    [Export]
    public float damage;
    [Export]
    public Godot.Collections.Array<Type.T> resistances;
    [Export]
    public float Speed;
}
