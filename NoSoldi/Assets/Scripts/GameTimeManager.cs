using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimeManager : MonoBehaviour
{
    public float timeScale = 10f; // X segundos del juego equivalen a 1 hora del día
    private float gameTimeHours;
    private float originalTimeScale;
    private int gameTimeDays;
    private float drainRatio = 0.09f;
    public PlayerController playerController;
    public ActionDetector actionDetector;

    public TextMeshProUGUI timeScaleText;
    public TextMeshProUGUI originalTimeScaleText;
    public TextMeshProUGUI accumulatedTimeText;
    bool isFastForward = false;

    private float accumulatedTime = 0f;

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
        originalTimeScale = timeScale;
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            // Incrementar el tiempo acumulado en el juego
            accumulatedTime += Time.deltaTime*Time.timeScale;

            if (isFastForward)
            {
                gameTimeHours = (accumulatedTime / originalTimeScale*(timeScale / Time.timeScale)) % 24; // 24 horas en un día

            }else
            {
                gameTimeHours = (accumulatedTime / originalTimeScale / Time.timeScale) % 24; // 24 horas en un día
            }
            // Calcular las horas del día basadas en el tiempo acumulado, considerando la escala del tiempo

            // Acciones dependiendo de la hora del día o uso el GameManager para hacerlo?
            gameTimeDays = (int)(accumulatedTime / (originalTimeScale * 24)); // Cada 24 horas se incrementa en un día
            PlayerStats.Instance.DrainStats(timeScale * Time.deltaTime * drainRatio);
        }
        timeScaleText.text = "Time Scale: " + timeScale;
        originalTimeScaleText.text = "O. Scale: " + originalTimeScale;
        accumulatedTimeText.text = "Accumulated Time: " + accumulatedTime;
    }

    public float GetGameTimeHours()
    {
        return gameTimeHours;
    }

    public void StopTime()
    {
        Time.timeScale = 0f; 
    }

    
    public int GetGameTimeDays()
    {
        return gameTimeDays;
    }

    public void SetTimeScale(float value)
    {
        timeScale = value;
    }

    public void FastForward()
    {
        isFastForward = true;
        SetTimeScale(3f);
        ChangeScriptsState(false);
        StartCoroutine(ReturnToGameplay());
    }    

    IEnumerator ReturnToGameplay()
    {
        yield return new WaitForSeconds(8);
        SetTimeScale(originalTimeScale);
        ChangeScriptsState(true);
        isFastForward = false;
    }

    private void ChangeScriptsState(bool nextState)
    {
        playerController.enabled = nextState;
        actionDetector.enabled = nextState;
    }

    
}

