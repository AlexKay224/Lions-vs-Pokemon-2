using Godot;
using System;

    [GlobalClass]
    public partial class Wave : Resource
    {
        [Export]
        public PackedScene lion;
        [Export]
        public int quantity;

    }