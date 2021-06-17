using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
    [SerializeField] int currentMoney = 1000;
    [SerializeField] int acceptableDebtBeforeLoss = 1000;
    [SerializeField] int income = 0;
    [SerializeField] int expense = 0;
    [SerializeField] int potenialIncome = 0;
    [SerializeField] int jobs = 0;
    [SerializeField] int housing = 0;
    [SerializeField] int people = 5;
    [SerializeField] int popGrowth = 1;
    private static CityManager _instance;
    public static CityManager Instance { get => _instance; set => _instance = value; }
    public int Income { get => income; set => income = value; }
    public int CurrentMoney { get => currentMoney; set => currentMoney = value; }
    public int Housing { get => housing; set => housing = value; }
    public int People { get => people; set => people = value; }
    public int Jobs { get => jobs; set => jobs = value; }
    public int PopGrowth { get => popGrowth; set => popGrowth = value; }
    public int PotenialIncome { get => potenialIncome; set => potenialIncome = value; }
    public int Expense { get => expense; set => expense = value; }
    public int AcceptableDebtBeforeLoss { get => acceptableDebtBeforeLoss; set => acceptableDebtBeforeLoss = value; }

    float tickTimer = 0;
    [SerializeField] float tickTime = 15;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    private void Update()
    {
        Tick();
    }
    void Tick()
    {
        tickTimer += 1 * Time.deltaTime;
        if (tickTimer > tickTime)
        {
            IncomeManager();
            managePop();
            tickTimer = 0;
        }
    }
    void managePop()
    {
        if (jobs > people && housing > people)
        {
            popGrowth += 1;
        }
        else if (people > jobs || people > housing)
        {
            popGrowth -= 1;
        }
        people += popGrowth;
    }
    void IncomeManager()
    {
        float a = people * 2;
        float b = housing + jobs;
        float c;
        if (a <= b) c = a / b;
        else c = b / a;

        if (c > 0) income = (Mathf.RoundToInt(c * potenialIncome));
        else income = 0;

        currentMoney += income - expense;
    }
}
