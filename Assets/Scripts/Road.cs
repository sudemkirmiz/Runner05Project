using UnityEngine;

public class Road : MonoBehaviour
{
    GameObject Player; //serialize kullanmayýz çünkü yollarýmýz dinamik olarak oluþuyor kod kod dosyasýna eriþeceðiz
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");//player etiketlerine sahip olan koda eriþim saðlýyoruz
    }

    // Update is called once per frame
    void Update()
    {    //oyuncunun pozisyonu ile yolun pozisyonu arasýndaki fark 25'ten büyük olduðunda 
        if((Player.transform.position.z-this.transform.position.z) > 25)
        {
            Destroy(this.gameObject);
        }
    }
}
