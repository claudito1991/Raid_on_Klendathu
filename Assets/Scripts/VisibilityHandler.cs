using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityHandler : MonoBehaviour
{
    void OnBecameInvisible()
    {
         enabled = false;
    }

    private void OnBecameVisible() {
         enabled = true;
    }
}
