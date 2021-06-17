using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimiter : MonoBehaviour
{
    [SerializeField] int ZBounds = 0;
    [SerializeField] int XBounds = 0;

    private void Update()
    {
        if (gameObject.transform.position.z < -ZBounds)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0);
        }
        if (gameObject.transform.position.x < -ZBounds)
        {
            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.z > ZBounds)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, ZBounds);
        }
        if (gameObject.transform.position.x > XBounds)
        {
            gameObject.transform.position = new Vector3(XBounds, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}
