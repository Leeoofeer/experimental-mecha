
using UnityEngine;

public class Persona : MonoBehaviour
{
    public bool coincideFoto;
    public bool tieneExperiencia;
    public bool tieneAntecedentes;
    public bool tieneEstudios;

    public Persona(bool coincideFoto, bool tieneExperiencia, bool tieneAntecedentes, bool tieneEstudios)
    {
        this.coincideFoto = coincideFoto;
        this.tieneExperiencia = tieneExperiencia;
        this.tieneAntecedentes = tieneAntecedentes;
        this.tieneEstudios = tieneEstudios;
    }
}

