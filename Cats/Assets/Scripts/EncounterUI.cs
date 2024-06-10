using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EncounterUI : MonoBehaviour
{
    public GameObject PanelObj;
    public List<GameObject> PetObjects, ContinueObjects;

    private void OnEnable()
    {
        PetObjects.ForEach(x => x.SetActive(true));
        ContinueObjects.ForEach(x => x.SetActive(false));
    }

    public void ButtonPet()
    {
        PetObjects.ForEach(x => x.SetActive(false));
        ContinueObjects.ForEach(x => x.SetActive(true));
    }

    public void ButtonContinue()
    { 
        PanelObj.SetActive(false);
    }
}
