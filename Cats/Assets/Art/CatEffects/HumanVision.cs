using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanVision : MonoBehaviour
{
    public float visionDistance = 10f;
    public float visionAngle = 120f;
    public LayerMask visionMask;
    private HashSet<GameObject> visibleObjects = new HashSet<GameObject>();

    private void Update()
    {
        Vector3 direction = transform.right * (transform.localScale.x > 0 ? 1 : -1);
        Vector3 leftBoundary = Quaternion.Euler(0, -visionAngle / 2, 0) * direction;
        Vector3 rightBoundary = Quaternion.Euler(0, visionAngle / 2, 0) * direction;

        Debug.DrawRay(transform.position, leftBoundary * visionDistance, Color.red);
        Debug.DrawRay(transform.position, rightBoundary * visionDistance, Color.red);

        RaycastHit[] hits = Physics.SphereCastAll(transform.position, visionDistance, direction, visionDistance, visionMask);
        HashSet<GameObject> currentlyVisibleObjects = new HashSet<GameObject>();

        foreach (RaycastHit hit in hits)
        {
            Vector3 toTarget = (hit.transform.position - transform.position).normalized;
            if (Vector3.Angle(direction, toTarget) < visionAngle / 2)
            {
                hit.transform.gameObject.SetActive(true);
                currentlyVisibleObjects.Add(hit.transform.gameObject);
            }
        }

        foreach (var obj in visibleObjects)
        {
            if (!currentlyVisibleObjects.Contains(obj))
            {
                //obj.SetActive(false);
            }
        }

        visibleObjects = currentlyVisibleObjects;
    }
}
