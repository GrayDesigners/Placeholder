using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(lookAt.position.x + offset.x, offset.y);

        //Camera move from start position to player position only in x-axis
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        new Vector3(lookAt.position.x + offset.x,offset.y);
    }
}
