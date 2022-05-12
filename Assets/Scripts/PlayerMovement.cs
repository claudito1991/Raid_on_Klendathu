using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float xThrow;
    public float yThrow;

    public float speed = 10f;
    public float rangeX = 3.5f;
    public float rangeY=5f;

    public Joystick joystick;

    public GameObject playerExplosionSFX;
    public ParticleSystem playerExplosion;
    public Transform playerPosition;
    public static Action playerExploded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
    }

        public void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        //xThrow = joystick.Horizontal;
        //yThrow = joystick.Vertical;
        //Debug.Log($"Horizontal: {xThrow}");
        //Debug.Log($"Vertical: {yThrow}");
        
        float rawX = transform.localPosition.x + xThrow * speed * Time.deltaTime;
        float rawY = transform.localPosition.y + yThrow * speed * Time.deltaTime;

        float clampedXPos = Mathf.Clamp(rawX, -rangeX, rangeX);
        float clampedYPos = Mathf.Clamp(rawY, -rangeY+7f, rangeY);

        transform.localPosition = new Vector3(
            clampedXPos,
            clampedYPos,
            transform.localPosition.z);
    }

    public void PlayerExplosion()
    {
       
        playerExploded?.Invoke();
        playerExplosion.transform.position = playerPosition.position;
       
    }

    void OnDisable()
    {
       // playerExplosion.transform.position = playerPosition.position;
        //playerExplosion.Play();
         playerExplosionSFX.SetActive(true);
    }
}
