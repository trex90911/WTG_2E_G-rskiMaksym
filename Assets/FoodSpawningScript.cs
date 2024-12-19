using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nazwa klasy niepotrzebnie ma końcówkę "Script" -> wiadomo że to skrypt
public class FoodSpawningScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ApplePrefab; // Jeśli żadna inna klasa nie korzysta z zmiennej to zmienna powinna być prywatna, z atrybutem [SerializeField]

    public GameObject SpawnedApple;

    private int appleCurrentX; //zmienna dynamiczna ustawiana przez skrypt, nie powinna być dostępna w inspektorze ani publiczna

    public int AppleCurrentY;

    public int AppleCurrentX => appleCurrentX; //to jest tak zwany "getter", profesjonalnie to się nazywa C# property. Coś pomiędzy zmienną a metodą.

    /* Alternatywny zapis gettera, robi to samo co linika wyżej
    public int AppleCurrentX
    {
        get
        {
            return appleCurrentX;
        }
    }*/

    private void Start() // Większość conding conventions zakłada pisanie modyfikatorów dostępności zawsze
    {
        int AreaX = 0;
        int AreaY = 0;
        appleCurrentX = AreaX;
        AppleCurrentY = AreaY;
        Vector3 AppleSpawnPosition = new Vector3(AreaX, AreaY, 0);
        SpawnedApple = Instantiate(ApplePrefab, AppleSpawnPosition, Quaternion.identity);
    }

    public void SpawnApple()
    {
        var AreaX = Random.Range(-10, 10); //W mojej opinii lepiej użyć var zamiast dokładnego typu zmiennej, tutaj też range spawnowania powinien być jako zmienna a nie magic number
        int AreaY = Random.Range(-5, 5);
        appleCurrentX = AreaX;
        AppleCurrentY = AreaY;
        Vector3 AppleSpawnPosition = new Vector3(AreaX, AreaY, 0);
        SpawnedApple = Instantiate(ApplePrefab, AppleSpawnPosition, Quaternion.identity);
    }
}
