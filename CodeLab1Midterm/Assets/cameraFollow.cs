using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 cameraOffset;
    private Transform targetTransform;
    private bool _istargetTransformNull;

    void Start()
    {
        _istargetTransformNull = targetTransform == null;
        targetTransform = GameObject.FindWithTag("Player").transform;
        transform.position = targetTransform.position + new Vector3(2.5f, 2.5f, 0);
        transform.eulerAngles = new Vector3(120, 90,0);
        cameraOffset = transform.position - targetTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_istargetTransformNull)
            targetTransform = GameObject.FindWithTag("Player").transform;
        
        transform.position = targetTransform.position + cameraOffset;
    }
}
