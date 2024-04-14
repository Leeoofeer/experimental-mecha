using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaceSelector : MonoBehaviour
{
    private FirebaseTest firebaseTest;

    private void Start()
    {
        firebaseTest = GameObject.Find("GameManager").GetComponent<FirebaseTest>();
        Button miBoton = GetComponent<Button>();
        TextMeshProUGUI miTexto = GetComponentInChildren<TextMeshProUGUI>();
        miTexto.text = lugarSeleccionado.ToString();
        // Agrega un listener para el evento onClick del botón y asigna la función MiFuncion
        miBoton.onClick.AddListener(SendPlace);
    }
    public enum Lugares
    {
        Compu,
        Cama,
        Sillon,
        Balcon,
        Lavadero,
        Baño,
        Cocina,
        Comedor
    }

    // Variable para almacenar el lugar seleccionado
    public Lugares lugarSeleccionado;

    public void SendPlace()
    {
        firebaseTest.SendPlaceButton(lugarSeleccionado.ToString());
    }
}
