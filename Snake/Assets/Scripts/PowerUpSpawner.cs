using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    private int powerupicker;
    public GameObject SpeedPotion;
    public GameObject Sheild;
    public GameObject Score;
    private float spawntime;
    private float spawntimemax;


    private void Start()
    {
        spawntimemax = 9f;
        spawntime = 1f;
    }


    private void Update()
    {
       
        

        spawntime += Time.deltaTime;
        if (spawntime >= spawntimemax) 
        {
            spawntime = 1f;
            SelectPowerUp();
            
        }
    }


    public void SelectPowerUp() 
    {
        powerupicker = Random.Range(1, 4);
        SpawnPowerUp();

    }

    public void SpawnPowerUp() 
    {
        if (powerupicker == 1) 
        {
            Instantiate(SpeedPotion,new Vector3(0,0,0),Quaternion.identity);
        }
        if (powerupicker == 2)
        {
            Instantiate(Score, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (powerupicker == 3)
        {
            Instantiate(Sheild, new Vector3(0, 0, 0), Quaternion.identity);
        }
        spawntimemax=Random.Range(9, 16);
    }



}
