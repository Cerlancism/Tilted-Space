using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{

    // === Public Variables ====



    // === Private Variables ====



    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length * 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
