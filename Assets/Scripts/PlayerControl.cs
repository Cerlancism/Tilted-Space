using UnityEngine;
using System.Collections;

//---------------------------------------------------------------------------------
// Author		: Chen Yu
// Date  		: 2017-07-01
// Description	: Controls the player movement and firing
//---------------------------------------------------------------------------------
public class PlayerControl : MonoBehaviour
{
    //===================
    // Public Variables
    //===================
    //Movement
    public enum ControlOption { ROLL, SLIDE };
    public ControlOption ControlType = ControlOption.ROLL;
    public float Speed;
    public float RollSpeed;
    public float SlideSpeed;

    //Firing
    public GameObject LaserBeam;
    public enum FireLevel {LEVEL1, LEVEL2, LEVEL3 };
    public FireLevel FirePower = FireLevel.LEVEL1;
    public float FireSpeed;


    //Additional Device Input
    public static bool Shaked;

    public CameraControl screenShake;

    //===================
    // Private Variables
    //===================
    private bool hasGyro = false;
    private Vector2 lerpPosition;
    private Vector2 origin = Vector2.zero;

    protected void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            hasGyro = true;
            Input.gyro.enabled = true;
            Input.gyro.updateInterval = 1f / 60f;
        }
        lerpPosition = transform.position;
        origin = Input.acceleration * 90;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        InvokeRepeating("Fire", 0, FireSpeed);
    }

    void Fire()
    {
        switch (FirePower)
        {
            case FireLevel.LEVEL1:
                Instantiate(LaserBeam, transform.position, Quaternion.identity);
                break;
            case FireLevel.LEVEL2:
                Instantiate(LaserBeam, new Vector2(transform.position.x - 0.1f, transform.position.y), Quaternion.identity);
                Instantiate(LaserBeam, new Vector2(transform.position.x + 0.1f, transform.position.y), Quaternion.identity);
                break;
            case FireLevel.LEVEL3:
                Instantiate(LaserBeam, new Vector2(transform.position.x - 0.1f, transform.position.y), Quaternion.identity);
                Instantiate(LaserBeam, new Vector2(transform.position.x + 0.1f, transform.position.y), Quaternion.identity);
                Instantiate(LaserBeam, new Vector2(transform.position.x - 0.3f, transform.position.y), Quaternion.identity);
                Instantiate(LaserBeam, new Vector2(transform.position.x + 0.3f, transform.position.y), Quaternion.identity);
                break;
            default:
                break;
        }
    }

    protected void Update()
    {
        Shaked = false;
        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 lerpScreenPosition = Camera.main.WorldToViewportPoint(lerpPosition);
        Vector2 gyroRotation = Vector2.zero;
        Vector2 accerleroRotation = ((Vector2)Input.acceleration * 90 - origin) * Speed;
        if (hasGyro)
        {
            if (Input.gyro.userAcceleration.magnitude > 0.5f)
            {
                Shaked = true;
            }
            if (Mathf.Abs(Input.acceleration.magnitude - 1) > 0.4f)
            {
                Shaked = true;
            }

            gyroRotation = Input.gyro.rotationRateUnbiased;
            lerpPosition.x = lerpPosition.x + gyroRotation.y * Speed;
            lerpPosition.y = lerpPosition.y + -gyroRotation.x * Speed / 9 * 16;
            //Checking with accelerometer for more accurate origin detection
            if (accerleroRotation.x < 1.5f && accerleroRotation.x > -1.5f &&
                accerleroRotation.y < 1.5f && accerleroRotation.y > -1.5f &&
                Mathf.Abs(Input.acceleration.x) < 0.5f && Mathf.Abs(Input.acceleration.y) < 0.5f &&
                Input.touchCount != 2)
            {
                lerpPosition = (lerpPosition + accerleroRotation) / 2;
            }

        }
        else
        {
            if (Mathf.Abs(Input.acceleration.magnitude - 1) > 0.4f)
            {
                Shaked = true;
            }
            if (Input.touchCount != 2)
            {
                lerpPosition = accerleroRotation;
            }
        }
        switch (ControlType)
        {
            case ControlOption.ROLL:
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
                        origin.x = origin.x - deltaPosition.x * 0.01f / Speed;
                        origin.y = origin.y - deltaPosition.y * 0.01f / Speed;
                    }
                }
                break;
            case ControlOption.SLIDE:
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
                    origin = Input.acceleration * 90;
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(lerpPosition, 0.1f);
    }

    protected void FixedUpdate()
    {
    }

    protected void OnDestroy()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
            screenShake.ShakeCamera(0.05f, 1);
            Handheld.Vibrate();
        }
    }
}