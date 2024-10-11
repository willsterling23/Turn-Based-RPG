using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class PartyManager : MonoBehaviour
{
    [SerializeField] private PartyMemberInfo[] _allMembers;
    [SerializeField] private List<PartyMember> _currentParty;
    [SerializeField] private PartyMemberInfo _defaultPartyMember;


    private void Awake()
    {
        if (_defaultPartyMember)
        {
            AddMemberToPartyByName(_defaultPartyMember.MemberName);
        }
    }

    public void AddMemberToPartyByName(string memberName)
    {
        var memberInfo = _allMembers.FirstOrDefault(member => member.MemberName == memberName);
        if (memberInfo == null) return;
        
        var newPartyMember = new PartyMember(memberInfo);
        _currentParty.Add(newPartyMember);
    }
    
}


[System.Serializable]
public class PartyMember
{
    public string MemberName;
    public int Level;
    public int CurrentHealth;
    public int MaxHealth;
    public int Strength;
    public int Initiative;
    public int CurrentExp;
    public int MaxExp;
    public GameObject MemberBattleVisualPrefab;
    public GameObject MemberOverworldVisualPrefab;

    
    // CONSTRUCTOR
    public PartyMember(PartyMemberInfo memberInfo)
    {
        MemberName = memberInfo.MemberName;
        Level = memberInfo.StartingLevel;
        CurrentHealth = memberInfo.BaseHealth;
        MaxHealth = CurrentHealth;
        Strength = memberInfo.BaseStrength;
        Initiative = memberInfo.BaseInitiative;
        MemberBattleVisualPrefab = memberInfo.MemberBattleVisualPrefab;
        MemberOverworldVisualPrefab = memberInfo.MemberOverworldVisualPrefab;
    }
    
}
