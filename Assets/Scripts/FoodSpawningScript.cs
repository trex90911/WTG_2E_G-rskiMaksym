using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
public class FoodSpawningScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ApplePrefab;

    public GameObject SpawnedApple;

    private int appleCurrentX;

    public int AppleCurrentY;

    private Vector3 AppleSpawnPosition; 

    private int maxAreaX = 10;
    
    private int minAreaX = -10;

    private int maxAreaY = 5;

    private int minAreaY = -5;

    public int AppleCurrentX
    {
        get
        {
            return appleCurrentX;
        }
    }
    private void Start()
    {
        int AreaX = 0;
        int AreaY = 0;
        appleCurrentX = AreaX;
        AppleCurrentY = AreaY;
        Vector3 AppleSpawnPosition = new Vector3(AreaX, AreaY, 0);
        SpawnedApple = Instantiate(ApplePrefab, AppleSpawnPosition, Quaternion.identity);
    }

    private void SetApplePosition()
    {
        var AreaX = Random.Range(minAreaX, maxAreaX);
        var AreaY = Random.Range(minAreaY, maxAreaY);
        appleCurrentX = AreaX;
        AppleCurrentY = AreaY;
        Vector3 AppleSpawnPosition = new Vector3(AreaX, AreaY, 0);
    }

    public void SpawnApple()
    {
        SetApplePosition();
        SpawnedApple = Instantiate(ApplePrefab, AppleSpawnPosition, Quaternion.identity);
    }
}
