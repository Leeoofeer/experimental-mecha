using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float smoothRotationSpeed = 10f;
    private ActionDetector actionDetector;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        actionDetector = GetComponent<ActionDetector>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Rotaci�n de la c�mara
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * smoothRotationSpeed * Time.deltaTime);

        // Obtener la direcci�n de movimiento en base a la rotaci�n del jugador
        Vector3 movement = transform.forward * verticalInput + transform.right * horizontalInput;
        movement.Normalize();

        // Mover al jugador
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.E)) { Interact(); }
    }

    void Interact()
    {
        actionDetector.Interact();
        actionDetector.GetObjectName();
    }
}
