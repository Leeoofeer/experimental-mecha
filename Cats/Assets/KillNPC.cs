using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillNPC : MonoBehaviour
{
      

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            Destroy(other.gameObject);
        }
    }
}


