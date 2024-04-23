using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager instance;

    public static UIManager Instance
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


    public TextMeshProUGUI daysCounter;
    public TextMeshProUGUI moneyCounter;
    public Slider hungerCounter;
    public Slider happinessCounter;
    public Slider sanityCounter;
    public Slider sleepCounter;

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        RefreshUI();
    }

    public void RefreshUI()
    {
        UpdateDays();
        UpdateMoney();
        UpdateHunger();
        UpdateHappiness();
        UpdateSanity();
        UpdateSleep();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDays();
    }

    public void UpdateDays()
    {
        daysCounter.text = "Day: " + GameTimeManager.Instance.GetGameTimeDays().ToString();
    }

    public void UpdateMoney()
    {
        moneyCounter.text = "Cash: " + PlayerStats.Instance.GetMoney();
    }

    public void UpdateHunger()
    {
        hungerCounter.value = PlayerStats.Instance.GetHunger() / 100f;
    }

    public void UpdateHappiness()
    {
        happinessCounter.value = PlayerStats.Instance.GetHappiness() / 100f;
    }

    public void UpdateSanity()
    {
        sanityCounter.value = PlayerStats.Instance.GetSanity() / 100f;
    }

    public void UpdateSleep()
    {
        sleepCounter.value = PlayerStats.Instance.GetSleep() / 100f;
    }
}
