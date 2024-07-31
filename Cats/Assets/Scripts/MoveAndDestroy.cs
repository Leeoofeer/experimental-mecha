using UnityEngine;

public class MoveAndDestroy : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento
    private float timeElapsed = 0f;  // Tiempo transcurrido
    public GameObject alterEgo;

    void Update()
    {
        // Mueve el objeto hacia adelante
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Incrementa el tiempo transcurrido
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 2f)
        {
            alterEgo.SetActive(true);
        }

        // Destruye el objeto después de 5 segundos
        if (timeElapsed >= 4f)
        {
            Destroy(gameObject);
        }
    }
}



