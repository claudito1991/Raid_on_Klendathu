using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectileMovement : MonoBehaviour
{
    public static Action PlayerHitted;
    public GameObject bullet;
    public GameObject explosionSFX;

    public ParticleSystem explosionEnemigo;
    public ParticleSystem explosionPlayer;
    public float projectileSpeed;

    public string myTag;
    //public List<string> targetTags;
    public string targetTag;
    
    void OnEnable()
    {
        Invoke("Disable",2f);
    }

    void Update()
    {
        FireProcess();
    }

    void FireProcess()
    {
        bullet.transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
    void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
        
    {



             if(other.CompareTag(myTag))
             {
                gameObject.SetActive(false);
             }
             else if (other.CompareTag("Player"))
            {

            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
            other.gameObject.SetActive(false);
            PlayerHitted?.Invoke();
            //Instantiate(explosionSFX,other.transform.position, other.transform.rotation);
            }
            else if (other.CompareTag("enemy"))
            {
                EnemyExplosionPooling();
                //Instantiate(explosionEnemigo, other.transform.position, other.transform.rotation);
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
         
            
                // if(other.CompareTag("Player") )
                // {
                //     Debug.Log(tag);
                //     PlayerHitted?.Invoke();
                // }
            
          
        
       
    }

    public void EnemyExplosionPooling()
    {
        GameObject explosion = EnemyExplosionPooler.current.GetPooledObject();
                if(explosion == null) return;
                explosion.transform.position = transform.position;
                explosion.transform.rotation = transform.rotation;
                explosion.SetActive(true);
    }

}
