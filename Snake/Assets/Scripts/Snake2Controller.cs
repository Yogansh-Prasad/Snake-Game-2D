using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Snake2Controller : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPostion;
    private float gridMoveTimer;
    public float gridMoveTimerMax;
    private List<Transform> segments;
    public Transform segmentPrefab;
    public int initialSize = 4;
    public static int snakeLength;
    public int speed=1;
    public ScoreController scoreController;
    public static int score=10;
    public int dscore = 5;
    public  bool sheild=false;

    private void Start()
    {

        segments = new List<Transform>();
        segments.Add(this.transform);
        for (int i = 1; i < initialSize; i++)
        {
            segments.Add(Instantiate(segmentPrefab));
        }



    }

    

    private void Awake()
    {
        gridPostion = new Vector2Int(5,5);
        gridMoveTimerMax = 0.1f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);

    }



    private void Update()
    {

        GetInput();
        GridMovement();
        snakeLength = segments.Count;


    }

    public Vector2Int ValidGridPosition(Vector2Int gridPosition)
    {
        if (gridPostion.x > 24)
        {
            gridPostion.x = -23;
        }
        if (gridPostion.x < -24)
        {
            gridPostion.x = 23;
        }
        if (gridPostion.y > 11)
        {
            gridPostion.y = -11;
        }
        if (gridPostion.y < -12)
        {
            gridPostion.y = 10;
        }
        return gridPostion;
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && gridMoveDirection.y != -1)
        {
            gridMoveDirection = Vector2Int.up;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && gridMoveDirection.y != 1)
        {
            gridMoveDirection = Vector2Int.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && gridMoveDirection.x != -1)
        {
            gridMoveDirection = Vector2Int.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && gridMoveDirection.x != 1)
        {
            gridMoveDirection = Vector2Int.left;
        }
    }



    private void GridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;
            gridPostion += gridMoveDirection*speed;
            gridPostion = ValidGridPosition(gridPostion);


            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;
            }

            transform.position = new Vector3Int(gridPostion.x, gridPostion.y, 0);

        }
    }


    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);

        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);

        scoreController.IncreaseScoreP2(score);
    }

    public void Shrink()
    {

        GameObject lastsegment = segments[segments.Count - 1].gameObject;
        Destroy(lastsegment);
        segments.RemoveAt(segments.Count - 1);
        scoreController.DecreaseScoreP2(dscore);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SnakeBody")
        {
            SceneManager.LoadScene(1);
        }
        if (collision.tag == "Snake2Body")
        {
            SceneManager.LoadScene(2);
        }



    }





}

