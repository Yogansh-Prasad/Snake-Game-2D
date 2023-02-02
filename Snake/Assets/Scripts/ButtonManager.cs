using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Button replay;
    public Button menu;

    private void Start()
    {
        replay.onClick.AddListener(Replay);
        menu.onClick.AddListener(Menu);
    }

    private void Menu()
    {
        SceneManager.LoadScene(0);
    }

    private void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
