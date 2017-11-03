using UnityEngine;

public class Cell : MonoBehaviour
{
    public Unit unit;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if ( Main.Instance.IsMouseDown )
        {
            if ( Main.Instance.currentUnit != null )
            {
                Main.Instance.currentUnit.TryAddStep( this );
            }
        }
    }

    private void OnMouseOver()
    {
        if ( Main.Instance.IsMouseDown )
        {
            if ( Main.Instance.currentUnit != null )
            {
                Main.Instance.currentUnit.TryAddStep( this );
            }
        }
    }

    private void OnMouseUp()
    {
        Main.Instance.currentUnit = null;
    }

    public void SetColor( Color color )
    {
        _renderer.color = color;
    }
}
