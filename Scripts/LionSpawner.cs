using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

public partial class LionSpawner : Node
{

	[Export]
	public Level environment;
	[Export]
	public Stage level;
	[Export]
	public Timer timer;
	[Export]
	public Timer waveDelay;

	private int currentWaveCount; //counts from 0
	private int maxWave;
	private Wave currentWave;
	private Lion currentLion;
	private Godot.Collections.Array<Node> paths;

	private Queue<Lion> lionQueue;

	private ulong currentTick;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentWaveCount = 0;
		maxWave = level.wave.Count;
		Debug.WriteLine("Max Wave: " + maxWave);
		paths = environment.GetNode<Node>("PathsContainer").GetChildren();
		lionQueue = new Queue<Lion>();
		timer.WaitTime = level.waitTimes[currentWaveCount];
        timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void onTimeout() {
		if(currentWaveCount < maxWave) StartWave();
			currentWaveCount++;
		if(currentWaveCount < maxWave) timer.WaitTime = level.waitTimes[currentWaveCount];
			timer.Start();
	}  

	public void StartWave() {
		Debug.WriteLine("Starting Wave " + currentWaveCount);
		currentWave = level.wave[currentWaveCount];

		for(int i = 0; i < currentWave.quantity; i++) {
			currentLion = currentWave.lion.Instantiate<Lion>();
			lionQueue.Enqueue(currentLion);
		}

		if(waveDelay.IsStopped()) waveDelay.Start();
	}

	public void IterateThroughWave() {
		Lion activateLion = lionQueue.Dequeue();
		paths.PickRandom().AddChild(activateLion);
		if(lionQueue.Any()) waveDelay.Start();
	}
}
