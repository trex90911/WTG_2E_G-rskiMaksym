using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawningScript : MonoBehaviour
{
    public GameObject ApplePrefab;
    public GameObject SpawnedApple;
    public int AppleCurrentX;
    public int AppleCurrentY;
    void Start()
    {
        SpawnApple();
    }

    public void SpawnApple()
    {
        int AreaX = Random.Range(-10, 10);
        int AreaY = Random.Range(-5, 5);
        AppleCurrentX = AreaX;
        AppleCurrentY = AreaY;
        Vector3 AppleSpawnPosition = new Vector3(AreaX, AreaY, 0);
        SpawnedApple = Instantiate(ApplePrefab, AppleSpawnPosition, Quaternion.identity);
    }
}
