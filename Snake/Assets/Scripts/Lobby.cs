using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    public Button buttonPlay;
    

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
        

    }

   
    private void PlayGame()
    {
        
       SceneManager.LoadScene(0);
    }
}
