using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerShake : MonoBehaviour
{
    public CameraShake cameraShake;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }
}
