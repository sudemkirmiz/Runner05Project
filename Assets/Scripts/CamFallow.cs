using UnityEngine;

public class CamFallow : MonoBehaviour
{
    //burtada oyuncunun pozisyon bilgisini alaca��z
    [SerializeField] Transform Player;
    void Start()
    {
        
    }
    private void Update()
    {
        transform.position =new Vector3(transform.position.x,transform.position.y,Player.position.z);   
    }
}
