using System.Collections.Generic;
using UnityEngine;

public class Path
{
    private List<Floor> _steps = new List<Floor>();

    public void TryAddStep(Floor floor, Color color)
    {
        if( _steps.Count > 1 && _steps[ _steps.Count-2 ] == floor )
        {
            floor.SetColor( Color.white );
            _steps[ _steps.Count - 1 ].SetColor( Color.white );

            _steps.RemoveAt( _steps.Count - 1 );
            return;
        }
        _steps.Add( floor );
        if( !(floor is Target) )
            floor.SetColor( color );
    }

    public bool HasTarget()
    {
        return _steps.Count > 0 && _steps[ _steps.Count - 1 ] is Target;
    }

    public void Clear()
    {
        foreach(var step in _steps)
        {
            if( step is Target )
                continue;
            step.SetColor( Color.white );
        }
        _steps.Clear();
    }

    public Floor GetFirst()
    {
        if( _steps.Count > 0 )
            return _steps[ 0 ];
        return null;
    }

    public void DeleteFirst()
    {
        if( _steps.Count > 0 )
        {
            if( !(_steps[ 0 ] is Target) )
                _steps[0].SetColor( Color.white );
            _steps.RemoveAt( 0 );
        }
    }

    public int Count()
    {
        return _steps.Count;
    }
}
