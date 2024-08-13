using Godot;
using System;
using System.Diagnostics;

public partial class OranBerry : Sprite2D
{
	private bool isEntered;
	private SignalHandlers _signalHandlers;

	public void onBerryEntered() {
		Debug.WriteLine("Inside Berry");
		isEntered = true;
	}	

	public void onBerryExited() {
		Debug.WriteLine("Outside Berry");
		isEntered = false;
	}

    public override void _Ready()
    {
		_signalHandlers = GetNode<SignalHandlers>("/root/SignalHandlers");
		isEntered = false;
    }

    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("MouseEnter") && isEntered) {
			_signalHandlers.EmitSignal(nameof(SignalHandlers.AddOranBerry), 1);
			QueueFree();
		}
    }
}
