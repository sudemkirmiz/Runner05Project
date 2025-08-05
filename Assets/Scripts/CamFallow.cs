using UnityEngine;
using DG.Tweening;

public class CamFallow : MonoBehaviour
{
    //burada oyuncunun pozisyon bilgisini alaca��z
    [SerializeField] Transform Player;
    float zoffset;
    void Start()
    {
        zoffset=transform.position.z-Player.position.z;
    }
    private void LateUpdate()
    {
        transform.position =new Vector3(transform.position.x,transform.position.y,Player.position.z+zoffset);  
        //direkt adam�n kendi pozisyonunu kameraya ba�lad�k
    }
    //update
    //fixed update hareket kodlar� burada olmas� gerekir
    //e�er kamera takibi varsa buda lateUpdate
}
