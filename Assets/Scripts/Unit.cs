using UnityEngine;
using DG.Tweening;

public class Unit : MonoBehaviour
{
    public Color color;
    public Path path = new Path();
    public float speed = 0.2f;

    [SerializeField]
    private Reminder _reminderPrefab;
    private Reminder _reminder;

    private Mission _mission;

    [SerializeField]
    private int _currentCheckpointIndex;

    private bool _boom;

    private void Start()
    {
        _reminder = Instantiate( _reminderPrefab, FindObjectOfType<Canvas>().transform );
        _currentCheckpointIndex = 0;
    }

    private void Update()
    {
        if ( _reminder != null )
        {
            var screenPos = Camera.main.WorldToScreenPoint( this.transform.localPosition );
            screenPos.x += 10;
            screenPos.y += 66;
            _reminder.transform.position = screenPos;
        }
    }

    private void OnMouseDown()
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
        if ( _boom )
            return;

        if ( path.Count() < 1 )
            return;

        if ( _reminder != null )
            _reminder.SetTarget( path.GetTarget() );

        var floor = path.GetFirst();

        if ( floor.unit != null )
        {
            Boom();
            floor.unit.Boom();
            return;
        }

        floor.unit = this;
        var pos = floor.transform.position;
        pos.z = this.transform.localPosition.z;
        this.transform.DOMove( pos, speed ).SetEase( Ease.Linear ).OnComplete( () =>
                                                                               {
                                                                                   floor.unit = null;

                                                                                   if ( path.Count() < 1 )
                                                                                   {
                                                                                       var target = floor as Target;
                                                                                       if ( target != null )
                                                                                           TryIntercat(target);
                                                                                       return;
                                                                                   }

                                                                                   Move();
                                                                               } );
        path.DeleteFirst();
    }

    public void Boom()
    {
        _boom = true;
        path.Clear();
    }

    public void SetMission(Mission mission)
    {
        _mission = mission;
        _currentCheckpointIndex = 0;
    }

    private void TryIntercat( Target target )
    {
        // wrong target
        if (_mission.GetCheckpoints()[_currentCheckpointIndex].type.id != target.id)
            return;

        // TODO:
        Debug.Log( "Interact with " + target.name );

        target.Use();
    }
}
