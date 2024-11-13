using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public GameObject SnakeBodyPrefab;
    public List<Transform> SnakeSegments = new List<Transform>();
    private int PlayerDirection;
    private int FramesPassed;
    public int SnakeCurrentX;
    public int SnakeCurrentY;
    void Start() => SnakeSegments.Add(this.transform);
    void MoveSnakeSegments()
    {
        for (int i = SnakeSegments.Count - 1; i > 0; i--)
        {
            SnakeSegments[i].position = SnakeSegments[i - 1].position;
        }

        SnakeSegments[0].position = new Vector3(SnakeCurrentX, SnakeCurrentY, 0);
    }
    void MoveSnakeHead()
    {
        if (PlayerDirection == 1)//up
        {
            transform.position += new Vector3(0, 1, 0);
            SnakeCurrentY++;
        }
        if (PlayerDirection == 2)//down
        {
            transform.position += new Vector3(0, -1, 0);
            SnakeCurrentY--;
        }
        if (PlayerDirection == 3)//left
        {
            transform.position += new Vector3(-1, 0, 0);
            SnakeCurrentX--;
        }
        if (PlayerDirection == 4)//right
        {
            transform.position += new Vector3(1, 0, 0);
            SnakeCurrentX++;
        }
    }
    void Update()
    {
        FramesPassed++;
        if (FramesPassed == 50)
        {
           MoveSnakeHead();
           MoveSnakeSegments();
            FramesPassed = 0;
        }    

        if (Input.GetKeyDown(KeyCode.W) && PlayerDirection != 2)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            PlayerDirection = 1; //up
        }
        if (Input.GetKeyDown(KeyCode.S) && PlayerDirection != 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            PlayerDirection = 2; //down
        }
        if (Input.GetKeyDown(KeyCode.A) && PlayerDirection != 4)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            PlayerDirection = 3; //left
        }
        if (Input.GetKeyDown(KeyCode.D) && PlayerDirection != 3)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            PlayerDirection = 4; //right
        }

    }
    public void AddSegments()
    {
        GameObject newSegment = Instantiate(SnakeBodyPrefab, SnakeSegments[SnakeSegments.Count - 1].position, Quaternion.identity);

        SnakeSegments.Add(newSegment.transform);
    }
}
   