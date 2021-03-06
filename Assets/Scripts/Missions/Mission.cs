﻿using System;
using UnityEngine;

[Serializable]
public class Mission
{
    [SerializeField]
    private MissionScriptableObject _pattern;

    [SerializeField]
    private int _time;

    public Mission(MissionScriptableObject pattern, int time)
    {
        _pattern = pattern;
        _time = time;
    }

    public void TimerTick()
    {
        _time--;

        /*if (_time == 0)
        {
            if (MissionManager.Instance.onRemoveMission!=null)
                MissionManager.Instance.onRemoveMission(this);
        }*/
    }

    public string GetName()
    {
        return _pattern.name;
    }

    public int GetTime()
    {
        return _time;
    }

    public int GetPrice()
    {
        return _pattern.price;
    }

    public Checkpoint[] GetCheckpoints()
    {
        return _pattern.checkpoints;
    }
}
