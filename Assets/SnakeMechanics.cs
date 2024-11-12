using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMechanics : MonoBehaviour
{
    public FoodSpawningScript FoodScript;
    public SnakeMovement SnakeMovement;
    public int Score;
    void Start()

    {

    }

    void Update()
    {
        if (SnakeMovement.SnakeCurrentX == FoodScript.AppleCurrentX && SnakeMovement.SnakeCurrentY == FoodScript.AppleCurrentY)
        {
            Destroy(FoodScript.SpawnedApple);
            FoodScript.SpawnApple();
            Score++;
            SnakeMovement.AddSegments();
        }

    }
}
