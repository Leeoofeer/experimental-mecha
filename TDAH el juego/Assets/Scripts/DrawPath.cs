using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DrawPath : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] targets;
   
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] targets)
    {
        lr.positionCount = targets.Length;
        this.targets = targets;
    }

    private void Update()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            lr.SetPosition(i, targets[i].position);
        }
    }

}
