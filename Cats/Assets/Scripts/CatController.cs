using UnityEngine;

public class CatController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public AudioSource meowAudioSource;

    private bool isSitting = false;
    private bool isMeowing = false;

    void Update()
    {
        HandleMovement();
        HandleAnimation();
    }

    void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveVertical, 0.0f, -moveHorizontal);

        if (movement != Vector3.zero && !isSitting)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
            transform.forward = movement;
        }
    }

    void HandleAnimation()
    {
        float  moveVertical= Input.GetAxis("Horizontal");
        float moveHorizontal = Input.GetAxis("Vertical");

        bool isWalking = moveHorizontal != 0 || moveVertical != 0;
        animator.SetBool("isWalking", isWalking);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            isSitting = !isSitting;
            animator.SetTrigger("isSitting");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isMeowing)
            {
                isMeowing = true;
                animator.SetBool("isMeowing", isMeowing);
                if (meowAudioSource != null)
                {
                    meowAudioSource.Play();
                }
            }else
            {
                isMeowing = false;
                animator.SetBool("isMeowing", isMeowing);
                if (meowAudioSource != null)
                {
                    meowAudioSource.Stop();
                }
            }
            
        }
    }


    
}
