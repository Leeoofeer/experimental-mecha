using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CallClient : MonoBehaviour
{
    #region Singleton
    private static CallClient instance;
    public static CallClient Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("CallClient no encontrado");
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion
    public GameObject head;
    public GameObject torso;
    public Image dni;
    public TextMeshProUGUI nombreDNI, nombreAntecedentes,nombreCV;


    public Sprite[] headSprites; 
    public Sprite[] torsoSprites; 
    bool isFake = false;
    public RandomizadorNombres randomizadorNombres;
    string nombreCompleto;
    public TextMeshProUGUI conAntecedentes, conEstudios, conExperiencia;

    public Image fotoCV;

    public GameObject curriculum, identidad,antecedentes;
    Vector2 curriculumPos, identidadPos, antecedentesPos;



    private void Start()
    {
        curriculumPos = curriculum.transform.localPosition;
        identidadPos = identidad.transform.localPosition;
        antecedentesPos = antecedentes.transform.localPosition;
        LlamarCliente();
        
    }

    public void LlamarCliente()
    {
        RestablecerPosiciones();
        RandomizeHead();
        RandomizeTorso();
        EnviarClienteAlGameManager();
        SetearNombre();
    }

    void RestablecerPosiciones()
    {
        curriculum.transform.localPosition = curriculumPos;
        identidad.transform.localPosition = identidadPos;
        antecedentes.transform.localPosition = antecedentesPos;
        curriculum.transform.localScale = Vector3.one;
        identidad.transform.localScale = Vector3.one;
        antecedentes.transform.localScale = Vector3.one;
    }

    void SetearNombre()
    {
        nombreCompleto = randomizadorNombres.ObtenerNombreCompletoAleatorio();
        nombreDNI.text = nombreCompleto;
        nombreAntecedentes.text = nombreCompleto;
        nombreCV.text = nombreCompleto;
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
        int fakeIt = Random.Range(0, 8);
        if (fakeIt <= 3)
        {
            dni.sprite = face;
            fotoCV.sprite = face;
            isFake = false;
        }
        else
        {
            int randomInd = Random.Range(0, headSprites.Length);
            if (dni != null)
            {                
                dni.sprite = headSprites[randomInd];
                fotoCV.sprite = headSprites[randomInd];
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
        Persona datos = CreateRandomPersona(); 
        ArmarPapeles(datos);
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

    void ArmarPapeles(Persona persona)
    {
        conAntecedentes.text = persona.tieneAntecedentes ? "Si" : "No";
        conEstudios.text = persona.tieneEstudios ? "Si tengo" : "No tengo";
        conExperiencia.text = persona.tieneExperiencia ? "Si tengo" : "No tengo";
    }

}