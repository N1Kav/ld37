using UnityEngine;
using System.Collections.Generic;
using System;

public class Main : MonoBehaviour
{
    static public Main Instance;

    [SerializeField]
    private Transform _missionsPanel;
    [SerializeField]
    private MissionUI _missionUIPrefab;

    [NonSerialized]
    public Unit currentUnit;

    private bool _mouseDown;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        if( Input.GetMouseButtonDown( 0 ) )
            _mouseDown = true;

        if( Input.GetMouseButtonUp( 0 ) )
        {
            _mouseDown = false;

            if( currentUnit != null )
            {
                if( !currentUnit.path.HasTarget() )
                    currentUnit.path.Clear();
                else
                    currentUnit.Move();
            }

            currentUnit = null;
        }
    }

    public bool IsMouseDown
    {
        get { return _mouseDown; }
    }
}
