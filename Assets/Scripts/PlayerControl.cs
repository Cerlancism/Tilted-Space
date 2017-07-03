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
public class PlayerControl : MonoBehaviour
{
    //===================
    // Public Variables
    //===================
    public float Speed;

    //===================
    // Private Variables
    //===================
    private bool hasGyro = false;

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
        if (SystemInfo.supportsGyroscope)
        {
            hasGyro = true;
            Input.gyro.enabled = true;
        }
    }

    //---------------------------------------------------------------------------------
    // XXX is when blah blah
    //---------------------------------------------------------------------------------
    protected void Update()
    {
        if (true)
        {
            var gyroRotation = Input.gyro.rotationRateUnbiased;
            if (Mathf.Abs(gameObject.transform.position.x) <= 2.5)
            {
                if (Mathf.Abs(gyroRotation.x) > 0.1)
                {
                    gameObject.transform.Translate(Mathf.Sign(-gyroRotation.x) * Speed * Time.deltaTime, 0, 0);
                }
            }
            else
            {
                if (Mathf.Sign(gameObject.transform.position.x) == -1)
                {
                    gameObject.transform.Translate(0.01f, 0, 0);
                }
                else
                {
                    gameObject.transform.Translate(-0.01f, 0, 0);
                }
            }

            if (Mathf.Abs(gameObject.transform.position.y) <= 4.5)
            {
                if (Mathf.Abs(gyroRotation.y) > 0.1)
                {
                    gameObject.transform.Translate(0, Mathf.Sign(-gyroRotation.y) * Speed * Time.deltaTime, 0);
                }
            }
            else
            {
                if (Mathf.Sign(gameObject.transform.position.y) == -1)
                {
                    gameObject.transform.Translate(0, 0.01f, 0);
                }
                else
                {
                    gameObject.transform.Translate(0, -0.01f, 0);
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 touchPosition = Input.GetTouch(0).deltaPosition;
            Debug.Log(Camera.main.ScreenToWorldPoint(touchPosition).x);
            gameObject.transform.Translate(Camera.main.ScreenToWorldPoint(touchPosition).x + 2.8125f, Camera.main.ScreenToWorldPoint(touchPosition).y + 5f, 0);
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
