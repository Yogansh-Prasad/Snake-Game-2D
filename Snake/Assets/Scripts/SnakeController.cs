using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPostion;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private List<Transform> segments;
    public Transform segmentPrefab;

    private void Start()
    {
        
        segments = new List<Transform>();
        segments.Add(this.transform);


    }

    private void ResetState()
    {
        throw new NotImplementedException();
    }

    private void Awake()
    {
        gridPostion = new Vector2Int();
        gridMoveTimerMax = 0.1f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1,0);
        
    }

    private void Update()
    {
        GetInput();
        GridMovement();       

    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && gridMoveDirection.y!=-1)
        {
            gridMoveDirection = Vector2Int.up;
        }

        else if (Input.GetKeyDown(KeyCode.S) && gridMoveDirection.y != 1)
        {
            gridMoveDirection = Vector2Int.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) && gridMoveDirection.x != -1)
        {
            gridMoveDirection = Vector2Int.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) && gridMoveDirection.x != 1)
        {
            gridMoveDirection = Vector2Int.left;
        }
    }

    private void GridMovement()
    {
        gridMoveTimer +=Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax) 
        { 
            gridMoveTimer -=gridMoveTimerMax ;
            gridPostion += gridMoveDirection;


            for (int i = segments.Count - 1; i > 0; i--) 
            {
                segments[i].position = segments[i - 1].position;
            }

            transform.position = new Vector3Int(gridPostion.x, gridPostion.y,0);

        }
    }


    public void Grow() 
    {
        Transform segment = Instantiate(this.segmentPrefab);

        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }

   

    


}
