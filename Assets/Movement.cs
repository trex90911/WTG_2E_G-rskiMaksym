using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private int PlayerDirection;
    private int FramesPassed;
    void Start()
    {

    }

    void Update()
    {
        FramesPassed++;
        if (FramesPassed == 70)
        {
            if (PlayerDirection == 1)
            {
                transform.position += new Vector3(0, 1, 0);
            }
            if (PlayerDirection == 2)
            {
                transform.position += new Vector3(0, -1, 0);
            }
            if (PlayerDirection == 3)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            if (PlayerDirection == 4)
            {
                transform.position += new Vector3(1, 0, 0);
            }
            FramesPassed = 0;
        }    

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            PlayerDirection = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            PlayerDirection = 2;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            PlayerDirection = 3;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            PlayerDirection = 4;
        }

    }
}
   