using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //Declations unavailable in editor
    private float lenght, startpos;

    //Declations available in editor
    public GameObject cam;
    public float parallaxEffect; //how fost object will move (1 = stand still , 0 at the same speed as camera)

    private void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distance = (cam.transform.position.x * parallaxEffect);
        
        //making parallax effect
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

        //changing background position to make endless level effect
        if (temp > startpos + lenght)
            startpos += lenght;
        else if (temp < startpos - lenght)
            startpos -= lenght;
    }
}
