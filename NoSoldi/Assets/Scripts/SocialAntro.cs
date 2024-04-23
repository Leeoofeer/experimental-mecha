using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialAntro : MonoBehaviour
{
    private float price = 0.0f;
    private int sleepness = 0;
    private int happiness = 0;
    private int fullness = 0;
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
        price = 200f;
        sleepness = -35;
        happiness = 20;
        fullness = 15;
        sanity = 30;
    }

    public void ConsumeProduct()
    {

        if (PlayerStats.Instance.GetMoney() > price && PlayerStats.Instance.GetSleep() > sleepness*-1)
        {
            PlayerStats.Instance.SetMoney(-price);
            UIManager.Instance.UpdateMoney();
            GameTimeManager.Instance.FastForward(4);
            PlayerStats.Instance.isDrinking = true;
            StartCoroutine(ReturnFastForward()); 
        }
        else
        {
            return;
        }

    }
    IEnumerator ReturnFastForward()
    {
        yield return new WaitForSeconds(4);
        PlayerStats.Instance.isDrinking = false;

    }
   
}
