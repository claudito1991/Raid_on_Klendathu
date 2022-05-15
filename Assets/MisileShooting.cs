using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisileShooting : MonoBehaviour
{
    public GameObject misile;
    public bool isOverheated;



    void Start()
    {
    

    }

    void Update()
    {
        if (Input.GetMouseButton(1) && !isOverheated)
        {
            misile.SetActive(true);
            //Debug.Log("Shooted");
        }
    }

}
