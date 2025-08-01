using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator myAnim;
    [SerializeField] public float speed;
    [SerializeField] public float shift=2;
    [SerializeField] public bool isLeft, isMiddle, isRight;

    void Start()
    {
        isMiddle = true; // Baþlangýçta karakter ortadadýr
        //transform.position=new Vector3 (0, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);//Karakteri sürekli olarak ileri (Z ekseni) yönde hareket ettirir

        // Eðer A tuþuna veya Sol Ok tuþuna basýlýrsa VE þu anda en solda deðilse
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isLeft == false)
        {
            // Eðer karakter ortadaysa, sola geç
            if (isMiddle)
            {
                isLeft = true;       // Artýk karakter solda
                isMiddle = false;    // Ortada deðil
            }
            // Eðer karakter saðda ise, önce orta konuma geç
            else if (isRight)
            {
                isMiddle = true;     // Artýk karakter ortada
                isRight = false;     // Saðda deðil
            }

            // X ekseninde sola doðru (negatif yön) shift kadar kaydýr
            transform.Translate(new Vector3(-shift, 0, 0));
        }
        // Eðer D tuþuna veya Sað Ok tuþuna basýlýrsa VE þu anda en saðda deðilse
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isRight == false)
        {
            // Eðer karakter ortadaysa, saða geç
            if (isMiddle)
            {
                isRight = true;      // Artýk karakter saðda
                isMiddle = false;    // Ortada deðil
            }
            // Eðer karakter solda ise, önce orta konuma geç
            else if (isLeft)
            {
                isMiddle = true;     // Artýk karakter ortada
                isLeft = false;      // Solda deðil
            }

            // X ekseninde saða doðru (pozitif yön) shift kadar kaydýr
            transform.Translate(new Vector3(shift, 0, 0));
        } //isLeft, isMiddle, isRight: Karakterin þu an hangi þeritte olduðunu kontrol eder.
    }
    //[SerializeField] public bool isLeft, isMiddle, isRight;===>bunlarý en baþta tanýmladým



    /*transform.Translate(Vector3.forward * speed * Time.deltaTime);

    if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -0.5f)
    {
        transform.Translate(new Vector3 (-shift, 0, 0));
    }
    else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 0.5f)
    {
        transform.Translate(shift,0,0);
    }*/

    //nesneyi hareket ettirmenin 2 yolu biri fizik vererek diðeri translate;

    // rb.MovePosition(transform.position+Vector3.forward*speed*Time.deltaTime);//nesnenin þu anki konumuna, ileri yönde küçük bir hareket vektörü ekliyor ve
    //Rigidbody'nin MovePosition fonksiyonuyla onu fizik kurallarýna uygun bir þekilde yeni konuma taþýyor.

    //transform.Translate(Vector3.forward*speed*Time.deltaTime);  //Time.deltaTime->FPS göre sabit hýz saðlar transform.Translate(...)->Nesneyi hareket ettirir
    //Vector3.forward->nesnenin z ekseni yönünü temsil eder (ileri yön).

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
    /*private void FixedUpdate() //fizik hesaplamalarý için özel olarak kullanýlan bir güncelleme metodudur.
                                //Her karede deðil, sabit zaman aralýklarýyla (örneðin her 0.02 saniyede bir) çalýþýr.
                                //Bu yüzden Rigidbody ile yapýlan hareketler her zaman FixedUpdate içinde yapýlmalýdýr.
    {
        rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
    } */
}
