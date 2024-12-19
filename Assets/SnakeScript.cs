using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public enum Direction
{ 
    Up = 1, 
    Down, 
    Left, 
    Right 
}

public class SnakeScript : MonoBehaviour
{
    public GameObject SnakeBodyPrefab;
    public List<Transform> SnakeSegments = new List<Transform>();
    public int SnakeCurrentX;
    public int SnakeCurrentY;

    [SerializeField]
    private float MoveDelay = 0.3f;
    private float moveTimer = 0f;
    private Direction PlayerDirection = Direction.Right;
    private Vector2 input = Vector2.right, 
        lastFrameInput = Vector2.right;
   
    void Start()
    {
        SnakeSegments.Add(this.transform);
        Time.fixedDeltaTime = 0.10f; 
    }
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
        switch (PlayerDirection) //możesz użyć switch case oraz enuma zamiast kilku ifów
        {
            case Direction.Up:
                transform.position += Vector3.up;
                SnakeCurrentY++;
                break;
            case Direction.Down:
                transform.position += Vector3.down;
                SnakeCurrentY--;
                break;
            case Direction.Left:
                transform.position += Vector3.left;
                SnakeCurrentX--;
            break;
                case Direction.Right:
                transform.position += Vector3.right;
                SnakeCurrentX++;
                break;
        }
    }
    private void FixedUpdate()
    {
        moveTimer += Time.fixedDeltaTime;

        if (moveTimer >= MoveDelay)
        {
            if (input.y > 0f && lastFrameInput.y == 0f)
            {
                PlayerDirection = Direction.Up;
                transform.eulerAngles = new Vector3(0f, 0f, -90f);
            }
            else if (input.y < 0f && lastFrameInput.y == 0f)
            {
                PlayerDirection = Direction.Down;
                transform.eulerAngles = new Vector3(0f, 0f, 90f);
            }
            else if (input.x < 0f && lastFrameInput.x == 0f)
            {
                PlayerDirection = Direction.Left;
                transform.eulerAngles = Vector3.zero;
            }
            else if (input.x > 0f && lastFrameInput.x == 0f)
            {
                PlayerDirection = Direction.Right;
                transform.eulerAngles = new Vector3(0f, 0f, 180f);
            }

            lastFrameInput = input;

            MoveSnakeHead();
            MoveSnakeSegments();
            moveTimer = 0f;
        }
    }
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        if (x != 0f && lastFrameInput.y != y )
        {
            input = new Vector2(x, 0f);
        }
        else if (y != 0f && lastFrameInput.x != x)
        {
            input = new Vector2(0f, y);
        }

    }
    public void AddSegments()
    {
        GameObject newSegment = Instantiate(SnakeBodyPrefab, SnakeSegments[SnakeSegments.Count - 1].position, Quaternion.identity);

        SnakeSegments.Add(newSegment.transform);
    }
}
   