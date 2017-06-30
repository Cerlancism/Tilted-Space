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

    }
	
	//---------------------------------------------------------------------------------
	// XXX is when blah blah
	//---------------------------------------------------------------------------------
	protected void Update() 
	{
        transform.Translate(Vector2.down / 10);
        if (transform.position.y < -2.5 && repeated == false)
        {
            repeated = true;
            GameObject replaced = Instantiate(gameObject, transform.position + (transform.up * 12.8f), transform.rotation);
            replaced.name = "SkyBackground(Replaced)";
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
