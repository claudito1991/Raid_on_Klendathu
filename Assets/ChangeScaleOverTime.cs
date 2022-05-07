using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScaleOverTime : MonoBehaviour
{


float lerpDuration = 10f; 
float startValue = 0.01f; 
float endValue = 1f; 
float valueToLerp;
public Vector3 objectScale;
void Start()
{
    objectScale = transform.localScale;
    StartCoroutine(Lerp());
    
}
public IEnumerator Lerp()
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            Debug.Log(valueToLerp);
            timeElapsed += Time.deltaTime;
            transform.localScale = new Vector3(objectScale.x*valueToLerp,  objectScale.y*valueToLerp, objectScale.z*valueToLerp);
            yield return null;
        }
        valueToLerp = endValue;
       
    }
}
