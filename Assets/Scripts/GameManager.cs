using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] road; //road ad�nda i�inde gameobject bar�nd�ran bir dizi tan�mlad�m
    [SerializeField] Transform Player; //oyuncunun konumuna ihtiyac�m var ��nk� buna g�re yollar� instantiate edece�iz
    [SerializeField] Transform roadParent; //dinamik olarak yollar� �zerinde olu�turaca��m�z obje

    float roadLength = 20;
    int startRoadCount = 6;
    // instantiate(nesne prefab,nesne pozisyon,nesne rotasyon); 13 farkl� kullan�m� vard�r.Nesnenin klonunu olu�turmaya yar�yor.Bir prefab'dan yeni nesne yarat�r.
    private void Start()
    {
        //bu komut temelde klon olu�turmaya yar�yor
        Instantiate(road[0], transform.position, Quaternion.identity, roadParent);
        for (int i = 0; i < startRoadCount; i++)
        {
            GenerateRoad();
        }
    }
    private void Update()
    {
        if(Player.position.z > roadLength/2)
        {
            GenerateRoad();
        } 
    }
    void GenerateRoad()
    {
        Instantiate(road[Random.Range(0, road.Length)], transform.position + new Vector3(0, 0, roadLength), Quaternion.identity, roadParent);
        roadLength += 20;
    }

}
