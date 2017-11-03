using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    public delegate void AddMissionDelegate(Mission mission);
    public AddMissionDelegate onAddMission;

    public delegate void RemoveMissionDelegate(Mission mission);
    public RemoveMissionDelegate onRemoveMission;

    [SerializeField]
    private List<MissionScriptableObject> _missionPatterns;

    [SerializeField]
    private List<Mission> _missions = new List<Mission>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GenerateNewMission();
        StartCoroutine(GenerateNextMission());
        StartCoroutine(UpdateMissions());
    }

    private IEnumerator GenerateNextMission()
    {
        var t = Random.Range(5f, 10f);
        yield return new WaitForSeconds(t);

        GenerateNewMission();
        StartCoroutine(GenerateNextMission());
    }

    private void GenerateNewMission()
    {
        var pattern = _missionPatterns.GetRandomElement();
        var mission = new Mission(pattern, Random.Range(10, 20));
        _missions.Add( mission );

        if (onAddMission != null)
            onAddMission(mission);
    }

    private IEnumerator UpdateMissions()
    {
        var removeItems = new List<Mission>();

        foreach (var mission in _missions)
        {
            mission.TimerTick();
            if (mission.GetTime() == 0)
                removeItems.Add(mission);
        }

        foreach(var mission in removeItems)
        {
            _missions.Remove(mission);
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(UpdateMissions());
    }
}
