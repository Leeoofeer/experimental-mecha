using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : Singleton<UIController>
{
    public GameObject Encounter1, Encounter2, Encounter3, Encounter4, Encounter5, Encounter11, Encounter12;
    public GameObject ExitAreaPanel;
    public CharController cC;
    public GameObject Fence;

    private void OnEnable()
    {
        GameEvents.OnCatEncounter += CatEncounter;
        GameEvents.OnExitArea += ExitArea;
    }

    private void OnDisable()
    {
        GameEvents.OnCatEncounter -= CatEncounter;
        GameEvents.OnExitArea -= ExitArea;
    }

    public void CatEncounter(CatEncounter catEncounter)
    {
       /* switch(catEncounter) {
            case global::CatEncounter.CAT_01:
                Encounter1.SetActive(true);
                cC.catEncounters++;
                DeactivateFence();

                break;
            case global::CatEncounter.CAT_02:
                Encounter2.SetActive(true);
                cC.catEncounters++;
                DeactivateFence();

                break;
            case global::CatEncounter.CAT_03:
                Encounter3.SetActive(true);
                cC.catEncounters++;
                DeactivateFence();

                break;
            case global::CatEncounter.CAT_04:
                Encounter4.SetActive(true);
                cC.catEncounters++;
                DeactivateFence();

                break;
            case global::CatEncounter.CAT_05:
                Encounter5.SetActive(true);
                cC.catEncounters++;
                DeactivateFence();
                break;
            case global::CatEncounter.CAT_11:
                Encounter11.SetActive(true);
                break;
            case global::CatEncounter.CAT_12:
                Encounter12.SetActive(true);
                break;
        }  */  
    }

    public void DeactivateFence()
    {
        if (cC.catEncounters == 5)
        {
            Fence.SetActive(false);
        }
    }

    public void ExitArea() 
    {
        ExitAreaPanel.SetActive(true);
    }
}
