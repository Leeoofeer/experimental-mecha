using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : MonoBehaviour
{
    private float price = 0.0f;
    private int sleepness = 0;
    private int happiness = 0;
    private int fullness = 0;
    private int sanity = 0;
    public GameObject insuficientStat;


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
        price = 900f;
        sleepness = -30;
        happiness = -20;
        fullness = 10;
        sanity = -15;
    }

    
    public void ConsumeProduct()
    {
        if (PlayerStats.Instance.GetSleep() > sleepness*-1 || PlayerStats.Instance.GetHappiness() > happiness * -1 || PlayerStats.Instance.GetSanity() > sanity * -1)
        {
            
            GameTimeManager.Instance.FastForward(6);
            StartCoroutine(ReturnFastForward());
        }
        else
        {
            insuficientStat.SetActive(true);
            StartCoroutine(DeactivateGO());
            return;
        }

    }

    IEnumerator DeactivateGO()
    {
        yield return new WaitForSeconds(3);
        insuficientStat.SetActive(false);
    }

    IEnumerator ReturnFastForward()
    {
        yield return new WaitForSeconds(6);
        PlayerStats.Instance.SetMoney(price);
        UIManager.Instance.UpdateMoney();

    }
}
