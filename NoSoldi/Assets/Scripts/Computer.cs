using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{    
    private int sleepness = 0;
    private int happiness = 0;
    private int sanity = 0;
    private int hunger = 0;

    public Material nuevoMaterial;
    private Material materialOriginal; 
    public Renderer rend; 

    public int GetFullness() { return sleepness; }
    public int GetHappiness() { return happiness; }
    public int GetSanity() { return sanity; }


    void Start()
    {
        InitializePC();
    }

    void InitializePC()
    {
        sleepness = -10;
        happiness = 40;
        sanity = 10;
        hunger = -20;
        materialOriginal = rend.material;
    }

    public void ConsumeProduct()
    {
        if (PlayerStats.Instance.GetSleep() < sleepness*-1 && PlayerStats.Instance.GetHunger() < hunger * -1 )
        {
            return;
        }
        else
        {            

            StartCoroutine(CambiarMaterialDespuesDe3Segundos());
            UIManager.Instance.RefreshUI();
            PlayerStats.Instance.isPlaying = true;
            GameTimeManager.Instance.FastForward(3);

        }

    }

    

    IEnumerator CambiarMaterialDespuesDe3Segundos()
    {        
        // Aplicar el nuevo material
        rend.material = nuevoMaterial;

        // Esperar  3 segundos
        yield return new WaitForSeconds(3f);

        // Volver al material original
        rend.material = materialOriginal;
        PlayerStats.Instance.isPlaying = false;

    }
}
