using Godot;
using System;
using System.Diagnostics;

public partial class CurrencyUI : Control
{

	private SignalHandlers _signalHandlers;

	[Export]
	public Label oranBerryCount;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_signalHandlers = GetNode<SignalHandlers>("/root/SignalHandlers");
		_signalHandlers.UpdateOranBerryTally += updateTally;
	}

	public void updateTally(int num) {
		oranBerryCount.Text = num.ToString();
	}
}
