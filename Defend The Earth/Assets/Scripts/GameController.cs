using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] Text TimerUI;
    [SerializeField] int Time;
    public static bool isGameWin;
    void Start()
    {
        StartCoroutine(UpdateUI());
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().time = 1.5f;
    }
    void Update()
    {
        if (Time <= 0)
        {
            Debug.Log("Game Win");
            Destroy(GameObject.FindGameObjectWithTag("Spawner"));
            TimerUI.text = "Timer: "+ 0;
            isGameWin = true;
            StartCoroutine(LoadEndScene());
        }
        if (GameObject.FindGameObjectWithTag("Spawner") == null) return;
        if (Time <= 150)
        {
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().time = 1f;
        }
        if (Time <= 120)
        {
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().time = 0.5f;
        }
        if (Time <= 60)
        {
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawner>().time = 0.4f;
        }
    }
    void RepeatUpdateUI()
    {
        StartCoroutine(UpdateUI());
    }
    IEnumerator UpdateUI()
    {
        Time--;
        if (Time / 60 == 0)
        {
            TimerUI.text = "Timer: " + Time % 60;
        }
        if ((Time % 60) < 10)
        {
            TimerUI.text = "Timer: " + Time / 60 + ":" + "0" + Time % 60;
        }
        else
        {
            TimerUI.text = "Timer: " + Time / 60 + ":" + Time % 60;
        }
        yield return new WaitForSeconds(1);
        RepeatUpdateUI();
    }
    public static void PlayerDead()
    {
        isGameWin = false;
        SceneManager.LoadScene("GameOver");
    }
    IEnumerator LoadEndScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameWin");
    }
}
