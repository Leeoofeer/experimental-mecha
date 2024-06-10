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
    }
}
