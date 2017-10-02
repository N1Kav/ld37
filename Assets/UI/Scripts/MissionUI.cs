using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public Mission mission;

    void Start()
    {
        if (mission != null)
            _text.text = mission.title;
    }
}
