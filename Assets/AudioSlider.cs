using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour {


    public AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void SetVolume(float value)
    {
        source.volume = value;
    }


    // Update is called once per frame
    void Update ()
    {
		
	}


}
