using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public delegate void ChangeMoneyDelegate();
    public ChangeMoneyDelegate onChangeMoney;

    [SerializeField]
    private int _money;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _money = 100;
        if (onChangeMoney != null)
            onChangeMoney();
    }

    public int GetMoney()
    {
        return _money;
    }

    public void SubtractMoney(int count)
    {
        _money -= count;
        if (onChangeMoney != null)
            onChangeMoney();
    }
}
