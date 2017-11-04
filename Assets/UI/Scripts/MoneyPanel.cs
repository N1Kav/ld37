using UnityEngine;
using UnityEngine.UI;

public class MoneyPanel : MonoBehaviour
{
    [SerializeField]
    private Text _money;

    private void Start()
    {
        MoneyManager.Instance.onChangeMoney += UpdateMoney;
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        _money.text = MoneyManager.Instance.GetMoney().ToString();
    }
}