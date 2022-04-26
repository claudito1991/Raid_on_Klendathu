using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemyModel;
    public Collider enemyCollider;
    public Transform enemySpawner;

    public ManageEnemyWaves enemyWaves;
    private float timeRemaining = 10f;

    public float timeBetweenEnemies = 3f;
    public int enemyQuantity = 3;

    // Start is called before the first frame update
    void Start()
    {
        //enemyCollider = enemyModel.GetComponent<Collider>();
        StartCoroutine(GenerateEnemiesOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        GenerateEnemiesWithTimer();
      //StartCoroutine(GenerateEnemiesOverTime());
    }
    IEnumerator GenerateEnemiesOverTime()
    {
        yield return new WaitForSeconds(2f);
        EnemyGeneration();
    }
    public static Vector3 RandomPointInBounds(Bounds bounds) 
    {
    return new Vector3(
        UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
        UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
        UnityEngine.Random.Range(bounds.min.z, bounds.max.z)
    );
    }

    public void EnemyGeneration()
    {
        enemyQuantity = enemyWaves.CantidadASpawnear();
        for (int i=0; i<enemyQuantity;i++)
        {
            var enemy = Instantiate(enemyModel,RandomPointInBounds(enemyCollider.bounds), Quaternion.identity);
            var targetRotation = Quaternion.LookRotation(enemySpawner.transform.forward, Vector3.up);
            enemy.transform.rotation  = targetRotation;
        }


    }

    Vector3 GetRandomPointInCollider()
    {

        var point = new Vector3(
            UnityEngine.Random.Range(enemyCollider.bounds.min.x, enemyCollider.bounds.max.x),
            UnityEngine.Random.Range(enemyCollider.bounds.min.y, enemyCollider.bounds.max.y),
            UnityEngine.Random.Range(enemyCollider.bounds.min.z, enemyCollider.bounds.max.z)
        );
 
        return point;
    }


        public void GenerateEnemiesWithTimer()
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            else
            {
               
               
                EnemyGeneration();
                timeRemaining = timeBetweenEnemies;
            }

        }

}



