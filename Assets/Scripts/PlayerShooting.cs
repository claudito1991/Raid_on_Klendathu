using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShooting : MonoBehaviour
{
    public static Action PlayerShoots;

    public float coolDownTime = 0.2f;
    public float currentTime;

    public bool LaserIsOverheated;

    //public LaserStatusBarManager laserStatusBar;
    public Transform LeftFirePointPosition;
    public Transform RightFirePointPosition;

    public ParticleSystem LeftMuzzleFlash;

    private FiringSoundTrackSelection shootingSFX;
    
    public ParticleSystem RightMuzzleFlash;

    public bool isFirePointLeft;
    // Start is called before the first frame update
    void Start()
    {
        //laserStatusBar.SetMaxTemp(maxLaserTemperature);
        //laserStatusBar.ImageColor(Color.blue);
        shootingSFX = GetComponent<FiringSoundTrackSelection>();
    }
    void OnEnable()
    {
        LaserStatusController.CantShoot += CheckLaserStatus;
    }

    void CheckLaserStatus(bool estado)
    {
        LaserIsOverheated = estado;
    }

    // Update is called once per frame
    void Update()
    {
 
        if(!LaserIsOverheated)
        {
            PlayerFiringProcess();
        }
        
     
    }

    private void PlayerFiringProcess()
    {
        currentTime += Time.deltaTime;
        if (currentTime > coolDownTime && Input.GetMouseButton(0))
        {
            PlayerShoots?.Invoke();
            shootingSFX.ShootingSound();

    
            GameObject obj = BulletPooler.current.GetPooledObject();
            if (obj == null) return;
            if (isFirePointLeft)
            {
                obj.transform.position = LeftFirePointPosition.position;
                obj.transform.rotation = LeftFirePointPosition.rotation;
                obj.SetActive(true);
                LeftMuzzleFlash.Play();
                isFirePointLeft = false;
            }

            else
            {
                obj.transform.position = RightFirePointPosition.position;
                obj.transform.rotation = RightFirePointPosition.rotation;
                obj.SetActive(true);
                RightMuzzleFlash.Play();
                isFirePointLeft = true;
            }

            currentTime = 0f;

        }
    }

    void OnDisable()
    {
         LaserStatusController.CantShoot -= CheckLaserStatus;
    }
}
