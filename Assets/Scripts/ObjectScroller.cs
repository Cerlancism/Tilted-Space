//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO

using UnityEngine;
using System.Collections;

//---------------------------------------------------------------------------------
// Author		: XXX
// Date  		: 2015-05-12
// Modified By	: YYY
// Modified Date: 2015-05-12
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
public class ObjectScroller : MonoBehaviour
{

    private bool repeated = false;

    //randomise distance between objects
    private float distanceBetween;
    private float distancebetweenMin = -10;
    private float distancebetweenMax = 10;

    //randomise rotation of objects 
    private float tiltAngle;
    private float maxtiltAngle = 10;
    private float mintiltAngle = -10;


    //---------------------------------------------------------------------------------
    // protected mono methods. 
    // Unity5: Rigidbody, Collider, Audio and other Components need to use GetComponent<name>()
    //---------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------
    // Awake is when the file is just loaded ... for other function blah blah
    //---------------------------------------------------------------------------------
    protected void Awake()
    {
    }

    //---------------------------------------------------------------------------------
    // Start is when blah blah
    //---------------------------------------------------------------------------------
    protected void Start()
    {
        var euler = transform.eulerAngles;
        euler.z = Random.Range(-20f, 20f);
        transform.eulerAngles = euler;
    }

    //---------------------------------------------------------------------------------
    // XXX is when blah blah
    //---------------------------------------------------------------------------------
    protected void Update()
    {
        distanceBetween = Random.Range(distancebetweenMin, distancebetweenMax);
        tiltAngle = Random.Range(mintiltAngle, maxtiltAngle);
        transform.Translate(Vector2.down / Random.Range(15f, 20f));
        if (transform.position.y < -6 && repeated == false)
        {
            repeated = true;
            transform.position = new Vector3(transform.position.x / 2 + distanceBetween, transform.position.y, transform.position.z);
            GameObject replaced = Instantiate(gameObject, transform.position + (transform.up * 12.8f), transform.rotation);
            replaced.name = "BackgroundObject(Replaced)";
        }
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

    //---------------------------------------------------------------------------------
    // FixedUpdate for Physics update
    //---------------------------------------------------------------------------------
    protected void FixedUpdate()
    {
    }

    //---------------------------------------------------------------------------------
    // XXX is when blah blah
    //---------------------------------------------------------------------------------
    protected void OnDestroy()
    {
    }
}
