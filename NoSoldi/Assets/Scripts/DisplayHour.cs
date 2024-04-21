using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayHour : MonoBehaviour
{
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Obtener las horas y los minutos actuales del GameTimeManager
        int hours = Mathf.FloorToInt(GameTimeManager.Instance.GetGameTimeHours());
        int minutes = Mathf.FloorToInt((GameTimeManager.Instance.GetGameTimeHours() - hours) * 60);

        // Formatear la hora para mostrarla en pantalla (HH:MM)
        string timeString = hours.ToString("00") + ":" + minutes.ToString("00");

        text.text = "Time: " + timeString;
    }
}

