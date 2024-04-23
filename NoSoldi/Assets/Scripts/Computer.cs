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
        if (PlayerStats.Instance.GetSleep() < sleepness*-1)
        {
            return;
        }
        else
        {            
            //PlayerStats.Instance.SetSleep(-sleepness);
            StartCoroutine(CambiarMaterialDespuesDe3Segundos());
            UIManager.Instance.RefreshUI();

            GameTimeManager.Instance.FastForward(3);
            StartCoroutine(ReturnFastForward());


        }

    }

    IEnumerator ReturnFastForward()
    {
        yield return new WaitForSeconds(3);
        PlayerStats.Instance.SetSleep(sleepness);
        PlayerStats.Instance.SetHappiness(happiness);
        PlayerStats.Instance.SetSanity(sanity);
        PlayerStats.Instance.SetHunger(hunger);
        UIManager.Instance.UpdateSleep();
        UIManager.Instance.UpdateHappiness();
        UIManager.Instance.UpdateSanity();
        UIManager.Instance.UpdateHunger();
    }

    IEnumerator CambiarMaterialDespuesDe3Segundos()
    {        
        // Aplicar el nuevo material
        rend.material = nuevoMaterial;

        // Esperar  3 segundos
        yield return new WaitForSeconds(3f);

        // Volver al material original
        rend.material = materialOriginal;
    }
}
