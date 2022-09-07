using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boutons : MonoBehaviour
{
    public void RunGame (){
        SceneManager.LoadScene("DovoScene");
    }

    public void Quit(){
        Application.Quit();
    }

    public void BackMenu(){
        SceneManager.LoadScene("SantinoScene");
    }

    public void Reprendre(){
        Time.timeScale=1;
    }

    void Update() {
        if (Input.GetKey(KeyCode.Escape)){
            Time.timeScale=0;
        }
    }
}
