using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //camera following player effect
    public float damping = 1;
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;

    private Transform target;
    private float m_OffsetZ;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;
    private Vector3 m_LookAheadPos;

    //camera shake
    private float shakeTimer;
    private float shakeAmount;


    // Use this for initialization
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        m_LastTargetPosition = target.position;
        m_OffsetZ = (transform.position - target.position).z;
        transform.parent = null;
    }

    // Update is called once per frame
    private void Update()
    {
        // only update lookahead pos if accelerating or changed direction

        float xMoveDelta = (target.position - m_LastTargetPosition).x;

        //set camera look ahead and follow
        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

        if (transform.position.x > -4 && transform.position.x < 4 &&
            transform.position.y > -5 && transform.position.y < 5)
        {
            transform.position = newPos;
        }
        else
        {
            transform.position = newPos * 0.985f;
        }

        m_LastTargetPosition = target.position;

        if (shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
        }

    }

    public void ShakeCamera(float shakePower, float shakeDuration)
    {
        shakeAmount = shakePower;
        shakeTimer = shakeDuration;
    }
}
