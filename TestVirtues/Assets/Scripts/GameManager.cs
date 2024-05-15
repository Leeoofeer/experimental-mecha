using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject("GameManager");
                _instance = singletonObject.AddComponent<GameManager>();
                DontDestroyOnLoad(singletonObject);
            }
            return _instance;
        }
    }
    #endregion



    public TextMeshProUGUI karmaText;

    public int karmaScore = 0;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        karmaScore = PlayerPrefs.GetInt("Karma");

        if(Input.GetKeyDown(KeyCode.F4))
        {
            PlayerPrefs.SetInt("Karma", 0);
        }
    }

    
    public void AddKarma(int karma)
    {
       
        Debug.Log("Karma + : " + karma);
        PlayerPrefs.SetInt("Karma", PlayerPrefs.GetInt("Karma") + karma);
    }

    public void NextLevel()
    {
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
