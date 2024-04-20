using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    #region Singleton
    private static GameTimeManager instance;

    public static GameTimeManager Instance
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

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTimeUI(float hours)
    {
        // Obtener el texto del reloj
        Text clockText = GameObject.Find("ClockText").GetComponent<Text>();

        // Convertir las horas a un formato de 24 horas
        int hoursInt = (int)hours;
        int minutes = (int)((hours - hoursInt) * 60);

        // Actualizar el texto del reloj
        clockText.text = hoursInt.ToString("00") + ":" + minutes.ToString("00");
    }
}
