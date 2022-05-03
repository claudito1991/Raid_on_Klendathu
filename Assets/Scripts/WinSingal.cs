using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WinSingal : MonoBehaviour
{
    public static Action winCondition;
    // Start is called before the first frame update
    public void Win()
    {
        winCondition?.Invoke();
    }
}
