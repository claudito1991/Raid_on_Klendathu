using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public GameObject bullet;

    public ParticleSystem explosionEnemigo;
    public float projectileSpeed;
    
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
        if(other.CompareTag("enemy"))
        {
            Instantiate(explosionEnemigo, other.transform.position, other.transform.rotation);
         
            other.gameObject.SetActive(false);
            
            Debug.Log("collision");
        }
    }

}
