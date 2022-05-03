using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailReset : MonoBehaviour
{
    public TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponentInChildren<TrailRenderer>();
    }

    void OnDisable()
    {
        tr.Clear();
    }
}
