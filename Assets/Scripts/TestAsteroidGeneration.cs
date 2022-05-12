using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAsteroidGeneration : MonoBehaviour
{
    public GameObject model;

    public Transform parent;

    public Transform planet;

    
    public int quantity;

    public int radio;

    bool sign;
    public List<Transform> asteroidsTransform = new List<Transform>();
    private float yPos;
    private float xPos;

    public float offsetInPlane=2f;

    private float xAngle;




    // Start is called before the first frame update
    void Start()
    {
        
        PopulateBelt();
    }

        private void PopulateBelt()
    {
          for (int i=0; i<quantity;i++)
        {

           // GameObject obj = Instantiate(model,Puntos3D(),Quaternion.identity,parent);  
            //asteroidsTransform.Add(obj.transform);
            GameObject obj = Instantiate(model,Puntos3D(),Quaternion.identity,parent);  
        }
        //parent.transform.parent = planet.transform;
    }
    public Vector3 Puntos3D()
    {
        xPos = UnityEngine.Random.Range(-radio, +radio);
        
        if(sign)
        {
         yPos = Mathf.Sqrt(Mathf.Pow(radio, 2)-Mathf.Pow(xPos, 2))*-1;       
        }
        else
        {
         yPos = Mathf.Sqrt(Mathf.Pow(radio, 2)-Mathf.Pow(xPos, 2));   
        }
        
        sign=!sign;

        Vector2 positionInPlane = Random2DOffset(xPos,yPos);
        Vector3 position3D = new Vector3(positionInPlane.x,RandomElevation(),positionInPlane.y);
        return position3D;
    }

    private Vector2 Random2DOffset(float xPos, float yPos)
    {

        float newxPos =xPos + UnityEngine.Random.Range(-offsetInPlane, +offsetInPlane);
        float newyPos = yPos + UnityEngine.Random.Range(-offsetInPlane, +offsetInPlane);

        return new Vector2(newxPos,newyPos);
    }

    private float RandomElevation()
    {
        float newPosz =UnityEngine.Random.Range(-offsetInPlane, offsetInPlane);
        return newPosz;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parent.position, 20f);
        Gizmos.color = Color.magenta;
    }

    void Update()
    {
        //parent.transform.position = planet.transform.position;

        transform.position = planet.transform.position;

    }


}
