using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodSpawningScript : MonoBehaviour
{
    public SnakeScript SnakeScript;
    public GameObject ApplePrefab;
    public GameObject SpawnedApple;
    public int AppleCurrentX;
    public int AppleCurrentY;
    private Coroutine MaybeFix;
    private Vector3 AppleSpawnPosition;
    private bool IsApplePositionValid = false;
    private int ReSpawnApple;
    void Start()
    {
        StartCoroutine(MaybeFix());
        int AreaX = 0;
        int AreaY = 0;
        AppleCurrentX = AreaX;
        AppleCurrentY = AreaY;
        AppleSpawnPosition = new Vector3(AreaX, AreaY, 0);
        SpawnedApple = Instantiate(ApplePrefab, AppleSpawnPosition, Quaternion.identity);
    }
    public void SpawnApple()
    {


        IEnumerator MaybeFix()
        {
            while (IsApplePositionValid == false)
            {
                int AreaX = Random.Range(-10, 10);
                int AreaY = Random.Range(-5, 5);
                AppleCurrentX = AreaX;
                AppleCurrentY = AreaY;
                Vector3 AppleSpawnPosition = new Vector3(AreaX, AreaY, 0);
                CheckSegmentPosition();
                if (IsApplePositionValid == true)
                {
                    SpawnedApple = Instantiate(ApplePrefab, AppleSpawnPosition, Quaternion.identity);
                }
                yield return new WaitForSeconds(.1f);
            }
        }
    }
    public void CheckSegmentPosition()
    {
        IsApplePositionValid = true;
        foreach (Transform segment in SnakeScript.SnakeSegmentList) 
        {
            if (segment.position == AppleSpawnPosition)
            {
                IsApplePositionValid = false;
                break;
            }
        }
    }

}
