using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public float timeScale = 10f; // X segundos del juego equivalen a 1 hora del d�a
    private float gameTimeHours;
    private float originalTimeScale;
    private int gameTimeDays;

    #region Singleton
    private static GameTimeManager instance;

    public static GameTimeManager Instance
    {
        get { return instance; }
    }

    // M�todo para inicializar la instancia del Singleton
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
        originalTimeScale = Time.timeScale;
    }

    void Update()
    {
        // Verificar si el tiempo no est� detenido
        if (Time.timeScale > 0)
        {
            // Obtener el tiempo transcurrido desde que se inici� el juego
            float elapsedTime = Time.time;

            // Calcular las horas del d�a
            gameTimeHours = (elapsedTime / timeScale) % 24; // 24 horas en un d�a

            // Acciones dependiendo de la hora del d�a o uso el GameManager para hacerlo?
            gameTimeDays = (int)(elapsedTime / (timeScale * 24)); // Cada 24 horas se incrementa en un d�a

        }
    }

    public float GetGameTimeHours()
    {
        return gameTimeHours;
    }

    public void StopTime()
    {
        Time.timeScale = 0f; 
    }

    public void ResumeTime()
    {
        Time.timeScale = originalTimeScale;
    }
    public int GetGameTimeDays()
    {
        return gameTimeDays;
    }
}

