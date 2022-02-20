using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Magara Jam 4

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pauseText;
    private AudioSource backgroundMusic;
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            pauseText.gameObject.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
            backgroundMusic.Play();
        }
        else
        {
            pauseText.gameObject.SetActive(true);
            backgroundMusic.Pause();
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
