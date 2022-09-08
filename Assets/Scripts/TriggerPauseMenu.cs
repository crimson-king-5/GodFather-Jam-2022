using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
