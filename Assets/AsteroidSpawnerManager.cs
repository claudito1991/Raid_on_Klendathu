
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnerManager : MonoBehaviour
{
    public int asteroidQuantity;
    public Collider ringCollider;
    public MeshCollider ringMeshCollider;
    
    public List<GameObject> asteroidModels = new List<GameObject>();
    public Collider auxiliaryCollider;
    public Collider auxiliaryCollider2;
    // Start is called before the first frame update
    void Start()
    {
        PopulateBelt();
    }

    private void PopulateBelt()
    {
          for (int i=0; i<asteroidQuantity;i++)
        {
            int elements = asteroidModels.Count - 1;
            int index = Random.Range(0, elements);
            GameObject obj = Instantiate(asteroidModels[index],PositionToSpawn(),Quaternion.identity);     
        }
    }



    // Update is called once per frame
    void Update()
    {
        PopulateBelt();
    }

    public Vector3 PositionToSpawn()
    {

        Vector3 position = RandomPointInBounds(ringMeshCollider.bounds);

        if(ringMeshCollider.bounds.Contains(position))
        {
            return position;
        }
        else
        {
            while(ringMeshCollider.bounds.Contains(position)==false)
            {
                position = RandomPointInBounds(ringMeshCollider.bounds);
            }
            return position;
        }
    }

    public  Vector3 RandomPointInBounds(Bounds bounds) 
    {

    Vector3 randPosition = new Vector3( UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                                        UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
                                        UnityEngine.Random.Range(bounds.min.z, bounds.max.z));  

                                 
    return randPosition;
    }

}
