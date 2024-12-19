using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryScript : MonoBehaviour
{
    //Zmienne powinny być pisane camelCase
    public FoodSpawningScript FoodScript;
    public SnakeScript SnakeScript;
    public Text ScoreText; //Używaj TextMeshProUGUI, zwykły tekst jest obsolote i do tego słąby

    public int Score;

    void Start()
    {
        Score--; //Co to jest? nie powinno być czegoś takiego
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
