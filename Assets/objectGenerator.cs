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

    //set height change and max/min height
    private float MinHeight;
    private float Maxheight;
    public Transform maxHeightPoint;
    public float MaxHeightChange;
    private float heightChange;

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
    void Start()
    {
        ObjectWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            ObjectWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        MinHeight = transform.position.y;
        Maxheight = maxHeightPoint.position.y;

    }

    //---------------------------------------------------------------------------------
    // XXX is when blah blah
    //---------------------------------------------------------------------------------
    void Update()
    {
            if (transform.position.x < generationPoint.position.x)
            {
                //making selection of platforms vary in type and height
                distanceBetween = Random.Range(distancebetweenMin, distancebetweenMax);
                ObjectSelector = Random.Range(0, theObjectPools.Length);

                //setting max and min height
                heightChange = transform.position.y + Random.Range(MaxHeightChange, -MaxHeightChange);
                if (heightChange > Maxheight)
                {
                    heightChange = Maxheight;
                }
                else if (heightChange < MinHeight)
                {
                    heightChange = MinHeight;
                }

                GameObject newPlatform = theObjectPools[ObjectSelector].GetPooledObject();

                //set new platform position for respawn
                newPlatform.transform.position = transform.position;
                newPlatform.transform.rotation = transform.rotation;
                newPlatform.SetActive(true);

                transform.position = new Vector3(transform.position.x + (ObjectWidths[ObjectSelector] / 2) + distanceBetween, heightChange, transform.position.z);
            }
    }
}