using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public float timeScale = 10f; // X segundos del juego equivalen a 1 hora del día
    private float gameTimeHours;
    private float originalTimeScale;
    private int gameTimeDays;

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
        originalTimeScale = Time.timeScale;
    }

    void Update()
    {
        // Verificar si el tiempo no está detenido
        if (Time.timeScale > 0)
        {
            // Obtener el tiempo transcurrido desde que se inició el juego
            float elapsedTime = Time.time;

            // Calcular las horas del día
            gameTimeHours = (elapsedTime / timeScale) % 24; // 24 horas en un día

            // Acciones dependiendo de la hora del día o uso el GameManager para hacerlo?
            gameTimeDays = (int)(elapsedTime / (timeScale * 24)); // Cada 24 horas se incrementa en un día

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

