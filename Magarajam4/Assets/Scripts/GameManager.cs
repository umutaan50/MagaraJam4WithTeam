using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Magara Jam 4

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public GameObject optionsMenu;
    public bool isPaused = false; 
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            optionsMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            optionsMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
