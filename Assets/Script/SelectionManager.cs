using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] GameObject selectionMarker;
    List<GameObject> selected = new List<GameObject>();
    List<GameObject> selectedMarkers = new List<GameObject>();
    private static SelectionManager _instance;
    bool canSelect = true;

    public bool CansSelect { get => canSelect; set => canSelect = value; }
    public static SelectionManager Instance { get => _instance; set => _instance = value; }

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
        Select();
    }
    void Select()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, Mathf.Infinity);
        if (hitInfo.collider != null)
        {
            if (Input.GetMouseButton(0) && canSelect && !UIManager.Instance.MouseIsOverUI())
            {
                ListTools.DestoryListofGameObjects(selectedMarkers);
                selected.Clear();
                selected.Add(hitInfo.collider.gameObject);
                SpawnMarkers(hitInfo.collider.gameObject, 1);
            }
            if (Input.GetMouseButtonDown(1))
            {
                ListTools.DestoryListofGameObjects(selectedMarkers);
                selected.Clear();
            }
        }
    }
    void SpawnMarkers(GameObject gameObject, float markerHeight)
    {
        selectedMarkers.Add(Instantiate(selectionMarker, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + markerHeight, gameObject.transform.position.z), gameObject.transform.rotation, gameObject.transform));
    }
}
