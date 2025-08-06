using UnityEngine;

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
}
