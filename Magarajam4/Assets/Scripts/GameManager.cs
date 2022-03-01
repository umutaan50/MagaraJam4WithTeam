using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Magara Jam 4

public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    public AudioSource backgroundMusic;
    public GameObject optionsMenu;
=======
    public TextMeshProUGUI pauseText;
    private AudioSource backgroundMusic;
>>>>>>> parent of 7d11327 (Added menus)
=======
    public TextMeshProUGUI pauseText;
    private AudioSource backgroundMusic;
>>>>>>> parent of 7d11327 (Added menus)
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
            pauseText.gameObject.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            pauseText.gameObject.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
