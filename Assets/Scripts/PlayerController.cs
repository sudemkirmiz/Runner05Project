using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Elements")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator myAnim;
    [Header ("Settings")]
    [Tooltip("bu değişken oyuncunun hızını ifade eder")] //speed üzerine gelince yazacak ipucu
    [SerializeField] public float speed;
    [Tooltip("bu değişken sağa sola kayma birimini ifade eder")]
    [SerializeField] public float shift=2;
    [Tooltip("bool ile karakter kontrolünde sağa sola orta konumunu ayarlama")]
    [SerializeField] public bool isLeft, isMiddle, isRight;
    [HideInInspector] public string denemeforgizleme; //gizleme1
    [System.NonSerialized] public string denemeforgizleme2; //gizleme2
    int score = 0;

    //bool ile sürünmeden kurtulalım
    public bool isDead;

    void Start()
    {
        isMiddle = true; // Başlangıçta karakter ortadadır
        //transform.position=new Vector3 (0, 0, 5);
        myAnim.SetBool("run", true);
    }
    void Update()
    {
        // transform.Translate(Vector3.forward * speed * Time.deltaTime);//Karakteri sürekli olarak ileri (Z ekseni) yönde hareket ettirir

        MoveCharacter();

        karakterHareket();


        //1. YÖNTEM
        // Eğer A tuşuna veya Sol Ok tuşuna basılırsa VE şu anda en solda değilse
        /*if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isLeft == false)
        {
            // Eğer karakter ortadaysa, sola geç
            if (isMiddle)
            {
                isLeft = true;       // Artık karakter solda
                isMiddle = false;    // Ortada değil
            }
            // Eğer karakter sağda ise, önce orta konuma geç
            else if (isRight)
            {
                isMiddle = true;     // Artık karakter ortada
                isRight = false;     // Sağda değil
            }

            // X ekseninde sola doğru (negatif yön) shift kadar kaydır
            transform.Translate(new Vector3(-shift, 0, 0));
        }
        // Eğer D tuşuna veya Sağ Ok tuşuna basılırsa VE şu anda en sağda değilse
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isRight == false)
        {
            // Eğer karakter ortadaysa, sağa geç
            if (isMiddle)
            {
                isRight = true;      // Artık karakter sağda
                isMiddle = false;    // Ortada değil
            }
            // Eğer karakter solda ise, önce orta konuma geç
            else if (isLeft)
            {
                isMiddle = true;     // Artık karakter ortada
                isLeft = false;      // Solda değil
            }

            // X ekseninde sağa doğru (pozitif yön) shift kadar kaydır
            transform.Translate(new Vector3(shift, 0, 0));
        } //isLeft, isMiddle, isRight: Karakterin şu an hangi şeritte olduğunu kontrol eder.
    } */
        //[SerializeField] public bool isLeft, isMiddle, isRight;===>bunları en başta tanımladım



        /*transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -0.5f)
        {
            transform.Translate(new Vector3 (-shift, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 0.5f)
        {
            transform.Translate(shift,0,0);
        }*/

        //nesneyi hareket ettirmenin 2 yolu biri fizik vererek diğeri translate;

        // rb.MovePosition(transform.position+Vector3.forward*speed*Time.deltaTime);//nesnenin şu anki konumuna, ileri yönde küçük bir hareket vektörü ekliyor ve
        //Rigidbody'nin MovePosition fonksiyonuyla onu fizik kurallarına uygun bir şekilde yeni konuma taşıyor.

        //transform.Translate(Vector3.forward*speed*Time.deltaTime);  //Time.deltaTime->FPS göre sabit hız sağlar transform.Translate(...)->Nesneyi hareket ettirir
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
    /*private void FixedUpdate() //fizik hesaplamaları için özel olarak kullanılan bir güncelleme metodudur.
                                //Her karede değil, sabit zaman aralıklarıyla (örneğin her 0.02 saniyede bir) çalışır.
                                //Bu yüzden Rigidbody ile yapılan hareketler her zaman FixedUpdate içinde yapılmalıdır.
    {
        rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
    } */
    void karakterHareket()
    {
        // programa ürettirdigimiz metod
    }

    void MoveCharacter()
    {
        if(isDead) return; //eğer ölüm doğru ise alttaki hiçbir şeyi çalıştırma!!!

        #region karakter sinirlama
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // 1.yöntem
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -0.5f)
        {

            //transform.Translate(new Vector3(-shift, 0, 0)); //ışınlanarak gidiyor
            transform.DOMoveX(transform.position.x - shift, 0.5f).SetEase(Ease.Linear); //ışınlanmadan karakterin sağ sol doğal hareketi
        }
        else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 0.5f)
        {
            //transform.Translate(shift, 0, 0);
            transform.DOMoveX(transform.position.x + shift, 0.5f).SetEase(Ease.Linear);
        }
        #endregion
    }
    //oncollisionenter=>fiziksel çarpışmaları algılayan özel bir fonksiyondur.başka bir Collider ile çarpışma olduğunda otomatik olarak çağrılır.Scriptin
    //bağlı olduğu GameObject'te Collider bileşeni bulunmalı (örneğin: BoxCollider, SphereCollider vs.) Ayrıca Rigidbody bileşeni olmalı(dinamik fizik için).
    private void OnCollisionEnter(Collision other)//Bu fonksiyon, bir Rigidbody'ye sahip obje başka bir Collider'la çarpıştığında otomatik olarak çalışır.
    {                                             //other, çarpıştığın nesneyle ilgili tüm bilgileri içerir.
        //Debug.Log("çarpıştık");
        if (other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("çarpıştık" +other.gameObject.name);
            myAnim.SetBool("Death", true);
            isDead = true;
        }  
    }
    //coinin yok olmasının kodu
    private void OnTriggerEnter(Collider other) //isTrigger ile kontrol edilen yapının içine girdiğinde neler yapılacağı
    {
        if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject);//süre olarak Destroy(other.gameObject,0.2f)-> 2sn sonra kaybolmak demektir
            score += 10;
            Debug.Log("Puan: " + score);
        }

    }

}
