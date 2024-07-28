using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaristaMovement : MonoBehaviour
{
    private AnimationClip[] myClips;
    private Animator animator;
    public GameObject[] puntos;
    private AnimationClip cl0, cl1, cl2, cl3;

    public float speed = 2.0f;
    private int currentPointIndex = 0;
    private bool moving = true;

    private AnimationClip[] otherAnims;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            myClips = animator.runtimeAnimatorController.animationClips;
            cl0 = myClips[0]; //Idle 2
            cl1 = myClips[1]; //Phone talking
            cl2 = myClips[2]; //Basic Walk
            cl3 = myClips[3]; //Idle 1
            otherAnims = new AnimationClip[] { cl0, cl1, cl3 };
        }
         
        //Debug.Log("C0 " + cl0.name + "  C1 " + cl1.name + "  C2 " + cl2.name + "  C3 " + cl3.name);
        StartCoroutine(MoveToNextPoint());
        //animator.CrossFadeInFixedTime(cl0.name, 1.0f, -1, Random.value * cl0.length);
    }

    IEnumerator MoveToNextPoint()
    {
        while (true)
        {
            if (moving && puntos.Length > 0)
            {
                Vector3 targetPosition = puntos[currentPointIndex].transform.position;
                Vector3 direction = (targetPosition - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

                while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

                    // Mover el NPC hacia el punto objetivo
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                    // Ejecutar animación de movimiento
                    animator.CrossFadeInFixedTime(cl2.name, 0.1f, -1, cl2.length*100);
                    yield return null;
                }

                // Llegó al punto, ejecutar una animación de llegada
                int randomIndex = Random.Range(0, otherAnims.Length);
                animator.CrossFadeInFixedTime(otherAnims[randomIndex].name, 1f);

                // Esperar un momento antes de moverse al siguiente punto
                yield return new WaitForSeconds(10.0f);

                // Actualizar al siguiente punto
                currentPointIndex = (currentPointIndex + 1) % puntos.Length;
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
