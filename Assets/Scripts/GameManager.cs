using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI MyScoreText;

    
    public int health = 3;
    public Image healthUI;
    [SerializeField] private List<Sprite> healthSprites = new List<Sprite>();
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject screenDuBas = null;
    [SerializeField]private int ScoreNum;

    public static GameManager instance;
    private void Start()
    {
        ScoreNum = 0;
        MyScoreText.text = "Score : " + ScoreNum;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Update()
    {
        switch (health)
        {
            case 0 :
                healthUI.sprite = healthSprites[0];
                break;
            case 1 :
                healthUI.sprite = healthSprites[1];
                break;
            case 2:
                healthUI.sprite = healthSprites[2];
                break;
            case 3:
                healthUI.sprite = healthSprites[3];
                break;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            screenDuBas.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RunGame()
    {
        SceneManager.LoadScene("DovoScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Reprendre()
    {
        pauseMenu.SetActive(false);
        screenDuBas.SetActive(true);
        Time.timeScale = 1;
    }

    public void MoreScore()
    {
        ScoreNum++;
        Debug.Log("+1");
    }
}
