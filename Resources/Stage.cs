using Godot;
using System;

[GlobalClass]
    public partial class Stage : Resource
    {
       [Export]
       public Godot.Collections.Array<Wave> wave;
       [Export]
       public Godot.Collections.Array<float> waitTimes;
    }