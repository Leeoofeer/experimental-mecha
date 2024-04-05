using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public Transform[] puntos;
    public float velocidad = 5f;
    public int checkpointActual = 0;
    public int[] checkPointChecker = { 0, 83, 137, 199 };
    public int nextCheckpoint = 0;
    public int lastClickCounter = 0;

    private void Start()
    {
        transform.position = puntos[0].position;
    }

    private void Update()
    {
        // Actualizar el contador de clics
        int clickCounter = GameManager.Instance != null ? GameManager.Instance.CurrentClicks : 0;

        // Verificar si el contador de clics aumentó desde la última vez
        if (clickCounter > lastClickCounter)
        {
            // Actualizar el último contador de clics
            lastClickCounter = clickCounter;

            // Verificar si el jugador no ha alcanzado el último punto de control
            if (checkpointActual < puntos.Length - 1)
            {
                // Calcular la dirección hacia el siguiente punto de control
                Vector3 direccion = (puntos[checkpointActual + 1].position - transform.position).normalized;

                // Mover al jugador hacia el siguiente punto de control
                transform.position += direccion * velocidad;

                // Verificar si el jugador ha llegado al siguiente punto de control
                if (Vector3.Distance(transform.position, puntos[checkpointActual + 1].position) < 0.1f)
                {
                    checkpointActual++; // Actualizar el índice del punto de control actual
                }
            }
        }
    }
}

