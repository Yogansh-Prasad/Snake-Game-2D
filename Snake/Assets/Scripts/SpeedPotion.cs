using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
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
            snakeController.gridMoveTimerMax=0.05f;
        }

        if (collision.tag == ("Player2"))
        {
            RandomizePosition();
            Snake2Controller snakeController2 = collision.GetComponent<Snake2Controller>();
            snakeController2.gridMoveTimerMax = 0.05f;
        }

        Invoke("ResetPotion", 5f);


    }

    private void ResetPotion()
    {
        snakeController.gridMoveTimerMax = 0.1f;
        snake2Controller.gridMoveTimerMax = 0.1f;
    }
}
