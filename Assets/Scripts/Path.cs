using System.Collections.Generic;
using UnityEngine;

public class Path
{
    private List<Cell> _steps = new List<Cell>();

    public void TryAddStep( Cell floor, Color color)
    {
        if( _steps.Count > 1 && _steps[ _steps.Count - 2 ] == floor )
        {
            if( _steps[ _steps.Count - 1 ] is Floor )
                _steps[ _steps.Count - 1 ].SetColor( Color.white );

            _steps.RemoveAt( _steps.Count - 1 );
            return;
        }

        if( HasWall() )
        {
            return;
        }

        _steps.Add( floor );
        if( floor is Floor )
            floor.SetColor( color );
    }

    public bool HasTarget()
    {
        return _steps.Count > 0 && _steps[ _steps.Count - 1 ] is Target;
    }

    private bool HasWall()
    {
        foreach (var floor in _steps)
        {
            if( floor is Wall )
                return true;
        }
        return false;
    }

    public void Clear()
    {
        foreach(var step in _steps)
        {
            if( step is Floor )
                step.SetColor( Color.white );
        }
        _steps.Clear();
    }

    public Cell GetFirst()
    {
        if( _steps.Count > 0 )
            return _steps[ 0 ];
        return null;
    }

    public void DeleteFirst()
    {
        if( _steps.Count > 0 )
        {
            if( _steps[ 0 ] is Floor )
                _steps[0].SetColor( Color.white );
            _steps.RemoveAt( 0 );
        }
    }

    public int Count()
    {
        return _steps.Count;
    }
}
