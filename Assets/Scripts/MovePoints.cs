using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    [SerializeField] private float moveSpeed;   
    [SerializeField] private Transform[] nPoints; 

    private int currentPoint = 0;                

    private void Update()
    {
        if (nPoints.Length == 0) return; 
        int nextPoint = (currentPoint + 1) % nPoints.Length;

        transform.position = Vector3.MoveTowards(transform.position, nPoints[nextPoint].position, moveSpeed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, nPoints[nextPoint].position) < 0.1f)
        {
            currentPoint = nextPoint;
        }
    }
}
