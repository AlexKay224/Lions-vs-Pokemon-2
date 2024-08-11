using Godot;
using System;

public partial class Level : TileMap
{

	public bool isBuilding;

	[Export]
	public Color green = new Color(0f, 0.8f, 0f, 0.3f);
	[Export]
	public Color red = new Color(0.8f, 0f, 0f, 0.3f);
	public Color current_color;

	public bool canBuild;
	public bool inMenu;

	public Vector2 currentTileLoc;

	//Need to refactor at some point to allow tower selection
	[Export]
	public Pokemon pokemon1;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		isBuilding = false;
		canBuild = false;
		inMenu = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
