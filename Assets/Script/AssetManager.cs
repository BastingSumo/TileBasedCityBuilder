using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : MonoBehaviour
{
    [SerializeField] GameObject factory;
    [SerializeField] GameObject house;
    [SerializeField] GameObject restaraunt;
    [SerializeField] GameObject roadStraight;
    [SerializeField] GameObject roadTurn;
    [SerializeField] GameObject roadCross;
    [SerializeField] GameObject roadT;
    [SerializeField] GameObject destroyBuilding;
    [SerializeField] List<GameObject> tiles = new List<GameObject>();

    [SerializeField] List<Material> tileTextures = new List<Material>();

    public List<GameObject> Tiles { get => tiles; }
    private static AssetManager _instance;

    public static AssetManager Instance { get { return _instance; } }

    public GameObject Factory { get => factory; }
    public GameObject House { get => house; }
    public GameObject Restaraunt { get => restaraunt;  }
    public GameObject RoadStraight { get => roadStraight; }
    public GameObject RoadTurn { get => roadTurn;  }
    public GameObject RoadCross { get => roadCross;  }
    public GameObject DestroyBuilding { get => destroyBuilding;  }
    public List<Material> TileTextures { get => tileTextures; }
    public GameObject RoadT { get => roadT; set => roadT = value; }

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
}
