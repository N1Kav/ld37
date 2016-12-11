using UnityEngine;
using DG.Tweening;

public class Unit : MonoBehaviour
{
    public Color color;
    public Path path;

    void OnMouseDown()
    {
        path = new Path();

        Main.Instance.currentUnit = this;
    }

    public void TryAddStep(Floor floor)
    {
        path.TryAddStep( floor, color );
    }

    public void Move()
    {
        if( path.Count() < 1 )
            return;

        var pos = path.GetFirst().transform.position;
        this.transform.DOMove( pos, 0.5f ).SetEase(Ease.Linear).OnComplete( () => { Move(); } );
        path.DeleteFirst();
    }
}
