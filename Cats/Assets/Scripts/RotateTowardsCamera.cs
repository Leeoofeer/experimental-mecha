using UnityEngine;

public class RotateTowardsCamera : MonoBehaviour
{
    public GameObject playerPosition;

    void Start()
    {
        if (playerPosition == null)
        {
            Debug.LogError("No player found");
        }
    }

    void Update()
    {
        if (playerPosition != null)
        {
            Vector3 direction = playerPosition.transform.position - transform.position;
            direction.y = 0;  // Ignora la diferencia en el eje Y
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);  // Ajusta la velocidad de rotación según sea necesario
        }
    }
}

