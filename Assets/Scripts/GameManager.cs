using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Inspector üzerinden atanabilen, farklý yol prefab'larýný içeren bir dizi
    [SerializeField] GameObject[] road;

    // Oyuncunun Transform bileþeni (pozisyon bilgisi için)
    [SerializeField] Transform Player;

    // Oluþturulan yol objelerinin hiyerarþide toplanacaðý ebeveyn obje
    [SerializeField] Transform roadParent;

    [SerializeField] GameObject[] collactables; //dinamik olarak oluþturacaðým kodlarý tutan dizi

    // Yol parçalarýnýn uzunluðu (Z ekseni boyunca)
    float roadLength = 20;

    // Oyun baþýnda sahneye eklenecek ilk yol parçasý sayýsý
    int startRoadCount = 6;

    // Oyun baþladýðýnda bir defa çalýþýr
    private void Start()
    {
        // Ýlk yol parçasýný sahneye yerleþtirir (genelde sabit bir yol parçasý olur)
        Instantiate(road[0], transform.position, Quaternion.identity, roadParent);

        // Belirtilen sayýda yol parçasý oluþturur
        for (int i = 0; i < startRoadCount; i++)
        {
            GenerateRoad(); // Yeni yol parçasý oluþtur
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

    // Her karede bir kez çalýþýr
    private void Update()
    {
        // Oyuncu ileri gittikçe yeni yol oluþturmak için kontrol yap
        if (Player.position.z > roadLength / 2)
        {
            GenerateRoad(); // Yeni yol oluþtur
        }
    }

    // Yeni bir yol parçasý oluþturan fonksiyon
    void GenerateRoad()
    {
        // Rastgele bir yol prefab'ýný al, ileri konumda instantiate et
        Instantiate(
            road[Random.Range(0, road.Length)],                          // Rastgele yol prefab'ý seçilir
            transform.position + new Vector3(0, 0, roadLength),         // Z ekseni boyunca ileriye konumlandýrýlýr
            Quaternion.identity,                                        // Varsayýlan rotasyon
            roadParent);                                                // Belirlenen ebeveyn altýna eklenir

        // Sonraki yol parçasý için konum deðeri güncellenir
        roadLength += 20;
    }
}

