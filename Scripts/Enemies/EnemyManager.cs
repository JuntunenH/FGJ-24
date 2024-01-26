using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public partial class EnemyManager : Node
{
    public int testSpawn = 1;
    public const int SpawnRange = 500;
    public float SpawnRate {get; private set;}= 1;
    public double SpawnDelay {get; private set;}=1;
    public  Dictionary<EnemyVariant, PackedScene> _enemyPrefabs;
    private readonly List<EnemyController> _enemies = new();
    public List<EnemyController> Enemies => _enemies;
    public CharacterController Player;
    public double GameTime { get; private set; } = 0;
    public Vector2 PlayerPos;

    public override void _Ready()
    {
        base._Ready();
        _enemyPrefabs = new()
        {
            { EnemyVariant.Melee, GD.Load<PackedScene>("res://Prefabs/EnemyMeleeMime.tscn") },
            { EnemyVariant.Range, GD.Load<PackedScene>("res://Prefabs/EnemyRangedMime.tscn") },
        };
        Player = GetNode<CharacterController>("/root/World/PlayerCharacter");
    }

    public override void _Process(double delta)
    {
        GameTime += delta;
        SpawnDelay -= delta;
        int enemiesToSpawn = 1;
        PlayerPos = Player.GlobalPosition;
        if (testSpawn <= 10)
        {
            for (int i = 0; i < enemiesToSpawn; ++i)
            {
                SpawnEnemy(EnemyVariant.Melee);
            }
        }
    }

    private void SpawnEnemy(EnemyVariant enemyVariant)
    {
        var testScene = GD.Load<PackedScene>("res://Prefabs/EnemyMeleeMime.tscn");
        var instance = testScene.Instantiate<EnemyController>();
        testSpawn +=1;
        AddChild(instance);
        instance.Position = GetRandomPosAroundPlayer(SpawnRange);
        GD.Print(instance.Position);
        // Tää on aivan vitun kesken (Koita kaivaa se controller tai body tai mikä onkaan ja vaihtaa position)
        

        // var sceneEnemy = _enemyPrefabs[enemyVariant].Instantiate();
        // var enemy = sceneEnemy.GetNode<EnemyController>("/root/World/Enemy");
        // enemy.Hitpoints = enemy.Hitpoints * ((int)GameTime/1000); // Ei hajuakaan gametime arvoista, pitää testata
        // enemy.Damage = enemy.Damage * ((int)GameTime/1000);
        // enemy.MovementSpeed = enemy.MovementSpeed * ((int)GameTime/1000);
        // enemy.Position=GetRandomPosAroundPlayer(SpawnRange);
        // Player.GetNode("/root/World").AddChild(enemy);

        // return enemy;
    }
    public Vector2 GetRandomPosAroundPlayer(int SpawnRange) => PlayerPos + SpawnRange * new Vector2(
            (float)GD.RandRange(-1f, 1f),
            (float)GD.RandRange(-1f, 1f)
            ).Normalized();

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey e && e.Keycode == Key.Space && e.Pressed)
            SpawnEnemy(EnemyVariant.Melee);
    }

}