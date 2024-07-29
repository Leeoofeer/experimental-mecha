using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CampoGravitacional : MonoBehaviour
{
   
    public float gravitationalForce = 10f;  // La fuerza de atracción
    public SphereCollider sphereCollider;
    private Rigidbody rb;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;  // Asegúrate de que el collider es un trigger
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("PlayerCat detected");
           rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //Debug.Log("PlayerCat atracting");

                Vector3 direction = (transform.position - rb.position).normalized;
                rb.AddForce(direction * gravitationalForce * Time.deltaTime, ForceMode.Acceleration);
            }
            
        }
        return;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            return;
        }
        rb.velocity = Vector3.zero;
        rb = null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sphereCollider.radius);
    }
}

