using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTime : MonoBehaviour
{
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        // Obtener el tiempo transcurrido en horas y convertirlo a un valor entre 0 y 1
        float normalizedTime = (GameTimeManager.Instance.GetGameTimeHours() / GameTimeManager.Instance.dayDuration);   
        // Calcular el ángulo de rotación en función del tiempo transcurrido
        float rotationAngle = normalizedTime * 3600f;
        // Rotar la imagen
        image.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }
}
