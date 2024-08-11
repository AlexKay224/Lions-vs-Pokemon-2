using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

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
	public Pokemon[] pokemonList = new Pokemon[6];

	//build-tool texture;
	[Export]
	public Texture2D buildIcon;

	public Pokemon currentPokemon;

	[Export]
	public Node2D buildTool;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		isBuilding = false;
		canBuild = false;
		inMenu = false;
		buildTool = GetNode<Node2D>("Build Tool");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("Build")) {
			isBuilding = !isBuilding;
			if(!isBuilding) buildTool.Hide();
			else buildTool.Show();
		}

		if(isBuilding) {
			updateBuildTool();
			if(Input.IsActionJustPressed("MouseEnter")) buildPokemon();
		}
	}

	public void updateBuildTool() {
		Vector2 mousePos = GetGlobalMousePosition();
		currentTileLoc = this.LocalToMap(mousePos);
		buildTool.GlobalPosition = this.MapToLocal((Vector2I) currentTileLoc);
	}
}
