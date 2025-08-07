using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Inspector �zerinden atanabilen, farkl� yol prefab'lar�n� i�eren bir dizi
    [SerializeField] GameObject[] road;

    // Oyuncunun Transform bile�eni (pozisyon bilgisi i�in)
    [SerializeField] Transform Player;

    // Olu�turulan yol objelerinin hiyerar�ide toplanaca�� ebeveyn obje
    [SerializeField] Transform roadParent;

    [SerializeField] GameObject[] collactables; //dinamik olarak olu�turaca��m kodlar� tutan dizi

    // Yol par�alar�n�n uzunlu�u (Z ekseni boyunca)
    float roadLength = 20;

    // Oyun ba��nda sahneye eklenecek ilk yol par�as� say�s�
    int startRoadCount = 6;

    // Oyun ba�lad���nda bir defa �al���r
    private void Start()
    {
        // �lk yol par�as�n� sahneye yerle�tirir (genelde sabit bir yol par�as� olur)
        Instantiate(road[0], transform.position, Quaternion.identity, roadParent);

        // Belirtilen say�da yol par�as� olu�turur
        for (int i = 0; i < startRoadCount; i++)
        {
            GenerateRoad(); // Yeni yol par�as� olu�tur
        }
        SpamCollectable();
    }

    void SpamCollectable()
    {
        GameObject collectableObject = Instantiate(collactables[Random.Range(0, collactables.Length)], Player.position + new Vector3(0, 0.5f, 50f), Quaternion.identity);
        Collectables collectable = collectableObject.GetComponent<Collectables>();
        if (collectable.CollectablesEnum == CollectablesEnum.Coin)
        {
            collectable.Player = Player.gameObject;
        }
        Invoke("SpawmCollectable", Random.Range(10f, 20f));
    }
    void SpawnCollectable()
    {
        GameObject collectableObject = Instantiate(collactables[Random.Range(0, collactables.Length)], Player.position + new Vector3(0, 0.5f, 50f), Quaternion.identity);
        Collectables collectable = collectableObject.GetComponent<Collectables>();
        if (collectable.CollectablesEnum == CollectablesEnum.Coin)
        {
            collectable.Player = Player.gameObject;
        }
        Invoke("SpawnCollectable", Random.Range(10f, 20f));

        Invoke("SpawnCollectable", Random.Range(3f, 10f));
    }

    // Her karede bir kez �al���r
    private void Update()
    {
        // Oyuncu ileri gittik�e yeni yol olu�turmak i�in kontrol yap
        if (Player.position.z > roadLength / 2)
        {
            GenerateRoad(); // Yeni yol olu�tur
        }
    }

    // Yeni bir yol par�as� olu�turan fonksiyon
    void GenerateRoad()
    {
        // Rastgele bir yol prefab'�n� al, ileri konumda instantiate et
        Instantiate(
            road[Random.Range(0, road.Length)],                          // Rastgele yol prefab'� se�ilir
            transform.position + new Vector3(0, 0, roadLength),         // Z ekseni boyunca ileriye konumland�r�l�r
            Quaternion.identity,                                        // Varsay�lan rotasyon
            roadParent);                                                // Belirlenen ebeveyn alt�na eklenir

        // Sonraki yol par�as� i�in konum de�eri g�ncellenir
        roadLength += 20;
    }
}

