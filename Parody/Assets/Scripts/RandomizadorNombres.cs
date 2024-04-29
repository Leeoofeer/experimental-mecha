using UnityEngine;
using System;

public class RandomizadorNombres : MonoBehaviour
{
    private string[] nombres = { "Juan", "Mar�a", "Luis", "Ana", "Pedro", "Laura", "Carlos", "Sof�a" };
    private string[] apellidos = { "Garc�a", "Rodr�guez", "Mart�nez", "Fern�ndez", "L�pez", "Gonz�lez", "P�rez", "S�nchez" };

    public string ObtenerNombreAleatorio()
    {
        return nombres[UnityEngine.Random.Range(0, nombres.Length)];
    }

    public string ObtenerApellidoAleatorio()
    {
        return apellidos[UnityEngine.Random.Range(0, apellidos.Length)];
    }

    public string ObtenerNombreCompletoAleatorio()
    {
        string nombre = ObtenerNombreAleatorio();
        string apellido = ObtenerApellidoAleatorio();
        return nombre + " " + apellido;
    }

    private void Start()
    {
        string nombreAleatorio = ObtenerNombreAleatorio();
        string apellidoAleatorio = ObtenerApellidoAleatorio();
        string nombreCompletoAleatorio = ObtenerNombreCompletoAleatorio();

        Debug.Log("Nombre aleatorio: " + nombreAleatorio);
        Debug.Log("Apellido aleatorio: " + apellidoAleatorio);
        Debug.Log("Nombre completo aleatorio: " + nombreCompletoAleatorio);
    }
}

