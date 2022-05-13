using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed = 10f;
    public int enemyDamage =10;

    public GameObject bulletPrefab;


    public Transform enemyFirepoint;


    private PlayerMovement player;
    public static Action<int> enemyCatched;

    private float currentTime;
    [SerializeField]
    private float coolDownTime = 0.3f;

    private ChangeScaleOverTime selfScale;
    
     // Move the object forward along its z axis 1 unit/second.
      

    // Start is called before the first frame update
    void Start()
    {
        selfScale = GetComponent<ChangeScaleOverTime>();
        if(player == null)
        {

        }
        else
        {
            player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(selfScale.scalingCompleted)
        {
            transform.Translate(Vector3.forward * Time.deltaTime*enemySpeed);
        }
       
      
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.PlayerExplosion();
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("catcher"))
        {
            enemyCatched?.Invoke(enemyDamage);
            gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
            EnemyShooting();
    }



    void EnemyShooting()
    {

        currentTime += Time.deltaTime;
        if(currentTime > coolDownTime && FindPlayer())
        {
            Instantiate(bulletPrefab, enemyFirepoint.position,enemyFirepoint.rotation);
            currentTime = 0f;
        }
        
    }

 
    bool FindPlayer()

    {     // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 0;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            return false;
        }
    }
}
