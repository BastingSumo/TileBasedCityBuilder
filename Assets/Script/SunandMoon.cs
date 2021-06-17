using UnityEngine;

public class SunandMoon : MonoBehaviour
{
    float ActualSpeed = 1;
    public float DaySpeed = 1;
    public float NightMultiplyer = 2;
    Light Sun;
    bool HasAddedDay = false;

    [SerializeField] float DayIntensity = 1.5f;
    [SerializeField] float SunSetRiseIntensity = 4f;

    [SerializeField] Color SunSetColor;
    [SerializeField] Color SunDayColor;

    private void Start()
    {
        Sun = gameObject.GetComponent<Light>();
    }
    private void Update()
    {
        ChangeColourandIntensity();
        DayCounter();
    }
    void DayCounter()
    {
        if (gameObject.transform.position.y > 0)
        {
            ActualSpeed = DaySpeed;
            Sun.enabled = true;
            if (HasAddedDay == false)
            {
                HasAddedDay = true;
            }
        }
        else if (gameObject.transform.position.y < 0)
        {
            ActualSpeed = DaySpeed * NightMultiplyer;
            Sun.enabled = false;
            HasAddedDay = false;
        }
    }
    void ChangeColourandIntensity()
    {
        Sun.color = Color.Lerp(SunSetColor, SunDayColor, gameObject.transform.position.y);
        Sun.intensity = Mathf.Lerp(SunSetRiseIntensity, DayIntensity, gameObject.transform.position.y);
    }
    private void FixedUpdate()
    {
        gameObject.transform.LookAt(Vector3.zero);
        gameObject.transform.RotateAround(Vector3.zero, Vector3.right, ActualSpeed);
    }
}