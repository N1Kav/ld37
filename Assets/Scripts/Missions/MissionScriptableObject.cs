﻿using System;
using UnityEngine;

public class MissionScriptableObject : ScriptableObject
{
    public int id;
    public string title;
    public int price;
    public Checkpoint[] checkpoints;
}

[Serializable]
public class Checkpoint
{
    public Target type;
    public float time;
}
