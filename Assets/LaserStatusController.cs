using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaserStatusController : MonoBehaviour
{
    public static Action<bool> CantShoot;
    public float currentLaserState;
    public float maxLaserTemperature;
    public float laserCoolingRate;
    public float laserHeatingRate;
    public bool LaserIsOverheated;

    public Material coolMaterial;
    public Material overheatedMaterial;

    public List<MeshRenderer> laserMaterials = new List<MeshRenderer>();

    public List<GameObject> overheatedLights = new List<GameObject>();

     public LaserStatusBarManager laserStatusBar;

    void Start()
    {
        laserStatusBar.SetMaxTemp(maxLaserTemperature);
        laserStatusBar.ImageColor(Color.blue);
    }

    void OnEnable()
    {
        PlayerShooting.PlayerShoots += HeatingProcess;
    }
    void Update()
    {
        laserStatusBar.SetTemp(currentLaserState);
        if(!LaserIsOverheated)
        {

            CoolingProcess();
            laserStatusBar.ImageColor(Color.blue);
        }

        else
        {
            StartCoroutine(OverheatedReaction());
        }

    }

    private void CoolingProcess()
    {
        if (currentLaserState > 0)
        {
            
            currentLaserState -= Time.deltaTime * laserCoolingRate;
        }
    }

    private void HeatingProcess()
    {
        if(currentLaserState<=maxLaserTemperature)
        {
            currentLaserState += laserHeatingRate;
        }

        if(currentLaserState > maxLaserTemperature)
        {
          
            CantShoot?.Invoke(true);
            VisualFeedBack(true);
            laserStatusBar.ImageColor(Color.red);
            LaserIsOverheated = true;
            currentLaserState = maxLaserTemperature;
        }
        
    }

    IEnumerator OverheatedReaction()
    {
        yield return new WaitForSeconds (2f);
        LaserIsOverheated=false;
        CantShoot?.Invoke(false);
        VisualFeedBack(false);
        currentLaserState = maxLaserTemperature * 0.7f;
    }

    void VisualFeedBack(bool state)
    {
        if(state)
        {
            foreach(GameObject light in overheatedLights)
            {
            light.SetActive(true);
            }
            foreach(MeshRenderer laser in laserMaterials)
            {
                laser.material = overheatedMaterial;
            }
        }
        else
        {
            foreach(GameObject light in overheatedLights)
            {
            light.SetActive(false);
            }
            foreach(MeshRenderer laser in laserMaterials)
            {
                laser.material = coolMaterial;
            }
        }

    }

    void OnDisable()
    {
        PlayerShooting.PlayerShoots -= HeatingProcess;
    }
}
