using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator myAnim;
    [SerializeField] public float speed;
    void Start()
    {
        //transform.position=new Vector3 (0, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*speed);

       /* if (Input.GetKey(KeyCode.W)) 
        {
            myAnim.SetBool("run", true);
        
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            myAnim.SetBool ("run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.SetBool("JUMP", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space)) 
        { 
            myAnim.SetBool("JUMP",false);
        } */

    }
}
