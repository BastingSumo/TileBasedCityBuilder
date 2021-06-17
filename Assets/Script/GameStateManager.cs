using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    private void Start()
    {
        MenuPanel.SetActive(false);
    }
    private void Update()
    {
        OpenMenu();
        GameSpeed();
    }
    void OpenMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenClose(MenuPanel);
        }
    }
    void GameSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Time.timeScale = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2)) Time.timeScale = 2;
        if (Input.GetKeyDown(KeyCode.Alpha3)) Time.timeScale = 3;
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    void OpenClose(GameObject obj)
    {
        if (obj.activeSelf == false) obj.SetActive(true);
        else obj.SetActive(false);
    }
}
