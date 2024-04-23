using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTruck : MonoBehaviour
{
    private float price = 0.0f;
    private int fullness = 0;
    private int happiness = 0;

    public float GetPrice() { return price; }
    public int GetFullness() { return fullness; }
    public int GetHappiness() { return happiness; }
    
    void Start()
    {
        InitializeFoodTruck();
    }

    void InitializeFoodTruck()
    {
        price = 150f;
        fullness = 35;
        happiness = 10;
    }

    public void ConsumeProduct()
    {
        if (PlayerStats.Instance.GetMoney() < price)
        {
            return;
        }
        else
        {
            PlayerStats.Instance.SetHunger(fullness);
            PlayerStats.Instance.SetHappiness(happiness);
            PlayerStats.Instance.SetMoney(-price);
            UIManager.Instance.UpdateMoney();
            UIManager.Instance.UpdateHunger();
            UIManager.Instance.UpdateHappiness();
        }
        
    }

}
