using UnityEngine;
using System;

public class Main : MonoBehaviour
{
    public static Main Instance;

    [NonSerialized]
    public Unit currentUnit;

    private bool _mouseDown;

    private void Awake()
    {
        Instance = this;
    }    

    private void Update()
    {
        if ( Input.GetMouseButtonDown( 0 ) )
            _mouseDown = true;

        if ( Input.GetMouseButtonUp( 0 ) )
        {
            _mouseDown = false;

            if ( currentUnit != null )
            {
                if ( !currentUnit.path.HasTarget() )
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
