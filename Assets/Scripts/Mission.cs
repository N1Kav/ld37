using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Mission
{
    public string title;
    [SerializeField]
    private List<Checkpoint> _checkpoints = new List<Checkpoint>();
    
    private int _currentCheckpoint;
}
