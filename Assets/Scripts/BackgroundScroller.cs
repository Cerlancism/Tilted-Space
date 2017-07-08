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
public class BackgroundScroller : MonoBehaviour
{
    //===================
    // Public Variables
    //===================

    //===================
    // Private Variables
    //===================
    private bool repeated = false;
    private Vector2 skySize;

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
        skySize = GetMaxBounds(gameObject).size;
    }

    //---------------------------------------------------------------------------------
    // XXX is when blah blah
    //---------------------------------------------------------------------------------
    protected void Update()
    {
        transform.Translate(Vector2.down / 15 * Time.deltaTime * 60);
        if (Camera.main.WorldToViewportPoint(transform.position).y < 2.5 && repeated == false)
        {
            repeated = true;
            GameObject replaced = Instantiate(gameObject, transform.position + (transform.up * skySize.y), transform.rotation);
            replaced.name = "SkyBackground(Replaced)";
        }
        if (Camera.main.WorldToViewportPoint(transform.position).y  < -2.5f)
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

    private Bounds GetMaxBounds(GameObject g)
    {
        var b = new Bounds(g.transform.position, Vector3.zero);
        foreach (Renderer r in g.GetComponentsInChildren<Renderer>())
        {
            b.Encapsulate(r.bounds);
        }
        return b;
    }
}