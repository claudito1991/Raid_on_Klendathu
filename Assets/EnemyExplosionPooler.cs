using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosionPooler : MonoBehaviour
{
 public static EnemyExplosionPooler current;
    public GameObject pooledExplosion;
    public int pooledAmount;
    public bool willGrow;
    private List<GameObject> pooledObjects;

    void Awake()
    {
        current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i =0; i<pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledExplosion);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i<pooledObjects.Count;i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if(willGrow)
        {
            GameObject obj = Instantiate(pooledExplosion);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;

    }
}
