using UnityEngine;

public class CatVision : MonoBehaviour
{
    public float visionDistance = 15f;
    public LayerMask visionMask;

    private void Update()
    {
        Vector3 direction = transform.right; // Asume que el personaje mira a la derecha
        if (Input.GetAxis("Horizontal") < 0)
        {
            direction = -transform.right; // Si el personaje mira a la izquierda
        }

        // Dibuja el campo de visión
        Vector3 leftBoundary = Quaternion.Euler(0, -100, 0) * direction;
        Vector3 rightBoundary = Quaternion.Euler(0, 100, 0) * direction;

        Debug.DrawRay(transform.position, leftBoundary * visionDistance, Color.green);
        Debug.DrawRay(transform.position, rightBoundary * visionDistance, Color.green);

        // Oculta los objetos fuera del campo de visión
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, visionDistance, direction, visionDistance, visionMask);
        foreach (RaycastHit2D hit in hits)
        {
            Vector3 toTarget = (hit.transform.position - transform.position).normalized;
            if (Vector3.Angle(direction, toTarget) < 100)
            {
                hit.transform.gameObject.SetActive(true); // Muestra el objeto
            }
            else
            {
                hit.transform.gameObject.SetActive(false); // Oculta el objeto
            }
        }
    }
}

