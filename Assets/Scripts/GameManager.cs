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
    [SerializeField] private GameObject GameOver = null;
    [SerializeField] private GameObject screenDuBas = null;
    [SerializeField]private int ScoreNum;
    [SerializeField] private GameObject Title_Theme;
    [SerializeField] private GameObject Main_Theme;
    [SerializeField] private GameObject GameOver_Theme;
    [SerializeField] private GameObject City_Ambience;
    [SerializeField] private GameObject Button_Clicked;
    public GameObject Scream;
    public GameObject Splash;
    

    public static GameManager instance;
    private void Start()
    {
        ScoreNum = 0;
        //MyScoreText.text = "Score : " + ScoreNum;
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
                Main_Theme.SetActive(false);
                City_Ambience.SetActive(false);
                GameOver_Theme.SetActive(true);
                
                GameOver.SetActive(true);
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
        Title_Theme.SetActive(false);
        Main_Theme.SetActive(true);
        City_Ambience.SetActive(true);

    }

    public void LoadScene()
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

    public IEnumerator ClickSound()
    {
        Button_Clicked.SetActive(true);
        yield return new WaitForSeconds(1);
        Button_Clicked.SetActive(false);
    }

    public void Click()
    {
        StartCoroutine(ClickSound());
    }
}
