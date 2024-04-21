using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTime : MonoBehaviour
{
    public float rotationSpeed = 1f;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        // Obtener el tiempo transcurrido en horas y convertirlo a un valor entre 0 y 1
        float normalizedTime = (GameTimeManager.Instance.GetGameTimeHours() / 24f);   
        // Calcular el ángulo de rotación en función del tiempo transcurrido
        float rotationAngle = normalizedTime * 360f;
        // Rotar la imagen
        image.transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }
}
