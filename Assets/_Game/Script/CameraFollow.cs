using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;
    public float value;

    private void LateUpdate()
    {
        Vector3 pos = followTarget.position + offset;

        transform.position = Vector3.Lerp(transform.position, pos, value*Time.deltaTime);
    }
}
