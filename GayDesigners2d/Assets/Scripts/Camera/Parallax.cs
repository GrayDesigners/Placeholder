using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //Declations available in editor
    [SerializeField] private Camera cam;
    [SerializeField] private Transform subject;

    //Declations unavailable in editor
    private Vector2 startPosition;
    private float startZ;
    private Vector2 travel => (Vector2)cam.transform.position - startPosition;

    private float distanceFromSubject => transform.position.z - subject.position.z;
    private float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));
    private float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    private void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        Vector2 newPosition = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startZ);
    }

}
