using UnityEngine;
using DG.Tweening;

public class Collectables : MonoBehaviour
{
    //enuma eri�im sa�l�yorum
    public CollectablesEnum CollectablesEnum;  //enumun i�indeki objelere eri�ebilirim (coin , shield...)
    public int ToBeAddedHealth;
    public int ToBeAddedScore;
    public int ToBeAddedSpeed;
    public GameObject Player;

    private void Start()
    {
        if (CollectablesEnum == CollectablesEnum.Coin)
        {
            Player = GameObject.FindFirstObjectByType<PlayerController>().gameObject; //player objemize eri�tik
        }
    }
    private void Update()
    {
        if(CollectablesEnum == CollectablesEnum.Coin && Player.GetComponent<PlayerController>().isMagnetActive)
        {
            if(Vector3.Distance(Player.transform.position, this.transform.position) < 8) //Vector3.Distance, iki Vector3 (vekt�r) nesnesi aras�ndaki do�rusal
                                                                                         //mesafeyi (yani �klidyen uzakl���) hesaplamak i�in kullan�l�r.
            {
                transform.DOMove(Player.transform.position+new Vector3(0,1,0),0.35f); //bir objeyi, Player (oyuncu) nesnesinin pozisyonundan 1 birim yukar�ya
                                                                                      //(y yani yukar� ekseninde) do�ru hareket ettirir ve bunu 0.35 saniyede yapar.
            }
        }
    }
}
