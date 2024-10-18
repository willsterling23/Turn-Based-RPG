using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyInfo[] _allEnemies;
    [SerializeField] private List<Enemy> _currentEnemies;

    private const float LEVEL_MODIFIER = .5f;

    private void Awake()
    {
        GenerateEnemyByName("Slime", 1);
    }

    private void GenerateEnemyByName(string enemyName, int enemyLevel)
    {
        foreach (var enemy in _allEnemies)
        {
            if (enemy.EnemyName == enemyName)
            {
                var newEnemy = new Enemy(enemy, enemyLevel, LEVEL_MODIFIER);
                _currentEnemies.Add(newEnemy);
            }
        }
    }
    
    
}

[System.Serializable]
public class Enemy
{
    public string EnemyName;
    public int Level;
    public int CurrentHealth;
    public int MaxHealth;
    public int Strength;
    public int Initiative;
    public GameObject EnemyVisualPrefab;
    
    
    // CONSTRUCTOR
    public Enemy(EnemyInfo enemyInfo, int level, float levelModifier)
    {
        EnemyName = enemyInfo.EnemyName;
        Level = level;
        MaxHealth = Mathf.RoundToInt(enemyInfo.BaseHealth + (enemyInfo.BaseHealth * levelModifier));
        CurrentHealth = MaxHealth;
        Strength = Mathf.RoundToInt(enemyInfo.BaseStrength + (enemyInfo.BaseStrength * levelModifier));
        Initiative = Mathf.RoundToInt(enemyInfo.BaseInitiative + (enemyInfo.BaseInitiative * levelModifier));
        EnemyVisualPrefab = enemyInfo.EnemyVisualPrefab;
    }

}