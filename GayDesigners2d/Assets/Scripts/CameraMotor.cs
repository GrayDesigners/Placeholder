using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        float deltaX = lookAt.position.x - transform.position.x;
        float deltaY = lookAt.position.y - transform.position.y;
        transform.position += new Vector3(deltaX, deltaY, 0);
    }
}
