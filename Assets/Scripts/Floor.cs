using UnityEngine;

public class Floor : MonoBehaviour
{
    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        if( Main.Instance.IsMouseDown )
        {
            if (Main.Instance.currentUnit != null)
            {
                Main.Instance.currentUnit.TryAddStep( this );
            }
        }
    }

    void OnMouseUp()
    {
        Main.Instance.currentUnit = null;
    }

    public void SetColor(Color color)
    {
        _renderer.color = color;
    }
}
