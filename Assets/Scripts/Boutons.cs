using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boutons : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject Title_Theme;
    [SerializeField] private GameObject Main_Theme;
    public void RunGame (){
        //SceneManager.LoadScene("DovoScene");
    }

    public void Quit(){
        Application.Quit();
    }

    public void BackMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void Reprendre(){
        pauseMenu.SetActive(false);
        Time.timeScale=1;
    }

    public void MusicChange()
    {
        Title_Theme.SetActive(false);
        Main_Theme.SetActive(true);
    }
}
