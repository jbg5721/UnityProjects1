using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public int score = 0;
    public GameObject lastSpawnPoint;
    public int deaths = 0;
    public float minutes = 0;
    public float seconds = 0;


    // Allows us to refer to the game manager as an instance
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    // If there is another game manager destroy it
    private void Awake()
    {

        deaths = 0;
        score = 0;

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
    }

    // Used to change level
    public void goToLevel(int levelNumber)
    {
        if(levelNumber == 1)
        {
            // Turn the cursor on
            Cursor.visible = false;

            // Unlock the cursor from the middle of the screen
            Cursor.lockState = CursorLockMode.Locked;
        }
        SceneManager.LoadScene(levelNumber);
    }

    
   

    
}