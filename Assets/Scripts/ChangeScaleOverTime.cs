using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScaleOverTime : MonoBehaviour
{


public float lerpDuration = 10f; 
public float startValue = 0.5f; 
public float endValue = 3f; 
float valueToLerp;
public Vector3 objectScale;

public bool scalingCompleted;

//public Vector3 initialScale;
void Start()
{
    
    transform.localScale = new Vector3(1f,1f,1f);
    //initialScale = transform.localScale;
    //Debug.Log(initialScale);
}

void OnEnable()
{
    transform.localScale = new Vector3(1f,1f,1f);
    objectScale = transform.localScale;
    StartCoroutine(Lerp());
    scalingCompleted = false;
}
public IEnumerator Lerp()
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            //Debug.Log(timeElapsed);
            timeElapsed += Time.deltaTime;
            transform.localScale = new Vector3(objectScale.x*valueToLerp,  objectScale.y*valueToLerp, objectScale.z*valueToLerp);
            yield return null;
        }
        valueToLerp = endValue;
        scalingCompleted = true;
       
    }


    void OnDisable()
{
    objectScale = new Vector3(1f,1f,1f);
}

}


