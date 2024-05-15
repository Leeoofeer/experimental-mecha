using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    void Awake()
    {
        // Ensure this object is not destroyed when loading a new scene
        DontDestroyOnLoad(gameObject);

        // Ensure there is only one instance of this object (singleton pattern)
        if (FindObjectsOfType<PersistentObject>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
