using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentHouse : MonoBehaviour
{
    private float price = 0.0f;
    private int sleepness = 0;
    private int happiness = 0;
    private int sanity = 0;

    public float GetPrice() { return price; }
    public int GetFullness() { return sleepness; }
    public int GetHappiness() { return happiness; }
    public int GetSanity() { return sanity; }


    void Start()
    {
        InitializeHouse();
    }

    void InitializeHouse()
    {
        price = 500f;
        sleepness = 60;
        happiness = 40;
        sanity = 30;
    }

    public void ConsumeProduct()
    {
        if (PlayerStats.Instance.GetMoney() < price)
        {
            return;
        }
        else
        {
            PlayerStats.Instance.SetMoney(-price);
            UIManager.Instance.UpdateMoney();

            GameTimeManager.Instance.FastForward(6);
            StartCoroutine(ReturnFastForward());
            
            
        }

    }

    IEnumerator ReturnFastForward()
    {
        yield return new WaitForSeconds(6);
        PlayerStats.Instance.SetSleep(sleepness);
        PlayerStats.Instance.SetHappiness(happiness);
        PlayerStats.Instance.SetSanity(sanity);
        UIManager.Instance.UpdateSleep();
        UIManager.Instance.UpdateHappiness();
        UIManager.Instance.UpdateSanity();
    }
}
