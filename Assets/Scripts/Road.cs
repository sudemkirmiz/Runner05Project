using UnityEngine;

public class Road : MonoBehaviour
{
    // Oyuncuya referans tutacak de�i�ken
    GameObject Player;

    // Ba�lang��ta bir kere �al���r
    void Start()
    {
        // Sahnedeki "Player" tag'ine sahip GameObject bulunur ve referansa atan�r
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Her karede bir kere �al���r
    void Update()
    {
        // Oyuncunun Z ekseni konumu ile bu yol par�as�n�n konumu aras�ndaki fark 25'ten b�y�kse
        if ((Player.transform.position.z - this.transform.position.z) > 25)
        {
            // Bu yol par�as� art�k arkada kald�, bu y�zden yok edilir
            Destroy(this.gameObject);
        }
    }
}

