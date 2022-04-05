using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    static bool isActive;
    public GameObject Canvas;
    public GameObject PlayerUI;
    private void Start()
    {
        Time.timeScale = 1;
        isActive = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isActive)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Canvas.SetActive(false);
        Time.timeScale = 1;
        isActive = false;
        if (PlayerUI == null) return;
        PlayerUI.SetActive(true);
    }
    void Pause()
    {
        Canvas.SetActive(true);
        Time.timeScale = 0;
        isActive = true;
        if (PlayerUI == null) return;
        PlayerUI.SetActive(false);
    }
}
