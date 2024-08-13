using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

	public Vector2I currentTileLoc;

	//Need to refactor at some point to allow tower selection
	[Export]
	public Pokemon[] pokemonList = new Pokemon[6];

	//build-tool texture;
	[Export]
	public Texture2D buildIcon;

	[Export]
	public Pokemon currentPokemon;

	[Export]
	public Node2D buildTool;
	private ShaderMaterial sm;

	[Export]
	public CanvasLayer UILayer;

	[Export]
	public Node resourceContainer;

	private PackedScene pokemonButton;

	private SignalHandlers _signalHandlers;

	private GameManager _gameManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		isBuilding = false;
		canBuild = false;
		inMenu = false;
		buildTool = GetNode<Node2D>("Build Tool");
		sm = (ShaderMaterial) buildTool.GetNode<Sprite2D>("SelectTile").Material;
		pokemonButton = ResourceLoader.Load<PackedScene>("res://Scenes/UI/pokemon_button.tscn");

		for(int i = 0; i < pokemonList.Length; i++) {
			if(pokemonList[i] != null) {
				pokemon_button newButton = (pokemon_button) pokemonButton.Instantiate();
				newButton.setPokemonResource(pokemonList[i]);
				UILayer.GetNode<Control>("PokemonMenu").GetNode<NinePatchRect>("NinePatchRect").GetNode<HBoxContainer>("HBoxContainer").AddChild(newButton);
			}
		}

		_signalHandlers = GetNode<SignalHandlers>("/root/SignalHandlers");
		_signalHandlers.PassPokemonResource += setCurrentPokemon;
		_signalHandlers.ToggleInMenuOn += inMenuOn;
		_signalHandlers.ToggleInMenuOff += inMenuOff;
		_signalHandlers.EmptyFaintedPokemonTile += resetTile;
		_signalHandlers.SendOranBerryToContainer += spawnOranBerry;

		_gameManager = GetNode<GameManager>("/root/GameManager");
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
		currentTileLoc = LocalToMap(ToLocal(mousePos));
		buildTool.GlobalPosition = ToGlobal(MapToLocal(currentTileLoc)) + new Vector2(32, 0);

		Vector2I cellAtlas = GetCellAtlasCoords(0, currentTileLoc);
		if (cellAtlas.Y == 0 && current_color != green) {
			current_color = green;
			canBuild = true;
			sm.SetShaderParameter("current_color", current_color);
		}

		if (cellAtlas.Y != 0 && current_color != red) {
			current_color = red;
			canBuild = false;
			sm.SetShaderParameter("current_color", current_color);
		}
	}

	public void buildPokemon() {
		if(canBuild && !inMenu && currentPokemon != null && currentPokemon.cost <= _gameManager.GetOranCurrency()) {
			int tileStyle = GetCellAtlasCoords(0, currentTileLoc).X;
			if(tileStyle == 0) SetCell(0, currentTileLoc, 0, new Vector2I(0, 1), 0);
			else if(tileStyle == 1) SetCell(0, currentTileLoc, 0, new Vector2I(1, 1), 0);

			PokemonScene newPokemon = ResourceLoader.Load<PackedScene>("res://Scenes/Pokemon/" + currentPokemon.sceneName + ".tscn").Instantiate<PokemonScene>();
			newPokemon.GlobalPosition = ToGlobal(MapToLocal(currentTileLoc));
			newPokemon.tileLoc = currentTileLoc;
			GetNode<Node>("PokemonContainer").AddChild(newPokemon);

			_gameManager.reduceOranCurrency(currentPokemon.cost);

		}
	}

	public void setCurrentPokemon(Pokemon resource) {
		currentPokemon = resource;
	}

	public void inMenuOn() {
		Debug.WriteLine("switching menu on");
		inMenu = true;
	}

	public void inMenuOff() {
		Debug.WriteLine("switiching menu off");
		inMenu = false;
	}

	public void resetTile(Vector2I tile) {
		int tileStyle = GetCellAtlasCoords(0, tile).X;
		if(tileStyle == 0) SetCell(0, tile, 0, new Vector2I(0, 0), 0);
		else if(tileStyle == 1) SetCell(0, tile, 0, new Vector2I(1, 0), 0);
	}

	public void spawnOranBerry(OranBerry oran) {
		resourceContainer.AddChild(oran);
		if(resourceContainer.GetChildCount() >= 51) {
			resourceContainer.GetChild(0).QueueFree();
		}
	}
}
