using UnityEngine;
using UnityEngine.UI;

public class MissionItem : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    [SerializeField]
    private Text _time;

    private Mission _mission;

    public void Load(Mission mission)
    {
        _mission = mission;

        _text.text = _mission.GetName();
    }

    private void Update()
    {
        _time.text = _mission.GetTime().ToString();
    }

    public Mission GetMission()
    {
        return _mission;
    }
}
