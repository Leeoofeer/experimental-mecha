using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager no encontrado");
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void DenyButton()
    {
        Debug.Log("Deny Button Pressed");
        if (CheckRequirements())
        {
            Debug.Log("Requirements Met");
            Debug.Log("Denied Failed");
        }
        else
        {
            Debug.Log("Requirements Not Met");
            Debug.Log("Denied Acomplished");
        }
    }

    public void AcceptButton()
    {
        Debug.Log("Accept Button Pressed");
        if (CheckRequirements())
        {
            Debug.Log("Requirements Met");
            Debug.Log("Denied Acomplished");
        }
        else
        {
            Debug.Log("Requirements Not Met");
            Debug.Log("Denied Failed");
        }
    }

    bool CheckRequirements()
    {
        if (true)
        {
            return true;
        }else 
        {
            return false;
        }        
    }

    public void RecibirDatos(Persona datos)
    {
        // Aquí puedes hacer lo que quieras con los datos recibidos
        Debug.Log("Datos recibidos:");
        Debug.Log("CoincideFoto: " + datos.coincideFoto);
        Debug.Log("TieneExperiencia: " + datos.tieneExperiencia);
        Debug.Log("TieneAntecedentes: " + datos.tieneAntecedentes);
        Debug.Log("TieneEstudios: " + datos.tieneEstudios);
        dbt.text = "CoincideFoto: " + datos.coincideFoto.ToString();
        dbt1.text = "TieneExperiencia: " + datos.tieneExperiencia.ToString();
        dbt2.text = "TieneAntecedentes: " + datos.tieneAntecedentes.ToString();
        dbt3.text = "TieneEstudios: " + datos.tieneEstudios.ToString();
    }

    public TextMeshProUGUI dbt,dbt1,dbt2,dbt3;


}
