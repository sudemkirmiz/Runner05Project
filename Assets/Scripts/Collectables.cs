using UnityEngine;
using DG.Tweening;

public class Collectables : MonoBehaviour
{
    //enuma eriþim saðlýyorum
    public CollectablesEnum CollectablesEnum;  //enumun içindeki objelere eriþebilirim (coin , shield...)
    public int ToBeAddedHealth;
    public int ToBeAddedScore;
    public int ToBeAddedSpeed;
    public GameObject Player;

    private void Start()
    {
        if (CollectablesEnum == CollectablesEnum.Coin)
        {
            Player = GameObject.FindFirstObjectByType<PlayerController>().gameObject; //player objemize eriþtik
        }
    }
    private void Update()
    {
        if(CollectablesEnum == CollectablesEnum.Coin && Player.GetComponent<PlayerController>().isMagnetActive)
        {
            if(Vector3.Distance(Player.transform.position, this.transform.position) < 8) //Vector3.Distance, iki Vector3 (vektör) nesnesi arasýndaki doðrusal
                                                                                         //mesafeyi (yani öklidyen uzaklýðý) hesaplamak için kullanýlýr.
            {
                transform.DOMove(Player.transform.position+new Vector3(0,1,0),0.35f); //bir objeyi, Player (oyuncu) nesnesinin pozisyonundan 1 birim yukarýya
                                                                                      //(y yani yukarý ekseninde) doðru hareket ettirir ve bunu 0.35 saniyede yapar.
            }
        }
    }
}
