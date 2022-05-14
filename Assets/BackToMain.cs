using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMain : MonoBehaviour
{
    public GameObject instructionMenu;
    public GameObject title;
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMainMenu()
    {
        instructionMenu.SetActive(false);
        mainMenu.SetActive(true);
        title.SetActive(true);
    }
}
