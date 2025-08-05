using UnityEngine;

public class Road : MonoBehaviour
{
    // Oyuncuya referans tutacak deðiþken
    GameObject Player;

    // Baþlangýçta bir kere çalýþýr
    void Start()
    {
        // Sahnedeki "Player" tag'ine sahip GameObject bulunur ve referansa atanýr
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Her karede bir kere çalýþýr
    void Update()
    {
        // Oyuncunun Z ekseni konumu ile bu yol parçasýnýn konumu arasýndaki fark 25'ten büyükse
        if ((Player.transform.position.z - this.transform.position.z) > 25)
        {
            // Bu yol parçasý artýk arkada kaldý, bu yüzden yok edilir
            Destroy(this.gameObject);
        }
    }
}

