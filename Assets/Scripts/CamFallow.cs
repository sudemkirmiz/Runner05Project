using UnityEngine;
using DG.Tweening;

public class CamFallow : MonoBehaviour
{
    //burada oyuncunun pozisyon bilgisini alacaðýz
    [SerializeField] Transform Player;
    float zoffset;
    void Start()
    {
        zoffset=transform.position.z-Player.position.z;
    }
    private void LateUpdate()
    {
        transform.position =new Vector3(transform.position.x,transform.position.y,Player.position.z+zoffset);  
        //direkt adamýn kendi pozisyonunu kameraya baðladýk
    }
    //update
    //fixed update hareket kodlarý burada olmasý gerekir
    //eðer kamera takibi varsa buda lateUpdate
}
