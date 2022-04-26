using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed = 10f;
    public int enemyDamage =10;

    public PlayerMovement player;
    public static Action<int> enemyCatched;
    
     // Move the object forward along its z axis 1 unit/second.
      

        
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
          transform.Translate(Vector3.forward * Time.deltaTime*enemySpeed);
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
}
