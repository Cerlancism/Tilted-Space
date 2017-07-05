//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------------------------------
// Author		: XXX
// Date  		: 2015-05-12
// Modified By	: YYY
// Modified Date: 2015-05-12
// Description	: This is where you write a summary of what the role of this file.
//---------------------------------------------------------------------------------
public class ObjectPool : MonoBehaviour
{
    //===================
    // Public Variables
    //===================
    public GameObject pooledObject;

    public int pooledAmount;

    public List<GameObject> pooledObjects;

    //===================
    // Private Variables
    //===================

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
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(true);
            pooledObjects.Add(obj);
        }
    }

    //take a random object out of the pool
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        //return platform from pool
        GameObject obj = (GameObject)Instantiate(pooledObject);
        pooledObjects.Add(obj);
        return obj;
    }

    //---------------------------------------------------------------------------------
    // XXX is when blah blah
    //---------------------------------------------------------------------------------
    protected void Update()
    {

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
