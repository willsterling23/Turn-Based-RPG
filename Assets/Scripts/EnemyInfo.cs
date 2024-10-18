using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class EnemyInfo : ScriptableObject
{
    [SerializeField] private string _enemyName;
    [SerializeField] private int _baseHealth;
    [SerializeField] private int _baseStrength;
    [SerializeField] private int _baseInitiative;
    [SerializeField] private GameObject _enemyVisualPrefab;

    public string EnemyName => _enemyName;
    public int BaseHealth => _baseHealth;
    public int BaseStrength => _baseStrength;
    public int BaseInitiative => _baseInitiative;
    public GameObject EnemyVisualPrefab => _enemyVisualPrefab;


}
