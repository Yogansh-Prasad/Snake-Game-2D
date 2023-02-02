using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassBurner : MonoBehaviour
{
    public BoxCollider2D gridArea;
    private float foodtimermax;
    private float foodtimer;

    private void Start()
    {
        RandomizePosition();
    }

    private void Awake()
    {
        foodtimermax = 5.0f;
        foodtimer = foodtimermax;
    }

    private void Update()
    {
        foodtimer += Time.deltaTime;
        if (foodtimer >= foodtimermax)
        {

            RandomizePosition();
            foodtimer -= foodtimermax;

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
        if (collision.tag == "Player" && SnakeController.snakeLength > 2)
        {
            RandomizePosition();
            SnakeController snakeController = collision.GetComponent<SnakeController>();
            snakeController.Shrink();
        }

        if (collision.tag == "Player2" && Snake2Controller.snakeLength > 2)
        {
            RandomizePosition();
            Snake2Controller snake2Controller = collision.GetComponent<Snake2Controller>();
            snake2Controller.Shrink();
        }






    }




}
