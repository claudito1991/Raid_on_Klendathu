using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float coolDownTime = 0.2f;
    public float currentTime;
    public Transform LeftFirePointPosition;
    public Transform RightFirePointPosition;

    public ParticleSystem LeftMuzzleFlash;
    
    public ParticleSystem RightMuzzleFlash;

    public bool isFirePointLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > coolDownTime && Input.GetMouseButton(0) )
        {
     
           
           GameObject obj = BulletPooler.current.GetPooledObject();
           if (obj == null) return; 
           if(isFirePointLeft)
           {
           obj.transform.position = LeftFirePointPosition.position;
           obj.transform.rotation = LeftFirePointPosition.rotation;
           obj.SetActive(true);
           LeftMuzzleFlash.Play();
           isFirePointLeft=false;
           }   

           else
           {
           obj.transform.position = RightFirePointPosition.position;
           obj.transform.rotation = RightFirePointPosition.rotation;
           obj.SetActive(true);
           RightMuzzleFlash.Play();
           isFirePointLeft=true;
           }

           currentTime = 0f;

        }

    }
}
