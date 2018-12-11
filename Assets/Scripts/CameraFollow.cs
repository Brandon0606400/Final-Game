using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTarget;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (followTarget != null)
        {
            Vector3 newPosition = followTarget.position;
            newPosition.z = transform.position.z;
            transform.position = newPosition;

        }
    }
}
