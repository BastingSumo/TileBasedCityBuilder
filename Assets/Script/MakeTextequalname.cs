using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if (UNITY_EDITOR)
[ExecuteInEditMode]
public class MakeTextequalname : MonoBehaviour
{
    void Update()
    {
        ass();
    }
    void ass()
    {
        gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = gameObject.name;
        DestroyImmediate(this);
    }
}
#endif
