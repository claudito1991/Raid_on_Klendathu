using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuShow : MonoBehaviour
{
    public GameObject menuJuego;
    public bool show;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            show = !show;
            menuJuego.SetActive(show);
        }
    }
}
