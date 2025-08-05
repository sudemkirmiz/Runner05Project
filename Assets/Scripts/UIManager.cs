using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] public GameObject gameStartMenu;
    [SerializeField] public GameObject gameRestartMenu;
    [SerializeField] public TextMeshProUGUI score; //TMPro kullanýmý restartda görünen
    [SerializeField] public TextMeshProUGUI mainScore; //her iki ekranda da görünen
    void Start()
    {
        gameStartMenu.SetActive(true);//oyun baþladýðýnda startmenu paneli açýlýyor
        gameRestartMenu.SetActive(false); //oyun baþladýðýnda restartmenu panelini kapatýyor
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
        
        playerController.isStart = true;//oyun baþladý
        playerController.myAnim.SetBool("run", true);
        gameStartMenu.SetActive(false);
    }
    public void RestartGame()
    {
       // SceneManager.LoadScene(0); //çok dinamik bir yapý deðil
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //daha dinamik bir yapýdýr
    }
}
