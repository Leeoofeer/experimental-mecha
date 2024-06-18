using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public float MaxUp;
    public float MaxDown;
    public float MaxRight;
    public float MaxLeft;

    public int Cats;
    public GameObject shirt;

    [SerializeField]
    Material[] materials;

    private void OnEnable()
    {
        GameEvents.OnCatEncounter += CatEncounter;
    }

    private void OnDisable()
    {
        GameEvents.OnCatEncounter -= CatEncounter;
    }

    public void CatEncounter(CatEncounter catEncounter)
    {
        Cats++;
        ChangeMaterial(Cats);
    }

    private void Start()
    {
        Cats = 0;
        ChangeMaterial(Cats);
    }

    void ChangeMaterial(int cats)
    {
        switch (cats)
        {
            case 0:
                shirt.GetComponent<Renderer>().material = materials[0];
                break;
            case 1:
                shirt.GetComponent<Renderer>().material = materials[1];
                break;
            case 3:
                shirt.GetComponent<Renderer>().material = materials[2];
                break;
            case 5:
                shirt.GetComponent<Renderer>().material = materials[3];
                break;            
            default:
                break;
        }
    }

}
