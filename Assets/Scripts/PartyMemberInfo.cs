using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Party Member", menuName = "New Party Member")]
public class PartyMemberInfo : ScriptableObject
{
    [SerializeField] private string _memberName;
    [SerializeField] private int _startingLevel;
    [SerializeField] private int _baseHealth;
    [SerializeField] private int _baseStrength;
    [SerializeField] private int _baseInitiative;
    [SerializeField] private GameObject _memberBattleVisualPrefab; 
    [SerializeField] private GameObject _memberOverworldVisualPrefab; 
    
    
}
