using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    public GameObject SnakeBodyPrefab;
    public List<Transform> SnakeSegmentList = new List<Transform>();
    public int SnakeCurrentX;
    public int SnakeCurrentY;
    private int PlayerDirection;
    private int FramesPassed;
    private int SnakeWantMoveUp;
    private int SnakeWantMoveDown;
    private int SnakeWantMoveLeft;
    private int SnakeWantMoveRight;
   
    void Start()
    {
        SnakeSegmentList.Add(this.transform);
        Time.fixedDeltaTime = 0.10f;
    }
    void MoveSnakeSegments()
    {
        for (int i = SnakeSegmentList.Count - 1; i > 0; i--)
        {
            SnakeSegmentList[i].position = SnakeSegmentList[i - 1].position;
        }

        SnakeSegmentList[0].position = new Vector3(SnakeCurrentX, SnakeCurrentY, 0);
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
    private void FixedUpdate()
    {
        FramesPassed++;
        if (FramesPassed == 3)
        {
            if (SnakeWantMoveUp == 1)
            {
                transform.eulerAngles = new Vector3(0, 0, -90);
                PlayerDirection = 1; //up
                SnakeWantMoveUp = 0;
            }
            if (SnakeWantMoveDown == 1)
            {
                transform.eulerAngles = new Vector3(0, 0, 90);
                PlayerDirection = 2; //down
                SnakeWantMoveDown = 0;
            }
            if (SnakeWantMoveLeft == 1)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                PlayerDirection = 3; //left
                SnakeWantMoveLeft = 0;
            }
            if (SnakeWantMoveRight == 1)
            {
                transform.eulerAngles = new Vector3(0, 0, 180);
                PlayerDirection = 4; //right
                SnakeWantMoveRight = 0;
            }

            MoveSnakeHead();
            MoveSnakeSegments();
            FramesPassed = 0;
        }
    }
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.W) && PlayerDirection != 2)
        {

            SnakeWantMoveUp = 1;
        }
        if (Input.GetKeyDown(KeyCode.S) && PlayerDirection != 1)
        {
            SnakeWantMoveDown = 1;
        }
        if (Input.GetKeyDown(KeyCode.A) && PlayerDirection != 4)
        {
            SnakeWantMoveLeft = 1;
        }
        if (Input.GetKeyDown(KeyCode.D) && PlayerDirection != 3)
        {
            SnakeWantMoveRight = 1;
        }

    }
    public void AddSegments()
    {
        GameObject newSegment = Instantiate(SnakeBodyPrefab, SnakeSegmentList[SnakeSegmentList.Count - 1].position, Quaternion.identity);

        SnakeSegmentList.Add(newSegment.transform);
    }
}
 //To be done list: death, (actual) score, sprites (better), snake body part movement, death when out of bounds, maybe snake anims, input queueing (double turn like in original), sliding instead of teleporting, music, menu, pause, original mechanics (if time)
 //bugs: apples spawn in snake