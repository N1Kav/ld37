using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField]
    private List<MissionScriptableObject> _missionPatterns;

    [SerializeField]
    private readonly List<Mission> _missions = new List<Mission>();

    public void GenerateNewMission()
    {
        var pattern = _missionPatterns.GetRandomElement();
        _missions.Add( new Mission( pattern ) );
    }
}
