using System.Collections.Generic;
using UnityEngine;

public class Path
{
    private List<Cell> _steps = new List<Cell>();

    public void TryAddStep( Cell floor, Color color)
    {
        if (_steps.Count > 0 && _steps[_steps.Count - 1] == floor)
            return;

        if ( _steps.Count > 1 && _steps[ _steps.Count - 2 ] == floor )
        {
            if( _steps[ _steps.Count - 1 ] is Floor )
                _steps[ _steps.Count - 1 ].SetColor( Color.white );

            //Debug.Log("remove " + _steps[_steps.Count - 1].name);

            _steps.RemoveAt( _steps.Count - 1 );

            //Debug.Log(ToString());
            return;
        }

        if (_steps.Count > 0)
        {
            var isDiagonal = _steps[_steps.Count - 1].transform.position.x != floor.transform.position.x &&
                             _steps[_steps.Count - 1].transform.position.y != floor.transform.position.y;
            if (isDiagonal)
                return;
        }

        if( HasWall() )
        {
            return;
        }

        _steps.Add( floor );
        if( floor is Floor )
            floor.SetColor( color );

        //Debug.Log("add " + floor.name);
        //Debug.Log(ToString());
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

    public override string ToString()
    {
        var result = "[ ";
        foreach (var step in _steps)
            result += step.name + ",";
        result = result.TrimEnd(',');
        result += " ]";
        return result;
    }
}
