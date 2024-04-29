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

    private int gameDifficulty = 0;
    private int approvedPeople = 0;
    private int deniedPeople = 0;
    private int wrongPeople = 0;
    private Persona currentPersona;
    public GameObject[] rrhhLifes;
    public GameObject req1, req2, req3, req4;
    public TextMeshProUGUI contratados, ignorados;
    public TextMeshProUGUI dificultad;

    void Start()
    {
        CheckGameDifficulty();
    }

    

    void CheckGameDifficulty()
    {
        if ((approvedPeople + deniedPeople) <= 5)
        {
            gameDifficulty = 0;
            req1.SetActive(true);
            req2.SetActive(true);
            dificultad.text = "Dificultad: Fácil";

        }
        else if ((approvedPeople + deniedPeople) <= 10)
        {
            gameDifficulty = 1;
            req3.SetActive(true);
            dificultad.text = "Dificultad: Media";
        }else if ((approvedPeople + deniedPeople) > 10)
        {
            gameDifficulty = 2;
            req4.SetActive(true);
            dificultad.text = "Dificultad: Difícil";
        }
    }


    public void DenyButton()
    {
        Debug.Log("Deny Button Pressed");
        if (CheckRequirements())
        {
            Debug.Log("Requirements Met");
            Debug.Log("Denied Failed");
            deniedPeople++;
            CheckLifes();
            wrongPeople++;
        }
        else
        {
            Debug.Log("Requirements Not Met");
            Debug.Log("Denied Acomplished");
            deniedPeople++;
        }
        ignorados.text = "Ignorados: " + deniedPeople;
        CheckGameDifficulty();
        CallClient.Instance.LlamarCliente();
    }

    public void AcceptButton()
    {
        Debug.Log("Accept Button Pressed");
        if (CheckRequirements())
        {
            Debug.Log("Requirements Met");
            Debug.Log("Approved Acomplished");
            approvedPeople++;
        }
        else
        {
            Debug.Log("Requirements Not Met");
            Debug.Log("Approved Failed");
            wrongPeople++;
            CheckLifes();
            approvedPeople++;
        }
        contratados.text = "Contratados: " + approvedPeople;
        CheckGameDifficulty();
        CallClient.Instance.LlamarCliente();
    }

    private void CheckLifes()
    {
        switch (wrongPeople)
        {
            case 1:
                rrhhLifes[0].SetActive(true);
                break;
            case 2:
                rrhhLifes[1].SetActive(true);
                break;
            case 3:
                rrhhLifes[2].SetActive(true);
                break;
            default:
                Debug.Log("No more lives");
                break;
        }
        if (wrongPeople >= 4)
        {
            Application.Quit();
        }
    }

    bool CheckRequirements()
    {
        switch(gameDifficulty)
        {
            case 0:
                if(!currentPersona.coincideFoto && !currentPersona.tieneExperiencia) { return true; }
                else { return false; }                
            case 1:
                if (!currentPersona.coincideFoto && !currentPersona.tieneExperiencia && !currentPersona.tieneEstudios) { return true; }
                else {  return false; }
            case 2:
                if (!currentPersona.coincideFoto && !currentPersona.tieneExperiencia && !currentPersona.tieneEstudios && currentPersona.tieneAntecedentes) { return true; }
                else { return false; }
            default: return true;
        }
               
    }

    public void ChangeDifficulty()
    {
        gameDifficulty++;
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
        currentPersona = datos;
    }

    public TextMeshProUGUI dbt,dbt1,dbt2,dbt3;


}
