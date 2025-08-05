using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] public GameObject gameStartMenu;
    [SerializeField] public GameObject gameRestartMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        playerController.isStart = true;//oyun ba�lad�
        playerController.myAnim.SetBool("run", true);
        gameStartMenu.SetActive(false);
    }
}
