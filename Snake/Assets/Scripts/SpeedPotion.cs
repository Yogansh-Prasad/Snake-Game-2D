using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    public BoxCollider2D gridArea;


    private void Start()
    {
        RandomizePosition();
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
            snakeController.speed=2;
        }

        if (collision.tag == ("Player2"))
        {
            RandomizePosition();
            Snake2Controller snakeController2 = collision.GetComponent<Snake2Controller>();
            snakeController2.speed = 2;
        }


    }
}