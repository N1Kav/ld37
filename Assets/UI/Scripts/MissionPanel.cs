using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPanel : MonoBehaviour
{
    [SerializeField]
    private HorizontalLayoutGroup _layoutGroup;

    [SerializeField]
    private MissionItem _prefab;

    private List<MissionItem> _items = new List<MissionItem>();

    private void Start()
    {
        MissionManager.Instance.onAddMission += CreateItem;
        MissionManager.Instance.onRemoveMission += RemoveItem;
    }

    private void CreateItem(Mission mission)
    {
        var item = Instantiate<MissionItem>(_prefab, _layoutGroup.transform);
        item.Load(mission);
        _items.Add(item);
    }

    private void RemoveItem(Mission mission)
    {
        foreach (var item in _items)
        {
            if (item.GetMission() == mission)
            {
                _items.Remove(item);
                Destroy(item.gameObject);
                break;
            }
        }
    }
}
