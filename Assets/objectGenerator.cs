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
public class objectGenerator : MonoBehaviour
{
    //===================
    // Public Variables
    //===================
    public ObjectPool[] theObjectPools;

    public GameObject Object;
    public Transform generationPoint;
    public float distanceBetween;

    //set distance between platform
    public float distancebetweenMin;
    public float distancebetweenMax;

    //public GameObject[] selection;
    private int ObjectSelector;
    private float[] ObjectWidths;

    //===================
    // Private Variables
    //===================
    private bool repeated = false;
    private float ObjectWidth;


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
        ObjectWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            ObjectWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

    }

    //---------------------------------------------------------------------------------
    // XXX is when blah blah
    //---------------------------------------------------------------------------------
    protected void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            //making selection of platforms vary in type and height
            distanceBetween = Random.Range(distancebetweenMin, distancebetweenMax);
            ObjectSelector = Random.Range(0, theObjectPools.Length);

            GameObject newObject = theObjectPools[ObjectSelector].GetPooledObject();

            transform.position = new Vector3(transform.position.x + (ObjectWidths[ObjectSelector]) + distanceBetween, transform.position.y, transform.position.z);

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