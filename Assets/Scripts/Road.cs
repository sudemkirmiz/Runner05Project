using UnityEngine;

public class Road : MonoBehaviour
{
    GameObject Player; //serialize kullanmay�z ��nk� yollar�m�z dinamik olarak olu�uyor kod kod dosyas�na eri�ece�iz
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");//player etiketlerine sahip olan koda eri�im sa�l�yoruz
    }

    // Update is called once per frame
    void Update()
    {    //oyuncunun pozisyonu ile yolun pozisyonu aras�ndaki fark 25'ten b�y�k oldu�unda 
        if((Player.transform.position.z-this.transform.position.z) > 25)
        {
            Destroy(this.gameObject);
        }
    }
}
