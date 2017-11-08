using UnityEngine;
using UnityEngine.UI;

public class MissionItem : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    [SerializeField]
    private Text _price;

    [SerializeField]
    private Text _time;

    [SerializeField]
    private Button _button;

    private Mission _mission;
    private OrderTable _orderTable;

    public void Load(Mission mission, OrderTable orderTable)
    {
        _mission = mission;
        _orderTable = orderTable;

        _button.onClick.AddListener( OnClick );

        _text.text = _mission.GetName();

        _price.text = "$ " + _mission.GetPrice();
    }

    private void OnClick()
    {
        _button.interactable = false;
    }

    private void Update()
    {
        _time.text = _mission.GetTime().ToString();

        if (_orderTable != null)
        {
            var screenPos = Camera.main.WorldToScreenPoint(_orderTable.transform.localPosition);
            screenPos.y -= 25;
            this.transform.position = screenPos;

            _button.interactable = _orderTable.unit != null;
        }
    }

    public Mission GetMission()
    {
        return _mission;
    }
}
