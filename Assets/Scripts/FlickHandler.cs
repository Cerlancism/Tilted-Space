using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using System;

public class FlickHandler : MonoBehaviour
{
    // === Public Variables ====


    // === Private Variables ====

    private void OnEnable()
    {
        GetComponent<FlickGesture>().Flicked += FlickHandle;
    }

    private void OnDisable()
    {
        GetComponent<FlickGesture>().Flicked -= FlickHandle;
    }

    private void FlickHandle(object sender, EventArgs e)
    {
        Debug.Log("Flicked");
        GameObject.Find("Player").GetComponent<PlayerControl>().FireRocket();
    }
}
