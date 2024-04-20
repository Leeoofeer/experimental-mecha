using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int sanity = 100;
    private int hunger = 100;
    private int happiness = 100;
    private int sleep = 100;
    private float money = 1000.0f;

    public int GetSanity() { return sanity; }
    public int GetHunger() { return hunger; }
    public int GetHappiness() { return happiness; }
    public float GetMoney() { return money; }
    public int GetSleep() { return sleep; }

    public void SetSanity(int value){ sanity = value; }
    public void SetHunger(int value) { hunger = value; }
    public void SetHappiness(int value) { happiness = value; }
    public void SetMoney(float value) { money = value; }
    public void SetSleep(int value) { sleep = value; }



    // Start is called before the first frame update
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
        
    }
}
