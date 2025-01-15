using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public List<Transform> SnakeSegments = new();

    public DeathMenuScript DeathMenu;
    public WinMenuScript WinMenu;

    [SerializeField]
    private float MoveDelay = 0.3f;
    private float moveTimer = 0f;

    private Direction PlayerDirection = Direction.Right;
    private Vector2 input = Vector2.right,
        lastFrameInput = Vector2.right;

    [SerializeField]
    private TMP_Text ScoreText;
    [SerializeField]
    private int Score;

    private bool initialMoveDone = false;

    void Start()
    {
        SnakeSegments.Add(this.transform);
        GameObject initialSegment = Instantiate(SnakeBodyPrefab, this.transform.position - Vector3.right, Quaternion.identity);
        SnakeSegments.Add(initialSegment.transform);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.10f;
    }

    void MoveSnakeSegments()
    {
        for (int i = SnakeSegments.Count - 1; i > 0; i--)
        {
            SnakeSegments[i].position = SnakeSegments[i - 1].position;

            Vector3 direction = SnakeSegments[i - 1].position - SnakeSegments[i].position;

            if (direction == Vector3.up)
            {
                SnakeSegments[i].eulerAngles = new Vector3(0, 0, 0);
            }
            else if (direction == Vector3.down)
            {
                SnakeSegments[i].eulerAngles = new Vector3(0, 0, 180);
            }
            else if (direction == Vector3.left)
            {
                SnakeSegments[i].eulerAngles = new Vector3(0, 0, 90);
            }
            else if (direction == Vector3.right)
            {
                SnakeSegments[i].eulerAngles = new Vector3(0, 0, -90);
            }
        }
    }

    void MoveSnakeHead()
    {
        switch (PlayerDirection)
        {
            case Direction.Up:
                transform.position += Vector3.up;
                break;
            case Direction.Down:
                transform.position += Vector3.down;
                break;
            case Direction.Left:
                transform.position += Vector3.left;
                break;
            case Direction.Right:
                transform.position += Vector3.right;
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
            if (!initialMoveDone)
            {
                initialMoveDone = true;
            }
            else
            {
                MoveSnakeSegments();
            }
            lastFrameInput = input;
            MoveSnakeHead();
            moveTimer = 0f;
        }
    }

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        if (x != 0f && lastFrameInput.y != y)
        {
            input = new Vector2(x, 0f);
        }
        else if (y != 0f && lastFrameInput.x != x)
        {
            input = new Vector2(0f, y);
        }
        if (Score == 200)
        {
            WinMenu.Win();
        }    

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Score++;
            ScoreText.text = "Score: " + Score;
            AddSegments();
        }
        else if (other.tag == "Obstacle"|| other.tag == "Player")
        {
            DeathMenu.Die();
        }
    }

    public void AddSegments()
    {
        GameObject newSegment = Instantiate(SnakeBodyPrefab, SnakeSegments[SnakeSegments.Count - 1].position, Quaternion.identity);
        SnakeSegments.Add(newSegment.transform);
    }
}