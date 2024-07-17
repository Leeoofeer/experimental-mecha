using System.Collections;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CatController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public AudioSource meowAudioSource;

    private bool isSitting = false;
    private bool isMeowing = false;
    private Rigidbody rb;
    public GameObject endTree, endTreeEmpty;
    public GameObject scratchUI;
    public AudioSource walk, walkGrass, scratch;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ensure Rigidbody settings
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        rb.useGravity = false;  // Optional, depending on whether you want gravity
    }

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
            // Move the cat
            rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
            transform.forward = movement;  // Rotate to face movement direction
        }
    }

    void HandleAnimation()
    {
        float moveVertical = Input.GetAxis("Horizontal");
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
            isMeowing = !isMeowing;
            animator.SetBool("isMeowing", isMeowing);

            if (meowAudioSource != null)
            {
                if (isMeowing)
                {
                    meowAudioSource.Play();
                }
                else
                {
                    meowAudioSource.Stop();
                }
            }
        }
    }

    public void ScratchTree()
    {
        endTreeEmpty.SetActive(false);
        endTree.SetActive(true);
        StartCoroutine(ScratchTreeSound());
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("EndTree"))
        {
            //Debug.Log("colisionando con endtree");
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Pending add scratch the tree
                scratchUI.SetActive(true);
                
            }
        }

        if(collision.gameObject.CompareTag("GrassFloor"))
        {
            if (walkGrass.isPlaying)
            {
                walk.Stop();
            }
            else
            {
                walkGrass.Play();
            }            
            
            
        }
        else
        {
            walkGrass.Stop();
        }
        if (collision.gameObject.CompareTag("NormalFloor"))
        {
            if (walk.isPlaying)
            {
                walkGrass.Stop();
            }
            else
            {
                walk.Play();

            }
        }
        else
        {
            walk.Stop();
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("NormalFloor") || collision.gameObject.CompareTag("GrassFloor"))
        {
            walkGrass.Stop();
            walk.Stop();

        }
    }

    IEnumerator ScratchTreeSound()
    {
        scratch.Play();
        yield return new WaitForSeconds(4);
        scratch.Stop();
    }
}

