using UnityEngine;

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
}
