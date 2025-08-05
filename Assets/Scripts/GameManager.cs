using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] road; //road adýnda içinde gameobject barýndýran bir dizi tanýmladým
    [SerializeField] Transform Player; //oyuncunun konumuna ihtiyacým var çünkü buna göre yollarý instantiate edeceðiz
    [SerializeField] Transform roadParent; //dinamik olarak yollarý üzerinde oluþturacaðýmýz obje

    float roadLength = 20;
    int startRoadCount = 6;
    // instantiate(nesne prefab,nesne pozisyon,nesne rotasyon); 13 farklý kullanýmý vardýr.Nesnenin klonunu oluþturmaya yarýyor.Bir prefab'dan yeni nesne yaratýr.
    private void Start()
    {
        //bu komut temelde klon oluþturmaya yarýyor
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
