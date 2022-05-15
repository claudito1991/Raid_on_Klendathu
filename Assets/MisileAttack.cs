using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisileAttack : MonoBehaviour
{
    public float projectileSpeed;
    public bool isShooted;

    public GameObject visualMisile;

    public GameObject misile;

    public Transform initialPosition;

    public GameObject misileExplosion;

    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform;
    }

    void OnEnable()
    {
        transform.position = visualMisile.transform.position;
        visualMisile.SetActive(false);
        currentTime=0f;
        
    }

    public void MissedTargetDisable()
    {
        
        currentTime += Time.deltaTime;
        if(currentTime>3f)
        {
            Debug.Log(currentTime);
            MisileExplosion();
            ResetState();
        }
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        MissedTargetDisable();
        
    }

    public void Movement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemy"))
        {
            MisileExplosion();
            ResetState();
        }

    }

    private void ResetState()
    {
        misile.SetActive(false);
        visualMisile.SetActive(true);
        transform.position = initialPosition.position;
    }

    private void MisileExplosion()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.SendMessage("DieSequence", SendMessageOptions.DontRequireReceiver);
            //Debug.Log("enemy reached");
        }
    }

    void OnDisable()
    {
        Instantiate(misileExplosion,transform.position,transform.rotation);
    }
}
