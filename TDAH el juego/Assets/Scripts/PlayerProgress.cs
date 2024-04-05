using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public Transform[] puntos;
    public float velocidad = 5f;
    public int checkpointActual = 0;
    public int[] checkPointChecker = { 0, 83, 130, 199 };
    public int nextCheckpoint = 0;
    public int lastClickCounter = 0;
    public TMPro.TextMeshProUGUI positionText;
    float distanciaTotal = 0;
    private void Start()
    {
        transform.position = puntos[0].position;
    }

    private Vector3 objetivo;


    private void Update()
    {
        int clickCounter = GameManager.Instance != null ? GameManager.Instance.CurrentClicks : 0;
        
        if (clickCounter > lastClickCounter)
        {
            lastClickCounter = clickCounter;
            int clicsRequeridos = 0;
            clicsRequeridos = SetObjective();
            // Verificar si el jugador no ha alcanzado el último punto de control
            if (checkpointActual < puntos.Length - 1)
            {
                // Calcular la distancia y dirección hacia el siguiente punto de control
                float distancia = Vector3.Distance(transform.position, objetivo);
                
                if (distancia > distanciaTotal)
                {
                      distanciaTotal = distancia;
                }
                
                Vector3 direccion = (objetivo - transform.position).normalized;
                float velocidad = 1 * (distanciaTotal / clicsRequeridos) ;

                // Mover al jugador hacia el siguiente punto de control cada vez que hace clic
                transform.position += direccion * velocidad;
                //positionText.text = "POSICION PJ: " + transform.position.ToString() + "  DistanciaTotal: " + distanciaTotal + "  Distancia: " + distancia + "  Velocidad: " + velocidad;

                if (distancia < 0.00001f)
                {
                    checkpointActual++;
                    if (checkpointActual < puntos.Length - 1)
                    {
                        objetivo = puntos[checkpointActual + 1].position;
                    }
                }
            }
        }
    }

    private int SetObjective()
    {
        switch (lastClickCounter)
        {
            case < 83:
                objetivo = puntos[1].position;
                return 83;             
            case >= 83 and < 130:
                objetivo = puntos[2].position;
                return 130-83;
            case >= 130 and < 199:
                objetivo = puntos[3].position;
                return 199-130;
        }
        return 0;
    }
}

