using UnityEngine;
using System.Collections;

public class OrderTable : Target
{
    [SerializeField]
    private Mission _mission;
    private MissionItem _missionItem;

    [SerializeField]
    private Unit _unit;

    private void Start()
    {
        StartCoroutine(CreateNewMission());
        StartCoroutine(UpdateMission());
    }

    private IEnumerator UpdateMission()
    {
        if ( _mission != null )
        {
            _mission.TimerTick();
            if ( _mission.GetTime() == 0 )
            {
                Destroy( _missionItem.gameObject );
                MoneyManager.Instance.SubtractMoney( _mission.GetPrice() );
                StartCoroutine( CreateNewMission() );
            }
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(UpdateMission());
    }

    private IEnumerator CreateNewMission()
    {
        yield return new WaitForSeconds( Random.Range( 1f, 3f ) );

        _mission = MissionManager.Instance.GenerateNewMission();

        _missionItem = Instantiate<MissionItem>(MissionManager.Instance.missionPrefab, FindObjectOfType<Canvas>().transform);
        _missionItem.Load(_mission, this);
    }
}
