using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryScript : MonoBehaviour
{
    public FoodSpawningScript FoodScript;
    public SnakeScript SnakeScript;
    public Text ScoreText;
    public int Score;
    void Start()

    {
        Score--;
    }

    void Update()
    {
        if (SnakeScript.SnakeCurrentX == FoodScript.AppleCurrentX && SnakeScript.SnakeCurrentY == FoodScript.AppleCurrentY)
        {
            Destroy(FoodScript.SpawnedApple);
            FoodScript.SpawnApple();
            Score++;
            ScoreText.text = "Score:" + Score;
            SnakeScript.AddSegments();
        }

    }
}
