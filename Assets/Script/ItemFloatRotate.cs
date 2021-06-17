using UnityEngine;

public class ItemFloatRotate : MonoBehaviour
{
    public float BobRate = 1.0f;
    public float BobSize = 0.6f;
    private float BobTick = 0.0f;
    private float yOrigin;
    private void Start()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + BobSize, gameObject.transform.position.z);
        yOrigin = gameObject.transform.position.y;
    }
    private void Update()
    {
        gameObject.transform.Rotate(Vector3.up, 1);

        BobTick += BobRate * Time.deltaTime;
        float SinValue = Mathf.Sin(BobTick);

        float newYPosition = yOrigin + BobSize * SinValue;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, newYPosition, gameObject.transform.position.z);
    }
}