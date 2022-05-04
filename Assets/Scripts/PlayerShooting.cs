using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float coolDownTime = 0.2f;
      public float currentTime;
    public float currentLaserState;
    public float maxLaserTemperature = 30f;
    public float laserCoolingRate;
    public float laserHeatingRate;
    public bool LaserIsOverheated;

    public LaserStatusBarManager laserStatusBar;
    public Transform LeftFirePointPosition;
    public Transform RightFirePointPosition;

    public ParticleSystem LeftMuzzleFlash;
    
    public ParticleSystem RightMuzzleFlash;

    public bool isFirePointLeft;
    // Start is called before the first frame update
    void Start()
    {
        laserStatusBar.SetMaxTemp(maxLaserTemperature);
        laserStatusBar.ImageColor(Color.blue);
    }

    // Update is called once per frame
    void Update()
    {
        laserStatusBar.SetTemp(currentLaserState);
        
        if(currentLaserState >= maxLaserTemperature)
        {
            currentLaserState = maxLaserTemperature;
            StartCoroutine(LaserOverheated());
            
        }

        else
        {
            PlayerFiringProcess();
            laserStatusBar.ImageColor(Color.blue);
            Debug.Log("Cooling");
            currentLaserState -= Time.deltaTime * laserCoolingRate;

            if(currentLaserState < 0)
            {
                currentLaserState = 0;
            }
        }

        
        Debug.Log(currentLaserState);
    }

    private void PlayerFiringProcess()
    {
        currentTime += Time.deltaTime;
        if (currentTime > coolDownTime && Input.GetMouseButton(0))
        {

            currentLaserState+=laserHeatingRate;
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

    IEnumerator LaserOverheated()
    {
        Debug.Log("Overheated");
        laserStatusBar.ImageColor(Color.magenta);
        yield return new WaitForSeconds(2f);
        currentLaserState = maxLaserTemperature * 0.5f;
    }
    
}
