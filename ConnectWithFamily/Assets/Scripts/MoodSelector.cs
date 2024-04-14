using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoodSelector : MonoBehaviour
{
    private FirebaseTest firebaseTest;

    private void Start()
    {
        firebaseTest = GameObject.Find("GameManager").GetComponent<FirebaseTest>();
        Button miBoton = GetComponent<Button>();
        TextMeshProUGUI miTexto = GetComponentInChildren<TextMeshProUGUI>();
        miTexto.text = moodSeleccionado.ToString();
        // Agrega un listener para el evento onClick del botón y asigna la función MiFuncion
        miBoton.onClick.AddListener(SendMood);
    }

    public enum Moods
    {
        Feliz,
        Triste,
        Ansioso,
        Ocupado,
        Enojado,
        Hambriento,
        Cansado,
        Concentrado,
        Enfermo
    }

    // Variable para almacenar el lugar seleccionado
    public Moods moodSeleccionado;

    public void SendMood()
    {
        firebaseTest.SendMoodButton(moodSeleccionado.ToString());
    }
}
