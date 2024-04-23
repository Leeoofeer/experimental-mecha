using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    #region Singleton
    private static PlayerStats instance;

    public static PlayerStats Instance
    {
        get { return instance; }
    }

    // Método para inicializar la instancia del Singleton
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    private float sanity = 100;
    private float hunger = 100;
    private float happiness = 100;
    private float sleep = 100;
    private float money = 1000.0f;

    public GameObject player;

    public float GetSanity() { return sanity; }
    public float GetHunger() { return hunger; }
    public float GetHappiness() { return happiness; }
    public float GetMoney() { return money; }
    public float GetSleep() { return sleep; }

    public void SetSanity(float value)
    {
        sanity += value;
        if (sanity + value >= 100)
        {
            sanity = 100;
        }
    }
    public void SetHunger(float value) 
    { 
        hunger += value; 
        if (hunger + value >= 100)
        {
            hunger = 100;
        }
    }
    public void SetHappiness(float value) 
    { 
        happiness += value; 
        if (happiness + value >= 100)
        {
            happiness = 100;
        }
    }
    public void SetMoney(float value) { money += value; }
    public void SetSleep(float value) 
    { 
        sleep += value; 
        if (sleep + value >= 100)
        {
            sleep = 100;
        }
    }



    void Start()
    {
        InitializeStats();
    }

    private void InitializeStats()
    {
        sanity = 100;
        hunger = 100;
        happiness = 100;
        sleep = 100;
        money = 1000.0f;
    }

    void Update()
    {
        if (hunger <= 0 || happiness <= 0 || sanity <= 0 || sleep <= 0)
        {
            Debug.Log("Game Over");
            player.SetActive(false);
        }
    }

    public bool isSleeping;
    public bool isPlaying;
    public bool isDrinking;

    public void DrainStats(float drainRate)
    {
        
        if (isSleeping)
        {
            sleep += drainRate * 0.9f;
            hunger -= drainRate * 1f;
            happiness += drainRate * 0.9f;
            sanity += drainRate * 0.9f;
        }else if (isPlaying)
        {
            sleep -= drainRate * 0.7f;
            hunger -= drainRate * 1f;
            happiness += drainRate * 0.9f;
            sanity += drainRate * 0.9f;
        }else if (isDrinking)
        {
            sleep -= drainRate * 0.9f;
            hunger += drainRate * 0.4f;
            happiness += drainRate * 0.9f;
            sanity += drainRate * 0.9f;
        }
        else
        {
            sleep -= drainRate * 0.8f;
            hunger -= drainRate * 1f;
            happiness -= drainRate * 0.9f;
            sanity -= drainRate * 0.9f;
        }

        UIManager.Instance.RefreshUI();
    }
}
