using UnityEngine;
using DG.Tweening;

public class Unit : MonoBehaviour
{
    public Color color;
    public Path path = new Path();

    private bool _boom;

    void OnMouseDown()
    {
        _boom = false;
        Main.Instance.currentUnit = this;
    }

    public void TryAddStep( Cell floor )
    {
        path.TryAddStep( floor, color );
    }

    public void Move()
    {
        if( _boom )
            return;

        if( path.Count() < 1 )
            return;

        var floor = path.GetFirst();

        if( floor.unit != null )
        {
            Boom();
            floor.unit.Boom();
            return;
        }

        floor.unit = this;
        var pos = floor.transform.position;
        pos.z = this.transform.localPosition.z;
        this.transform.DOMove( pos, 0.5f ).SetEase( Ease.Linear ).OnComplete( () => { floor.unit = null; Move(); } );
        path.DeleteFirst();
    }

    public void Boom()
    {
        _boom = true;
        path.Clear();
    }
}
