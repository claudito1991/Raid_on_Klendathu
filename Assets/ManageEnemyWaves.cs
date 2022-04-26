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
        initialDistance = Vector3.Distance(playerTransform.position,klendathuTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public float DistanceChecker()
    {
        float distancia = Vector3.Distance(playerTransform.position,klendathuTransform.position);
        float probabilidadAparicion = 1-(distancia/initialDistance);
        var cantidadAleatoria = UnityEngine.Random.Range(5,15);
        float numeroCalculado = (cantidadAleatoria * probabilidadAparicion) + 1;
        return numeroCalculado;
    }

    public int CantidadASpawnear()
    {
        int cantidadASpawnear = Mathf.RoundToInt(DistanceChecker());

        return cantidadASpawnear;
    }


}
