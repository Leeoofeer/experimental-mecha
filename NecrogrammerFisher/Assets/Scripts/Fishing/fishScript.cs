using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishScript : MonoBehaviour
{
    public Transform topBoundary;  
    public Transform bottomBoundary;  
    public float minSpeed = 1f;  
    public float maxSpeed = 3f;  

    private float speed;  
    private Vector2 targetPosition;
    private float changeDirectionTime = 2f;  
    private float timer;

    void Start()
    {
        SetRandomTarget();
        SetRandomSpeed();
        timer = changeDirectionTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f || timer <= 0)
        {
            SetRandomTarget();
            SetRandomSpeed();
            timer = changeDirectionTime;
        }
    }

    void SetRandomTarget()
    {
        float randomY = Random.Range(bottomBoundary.position.y, topBoundary.position.y);
        targetPosition = new Vector2(transform.position.x, randomY);
    }

    void SetRandomSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
}
