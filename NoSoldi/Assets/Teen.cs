using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teen : MonoBehaviour
{

    void Start()
    {
        InvokeRepeating("MaitainResources", 0, 10);
        InvokeRepeating("DoItFast", 15, 60);
    }

    void Update()
    {
        if (GameTimeManager.Instance.GetGameTimeDays() >= 1)
        {
            foreach (var singleton in FindObjectsOfType<GameManager>())
            {
                Destroy(singleton.gameObject);
            }

            foreach (var singleton in FindObjectsOfType<UIManager>())
            {
                Destroy(singleton.gameObject);
            }

            foreach (var singleton in FindObjectsOfType<GameTimeManager>())
            {
                Destroy(singleton.gameObject);
            }

            foreach (var singleton in FindObjectsOfType<PlayerStats>())
            {
                Destroy(singleton.gameObject);
            }
            SceneManager.LoadScene(3);
        }
    }

    void DoItFast()
    {
        GameTimeManager.Instance.isFastForwarding = true;

    }


    void MaitainResources()
    {
        PlayerStats.Instance.SetSanity(100);
        PlayerStats.Instance.SetMoney(500);
    }


}
