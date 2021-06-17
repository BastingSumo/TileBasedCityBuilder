using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    //GameManager gameManager;
    public GameObject CameraRig;
    public GameObject ActualCamera;
    public Camera CameraScript;
    float currentPanSpeed = 20;
    [SerializeField] float PanSpeed = 20;
    [SerializeField] float shiftPanSpeed = 20;
    [SerializeField] float PanLimit = 5000;
    [SerializeField] float RotateSpeed = 5000;
    [SerializeField] float RotateMax = 50;
    [SerializeField] float RotateMin = 0;

    [SerializeField] float ScrollMin = 25;
    [SerializeField] float ScrollMax = 200;
    [SerializeField] float ScrollSpeed = 25;

    [SerializeField] float distance = 0;
    [SerializeField] float damp;
    [SerializeField] float timer;
    [SerializeField] float MouseWheel;

    bool isFollowing = false;


    public enum RotateTypes {ForcedRotate, FreeRotate }
    public RotateTypes currentRotateType;

    private static RTSCamera _instance;

    public static RTSCamera Instance { get { return _instance; } }
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
        CenterCameraOnCameraRig();
        WASD();
        Zoom();
        RotateCamera();
        ShiftSpeedBoost();
        PanLimiter();
    }
    void PanLimiter()
    {
        if (gameObject.transform.position.x > PanLimit) gameObject.transform.position = new Vector3(PanLimit, gameObject.transform.position.y, gameObject.transform.position.z);
        if (gameObject.transform.position.x < -PanLimit) gameObject.transform.position = new Vector3(-PanLimit, gameObject.transform.position.y, gameObject.transform.position.z);
        if (gameObject.transform.position.z > PanLimit) gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, PanLimit);
        if (gameObject.transform.position.z < -PanLimit) gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -PanLimit);
    }
    void CenterCameraOnCameraRig()
    {
        ActualCamera.transform.LookAt(CameraRig.transform.position);
    }
    void WASD()
    {
        gameObject.transform.position += new Vector3(gameObject.transform.forward.x, 0, gameObject.transform.forward.z) * Input.GetAxis("W/S") * currentPanSpeed * Time.deltaTime / Time.timeScale;
        gameObject.transform.position += gameObject.transform.right * Input.GetAxis("A/D") * currentPanSpeed * Time.deltaTime / Time.timeScale;
    }
    void Zoom()
    {
        distance = Vector3.Distance(gameObject.transform.position, ActualCamera.transform.position);
        MouseWheel = Input.GetAxis("MouseWheel");
        if (MouseWheel != 0)
        {
            if (timer < 2) timer += .2f;
            damp += MouseWheel * ScrollSpeed;
        }
        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
            damp -= 1 * Time.deltaTime;
        }
        if (timer <= 0 || damp < 0 && MouseWheel > 0 || damp > 0 && MouseWheel < 0)
        {
            damp = 0;
            timer = 0;
        }
        if (distance > ScrollMin && distance < ScrollMax) ActualCamera.transform.position += ActualCamera.transform.forward * damp * Time.deltaTime / Time.timeScale;
        else if (distance < ScrollMin && damp <= 0) ActualCamera.transform.position += ActualCamera.transform.forward * damp * Time.deltaTime / Time.timeScale;
        else if (distance > ScrollMax && damp >= 0) ActualCamera.transform.position += ActualCamera.transform.forward * damp * Time.deltaTime / Time.timeScale;
    }
    void ShiftSpeedBoost()
    {
        if (Input.GetAxis("LeftShift") > 0) currentPanSpeed = shiftPanSpeed;
        else currentPanSpeed = PanSpeed;
    }
    void RotateCamera()
    {
        switch (currentRotateType)
        {
            case RotateTypes.ForcedRotate:
                ForcedRotate();
                break;
            case RotateTypes.FreeRotate:
                FreeRotate();
                break;
            default:
                break;
        }
    }
    void FreeRotate()
    {
        Vector3 CameraRotation = gameObject.transform.rotation.eulerAngles;

        CameraRotation.y += Input.GetAxis("Q/E") * RotateSpeed * Time.deltaTime * 10;
        if (Input.GetAxis("Fire3") > 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            CameraRotation.y += Input.GetAxis("Mouse X") / RotateSpeed;
            CameraRotation.x -= Input.GetAxis("Mouse Y") / RotateSpeed;
            if (CameraRotation.x < RotateMin) CameraRotation.x = RotateMin;
            if (CameraRotation.x > RotateMax) CameraRotation.x = RotateMax;
        }
        else Cursor.lockState = CursorLockMode.None;

        gameObject.transform.rotation = Quaternion.Euler(CameraRotation);
    }
    void ForcedRotate()
    {
        Vector3 CameraRotation = gameObject.transform.rotation.eulerAngles;

        CameraRotation.y += Input.GetAxis("Q/E") * RotateSpeed * Time.deltaTime * 10;
        if (Input.GetAxis("Fire3") != 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            CameraRotation.y += Input.GetAxis("Mouse X") * RotateSpeed * Time.deltaTime;

        }
        else Cursor.lockState = CursorLockMode.None;

        CameraRotation.x = Mathf.Abs(distance - ScrollMin);
        if (CameraRotation.x > 30) CameraRotation.x = 30;
        gameObject.transform.rotation = Quaternion.Euler(CameraRotation);
    }
}