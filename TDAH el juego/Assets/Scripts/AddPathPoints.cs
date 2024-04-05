using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPathPoints : MonoBehaviour
{
    [SerializeField] private Transform[] pathPoints;
    [SerializeField] private DrawPath drawPath;

    private void Start()
    {
        drawPath.SetUpLine(pathPoints);
    }
}
