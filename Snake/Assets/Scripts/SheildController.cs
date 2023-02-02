using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheildController : MonoBehaviour
{

    public BoxCollider2D gridArea;
    private float poweruptimer;
    private float poweruptimerMax;
    public SnakeController snakeController;
    public Snake2Controller snake2Controller;


    private void Start()
    {
        RandomizePosition();
    }

    private void Awake()
    {
        poweruptimerMax = 5.0f;
        poweruptimer = poweruptimerMax;
    }

    private void Update()
    {
        poweruptimer += Time.deltaTime;
        if (poweruptimer >= poweruptimerMax)
        {


            poweruptimer -= poweruptimerMax;

        }
    }

    private void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            RandomizePosition();
            SnakeController snakeController = collision.GetComponent<SnakeController>();
            snakeController.sheild = true;
        }

        if (collision.tag == ("Player2"))
        {
            RandomizePosition();
            Snake2Controller snakeController2 = collision.GetComponent<Snake2Controller>();
            snakeController2.sheild=true;
        }

        ResetPotion();


    }

    private void ResetPotion()
    {
        snakeController.sheild = false;
        snake2Controller.sheild = false;

    }
}
