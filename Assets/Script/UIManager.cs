using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI income;
    [SerializeField] TextMeshProUGUI bankMoney;
    [SerializeField] TextMeshProUGUI people;
    [SerializeField] TextMeshProUGUI housing;
    [SerializeField] TextMeshProUGUI jobs;
    [SerializeField] TextMeshProUGUI popGrowth;
    [SerializeField] TextMeshProUGUI expense;
    public GameObject NoRoadUi;

    private static UIManager _instance;

    public static UIManager Instance { get { return _instance; } }

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
        SetMoneyPanel();
    }
    void SetMoneyPanel()
    {
        income.text = " Income : " + CityManager.Instance.Income;
        bankMoney.text = " Bank : " + CityManager.Instance.CurrentMoney;
        jobs.text = " Jobs : " + CityManager.Instance.Jobs;
        housing.text = " Housing : " + CityManager.Instance.Housing;
        people.text = " People : " + CityManager.Instance.People;
        popGrowth.text = " Pop Growth : " + CityManager.Instance.PopGrowth;
        expense.text = " Expense : " + -CityManager.Instance.Expense;
    }
    public bool MouseIsOverUI() => EventSystem.current.IsPointerOverGameObject();
    public void SetPlacingObjectTo(GameObject gameObject)
    {
        SelectionManager.Instance.CansSelect = false;
        Destroy(BuildingPlacementManager.Instance.ObjectIsPlacing);
        BuildingPlacementManager.Instance.ObjectIsPlacing = Instantiate(gameObject);
        MaterialTools.AssignMaterial(AssetManager.Instance.TileTextures[0], BuildingPlacementManager.Instance.ObjectIsPlacing);
    }
    public void PlaceFactory() => SetPlacingObjectTo(AssetManager.Instance.Factory);
    public void PlaceHouse() => SetPlacingObjectTo(AssetManager.Instance.House);
    public void PlaceRestaraunt() => SetPlacingObjectTo(AssetManager.Instance.Restaraunt);
    public void PlaceRoadStraight() => SetPlacingObjectTo(AssetManager.Instance.RoadStraight);
    public void PlaceRoadTurn() => SetPlacingObjectTo(AssetManager.Instance.RoadTurn);
    public void PlaceRoadCross() => SetPlacingObjectTo(AssetManager.Instance.RoadCross);
    public void PlaceRoadT() => SetPlacingObjectTo(AssetManager.Instance.RoadT);
    public void PlaceDestroy() => SetPlacingObjectTo(AssetManager.Instance.DestroyBuilding);
}
