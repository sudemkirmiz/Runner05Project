using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] public GameObject gameStartMenu;
    [SerializeField] public GameObject gameRestartMenu;
    [SerializeField] public TextMeshProUGUI score; //TMPro kullan�m� restartda g�r�nen
    [SerializeField] public TextMeshProUGUI mainScore; //her iki ekranda da g�r�nen
    void Start()
    {
        gameStartMenu.SetActive(true);//oyun ba�lad���nda startmenu paneli a��l�yor
        gameRestartMenu.SetActive(false); //oyun ba�lad���nda restartmenu panelini kapat�yor
    }
    void Update()
    {
        mainScore.text = "Score : " + playerController.score;

        if (playerController.isDead)
        {
            gameRestartMenu.SetActive(true);
            score.text = "Score: " + playerController.score;
        }
    }
    public void StartGame()
    {
        
        playerController.isStart = true;//oyun ba�lad�
        playerController.myAnim.SetBool("run", true);
        gameStartMenu.SetActive(false);
    }
    public void RestartGame()
    {
       // SceneManager.LoadScene(0); //�ok dinamik bir yap� de�il
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //daha dinamik bir yap�d�r
    }
}
