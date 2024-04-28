using UnityEngine;
using UnityEngine.UI;

public class CallClient : MonoBehaviour
{
    public GameObject head;
    public GameObject torso;
    public Image dni;

    public Sprite[] headSprites; 
    public Sprite[] torsoSprites; 
    bool isFake = false;
   

    public void LlamarCliente()
    {
        RandomizeHead();
        RandomizeTorso();
        EnviarClienteAlGameManager();
    }

    void RandomizeHead()
    {
        if (headSprites.Length > 0 && head != null)
        {
            int randomIndex = Random.Range(0, headSprites.Length);

            Image headRenderer = head.GetComponent<Image>();
            if (headRenderer != null)
            {
                headRenderer.sprite = headSprites[randomIndex];
                FakeClient(headSprites[randomIndex]);
            }
        }
        else
        {
            Debug.LogWarning("No hay sprites de cabeza asignados o falta el GameObject de la cabeza.");
        }
    }

    void FakeClient(Sprite face)
    {
        int fakeIt = Random.Range(0, 4);
        if (fakeIt <= 2)
        {
            dni.sprite = face;
            isFake = false;
        }
        else
        {
            int randomInd = Random.Range(0, headSprites.Length);
            if (dni != null)
            {                
                dni.sprite = headSprites[randomInd];
                isFake = true;
            }
        }
        

    }

    void RandomizeTorso()
    {
        if (torsoSprites.Length > 0 && torso != null)
        {
            int randomIndex = Random.Range(0, torsoSprites.Length);

            Image torsoRenderer = torso.GetComponent<Image>();
            if (torsoRenderer != null)
            {
                torsoRenderer.sprite = torsoSprites[randomIndex];
            }
        }
        else
        {
            Debug.LogWarning("No hay sprites de torso asignados o falta el GameObject del torso.");
        }
    }

    

    public void EnviarClienteAlGameManager()
    {
        // Crear una instancia de DatosEmpleado
        Persona datos = CreateRandomPersona(); 

        // Pasar los datos al GameManager
        GameManager.Instance.RecibirDatos(datos);
    }

    public Persona CreateRandomPersona()
    {
        //Devuelve true o false dependiendo de si el valor aleatorio es mayor a 0.5 o no
        bool coincideFoto = !isFake;
        bool tieneExperiencia = Random.value > 0.5f;
        bool tieneAntecedentes = Random.value > 0.5f;
        bool tieneEstudios = Random.value > 0.5f;

        return new Persona(coincideFoto, tieneExperiencia, tieneAntecedentes, tieneEstudios);
    }

}