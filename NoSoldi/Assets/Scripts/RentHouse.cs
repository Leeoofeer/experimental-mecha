using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RentHouse : MonoBehaviour
{
    private float price = 0.0f;
    private int sleepness = 0;
    private int happiness = 0;

    public float GetPrice() { return price; }
    public int GetFullness() { return sleepness; }
    public int GetHappiness() { return happiness; }

    void Start()
    {
        InitializeHouse();
    }

    void InitializeHouse()
    {
        price = 500f;
        sleepness = 80;
        happiness = 40;
    }

    public void ConsumeProduct()
    {
        if (PlayerStats.Instance.GetMoney() < price)
        {
            return;
        }
        else
        {
            UIManager.Instance.UpdateMoney();
            PlayerStats.Instance.SetMoney(-price);

            GameTimeManager.Instance.FastForward();
            StartCoroutine(ReturnFastForward());
            
            
        }

    }

    IEnumerator ReturnFastForward()
    {
        yield return new WaitForSeconds(8);
        PlayerStats.Instance.SetSleep(sleepness);
        PlayerStats.Instance.SetHappiness(happiness);
        UIManager.Instance.UpdateSleep();
        UIManager.Instance.UpdateHappiness();
    }
}
