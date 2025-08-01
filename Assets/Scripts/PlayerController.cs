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
        isMiddle = true; // Ba�lang��ta karakter ortadad�r
        //transform.position=new Vector3 (0, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);//Karakteri s�rekli olarak ileri (Z ekseni) y�nde hareket ettirir

        // E�er A tu�una veya Sol Ok tu�una bas�l�rsa VE �u anda en solda de�ilse
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isLeft == false)
        {
            // E�er karakter ortadaysa, sola ge�
            if (isMiddle)
            {
                isLeft = true;       // Art�k karakter solda
                isMiddle = false;    // Ortada de�il
            }
            // E�er karakter sa�da ise, �nce orta konuma ge�
            else if (isRight)
            {
                isMiddle = true;     // Art�k karakter ortada
                isRight = false;     // Sa�da de�il
            }

            // X ekseninde sola do�ru (negatif y�n) shift kadar kayd�r
            transform.Translate(new Vector3(-shift, 0, 0));
        }
        // E�er D tu�una veya Sa� Ok tu�una bas�l�rsa VE �u anda en sa�da de�ilse
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isRight == false)
        {
            // E�er karakter ortadaysa, sa�a ge�
            if (isMiddle)
            {
                isRight = true;      // Art�k karakter sa�da
                isMiddle = false;    // Ortada de�il
            }
            // E�er karakter solda ise, �nce orta konuma ge�
            else if (isLeft)
            {
                isMiddle = true;     // Art�k karakter ortada
                isLeft = false;      // Solda de�il
            }

            // X ekseninde sa�a do�ru (pozitif y�n) shift kadar kayd�r
            transform.Translate(new Vector3(shift, 0, 0));
        } //isLeft, isMiddle, isRight: Karakterin �u an hangi �eritte oldu�unu kontrol eder.
    }
    //[SerializeField] public bool isLeft, isMiddle, isRight;===>bunlar� en ba�ta tan�mlad�m



    /*transform.Translate(Vector3.forward * speed * Time.deltaTime);

    if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -0.5f)
    {
        transform.Translate(new Vector3 (-shift, 0, 0));
    }
    else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 0.5f)
    {
        transform.Translate(shift,0,0);
    }*/

    //nesneyi hareket ettirmenin 2 yolu biri fizik vererek di�eri translate;

    // rb.MovePosition(transform.position+Vector3.forward*speed*Time.deltaTime);//nesnenin �u anki konumuna, ileri y�nde k���k bir hareket vekt�r� ekliyor ve
    //Rigidbody'nin MovePosition fonksiyonuyla onu fizik kurallar�na uygun bir �ekilde yeni konuma ta��yor.

    //transform.Translate(Vector3.forward*speed*Time.deltaTime);  //Time.deltaTime->FPS g�re sabit h�z sa�lar transform.Translate(...)->Nesneyi hareket ettirir
    //Vector3.forward->nesnenin z ekseni y�n�n� temsil eder (ileri y�n).

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
    /*private void FixedUpdate() //fizik hesaplamalar� i�in �zel olarak kullan�lan bir g�ncelleme metodudur.
                                //Her karede de�il, sabit zaman aral�klar�yla (�rne�in her 0.02 saniyede bir) �al���r.
                                //Bu y�zden Rigidbody ile yap�lan hareketler her zaman FixedUpdate i�inde yap�lmal�d�r.
    {
        rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
    } */
}
