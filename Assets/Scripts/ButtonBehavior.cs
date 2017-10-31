using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour {
    public Button start;
    public Button exit;

    public void Start()
    {
        start = start.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
    }

    public void Update()
    {
        
    }
    public void startPress()
    {

    }

    public void exitPress()
    {
        exit.enabled = true;
        start.enabled = false;
    }

    public void NoPress()
    {
        exit.enabled = true;
        start.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

