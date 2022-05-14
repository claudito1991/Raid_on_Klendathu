using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject menuJuego;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
         CursorHide.EnableCursor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitApplication()
    {
        //Application.Quit();

        Screen.fullScreen = false;
    }

   
}
