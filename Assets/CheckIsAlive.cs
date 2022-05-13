using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsAlive : MonoBehaviour
{
    private ParticleSystem thisParticle;
    public float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        thisParticle = GetComponent<ParticleSystem>();
    }

    void OnEnable()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime += Time.deltaTime;
        if(thisParticle.main.duration<currentTime)
        {
            Debug.Log(thisParticle.main.duration);
            Debug.Log(currentTime);
            gameObject.SetActive(false);
        }
    }   
}
