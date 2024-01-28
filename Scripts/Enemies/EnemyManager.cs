using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public partial class EnemyManager : Node
{
    [Export]
    public int MaxEnemies { get; set; } = 100;
    public int spawnCount = 1;
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
        int enemiesToSpawn = 1 * ((int)GameTime/20);
        PlayerPos = Player.GlobalPosition;
        if (spawnCount <= MaxEnemies && SpawnDelay < 0)
        {
            for (int i = 0; i < enemiesToSpawn; ++i)
            {
                SpawnEnemy(EnemyVariant.Melee);
            }
            SpawnDelay = 1;
        }
    }

    private void SpawnEnemy(EnemyVariant enemyVariant)
    {
        var instance = _enemyPrefabs[enemyVariant].Instantiate<EnemyController>();
        instance.Position = GetRandomPosAroundPlayer(SpawnRange);
        spawnCount +=1;
        instance.Hitpoints += instance.Hitpoints * ((int)GameTime/20);
        instance.Damage += instance.Damage * ((int)GameTime/20);
        // 2 minutes = same move as player
        instance.MovementSpeed += instance.MovementSpeed * ((int)GameTime/20);
        instance.Position=GetRandomPosAroundPlayer(SpawnRange);
        instance.EnemyDeath += HandleLoot;
        AddChild(instance);
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

    private void HandleLoot(PackedScene lootDrop, Vector2 lootPosition, EnemyController enemy)
    {
        enemy.EnemyDeath -= HandleLoot;
        Node2D lootNode = (Node2D)lootDrop.Instantiate();
		lootNode.Position = lootPosition;
		// Add the loot item to the scene
		AddChild(lootNode);
    }
}