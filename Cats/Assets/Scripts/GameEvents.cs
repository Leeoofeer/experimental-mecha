using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static Action<CatEncounter> OnCatEncounter;
    public static void CatEncounter(CatEncounter c)
    {
        OnCatEncounter?.Invoke(c);
    }

    public static Action OnExitArea;
    public static void ExitArea()
    {
        OnExitArea?.Invoke();
    }
}
