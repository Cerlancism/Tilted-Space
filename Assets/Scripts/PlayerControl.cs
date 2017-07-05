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
    public enum ControlOption { TiltRoll, TiltSlide };
    public ControlOption ControlType = ControlOption.TiltRoll;
    public float Speed;
    public float RollSpeed;
    public float SlideSpeed;

    //===================
    // Private Variables
    //===================
    private bool hasGyro = false;
    private Vector2 lerpPosition;

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
        lerpPosition = transform.position;
    }

    //---------------------------------------------------------------------------------
    // XXX is when blah blah
    //---------------------------------------------------------------------------------
    protected void Update()
    {
        if (hasGyro)
        {
            var gyroRotation = Input.gyro.rotationRateUnbiased;
            var screenPosition = Camera.main.WorldToViewportPoint(transform.position);
            var lerpScreenPosition = Camera.main.WorldToViewportPoint(lerpPosition);
            lerpPosition.x = lerpPosition.x + gyroRotation.y * Speed;
            lerpPosition.y = lerpPosition.y + -gyroRotation.x * Speed / 9 * 16;
            switch (ControlType)
            {
                case ControlOption.TiltRoll:
                    if (screenPosition.x > 0 && screenPosition.x < 1)
                    {
                        transform.position = Vector2.Lerp(transform.position, new Vector2(lerpPosition.x, transform.position.y), RollSpeed);
                    }
                    else if (lerpScreenPosition.x > 0 && lerpScreenPosition.x < 1)
                    {
                        transform.position = Vector2.Lerp(transform.position, new Vector2(lerpPosition.x, transform.position.y), RollSpeed);
                    }
                    if (screenPosition.y > 0 && screenPosition.y < 1)
                    {
                        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, lerpPosition.y), RollSpeed);
                    }
                    else if (lerpScreenPosition.y > 0 && lerpScreenPosition.y < 1)
                    {
                        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, lerpPosition.y), RollSpeed);
                    }
                    if (Input.touchCount == 2)
                    {
                        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);
                        if (Input.GetTouch(1).phase == TouchPhase.Moved)
                        {
                            Vector2 deltaPosition = Input.GetTouch(1).deltaPosition;
                            lerpPosition.x = lerpPosition.x + deltaPosition.x * 0.01f;
                            lerpPosition.y = lerpPosition.y + deltaPosition.y * 0.01f;
                        }
                    }
                    break;
                case ControlOption.TiltSlide:
                    if (Mathf.Abs(gyroRotation.x) < 0.1 && Mathf.Abs(gyroRotation.y) < 0.1 && (lerpPosition - Vector2.zero).magnitude < 1)
                    {
                        lerpPosition = Vector2.Lerp(lerpPosition, Vector2.zero, 0.05f);
                    }

                    if (screenPosition.x > 0 && screenPosition.x < 1)
                    {
                        transform.position = new Vector2(transform.position.x + lerpPosition.x * SlideSpeed, transform.position.y);
                    }
                    else
                    {
                        if (screenPosition.x < 0 && lerpPosition.x > 0)
                        {
                            transform.position = new Vector2(transform.position.x + lerpPosition.x * SlideSpeed, transform.position.y);
                        }
                        if (screenPosition.x > 1 && lerpPosition.x < 0)
                        {
                            transform.position = new Vector2(transform.position.x + lerpPosition.x * SlideSpeed, transform.position.y);
                        }
                    }

                    if (Input.touchCount == 2)
                    {
                        lerpPosition = Vector2.zero;
                    }

                    if (screenPosition.y > 0 && screenPosition.y < 1)
                    {
                        transform.position = new Vector2(transform.position.x, transform.position.y + lerpPosition.y * SlideSpeed);
                    }
                    else
                    {
                        if (screenPosition.y < 0 && lerpPosition.y > 0)
                        {
                            transform.position = new Vector2(transform.position.x, transform.position.y + lerpPosition.y * SlideSpeed);
                        }
                        if (screenPosition.y > 1 && lerpPosition.y < 0)
                        {
                            transform.position = new Vector2(transform.position.x, transform.position.y + lerpPosition.y * SlideSpeed);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(lerpPosition, 1);
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
