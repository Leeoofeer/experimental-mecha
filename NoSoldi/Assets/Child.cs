using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Child : MonoBehaviour
{

    void Start()
    {
        InvokeRepeating("MaitainResources", 0, 1);
        InvokeRepeating("DoItFast",0,15);
    }

    void Update()
    {
        if(GameTimeManager.Instance.GetGameTimeDays() >= 3)
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
            SceneManager.LoadScene(1);
        }
    }

    void DoItFast()
    {
        GameTimeManager.Instance.isFastForwarding = true;

    }    


    void MaitainResources()
    {
        PlayerStats.Instance.SetHunger(100);
        PlayerStats.Instance.SetSanity(100);
        PlayerStats.Instance.SetMoney(10000);
    }


}
