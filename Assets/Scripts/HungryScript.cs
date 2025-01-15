using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryScript : MonoBehaviour
{   

    public SnakeScript SnakeScript;

    private readonly int maxAreaX = 10;
    private readonly int minAreaX = -10;
    private readonly int maxAreaY = 5;
    private readonly int minAreaY = -5;


    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        bool validPosition = false;

        while (!validPosition)
        {
            int AreaX = Random.Range(minAreaX, maxAreaX);
            int AreaY = Random.Range(minAreaY, maxAreaY);
            Vector2 newPosition = new(AreaX, AreaY);

            Collider2D hit = Physics2D.OverlapCircle(newPosition, 0.5f);
            if (hit == null || hit.tag != "Player")
            {
                validPosition = true;
                this.transform.position = newPosition;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomizePosition();
        }
    }


}