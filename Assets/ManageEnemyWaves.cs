using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageEnemyWaves : MonoBehaviour
{
    public Transform klendathuTransform;

    public Transform playerTransform;
    public Vector3 distanceToKlendathu;

    public float  initialDistance;
    // Start is called before the first frame update
    void Start()
    {
        initialDistance = DistanceChecker();
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public float DistanceChecker()
    {
        float distancia = Vector3.Distance(playerTransform.position,klendathuTransform.position);
        return distancia;
    }

    public int NumeroRaro()
    {
        return Mathf.RoundToInt(initialDistance-DistanceChecker())%10;
    }
}
