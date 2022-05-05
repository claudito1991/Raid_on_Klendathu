using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAudioHandler : MonoBehaviour
{
    public GameObject explosionSFX;

void OnDisable()
{
    explosionSFX.SetActive(true);
}
    
}
