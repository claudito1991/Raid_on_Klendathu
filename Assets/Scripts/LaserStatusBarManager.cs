using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserStatusBarManager : MonoBehaviour
{
    public Slider slider;
    public Image image;

    public float maxTemp;


    void Start()
    {
       // SetMaxTemp(maxTemp);
    }
    public  void SetMaxTemp(float temp)
    {
        slider.maxValue = temp;
        slider.value = temp;
    }

    public void SetTemp(float temp)
    {
        slider.value = temp;
        //Debug.Log("function called");
    }

    public void ImageColor( Color color)
    {
        image.color = color;
    }
}
