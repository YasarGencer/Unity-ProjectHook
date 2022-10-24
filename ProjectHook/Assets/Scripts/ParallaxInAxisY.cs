using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxInAxisY : MonoBehaviour
{
    float startpos;
    public GameObject cam;
    public float parallaxEffect, length;
    private void Start()
    {
        startpos = transform.position.x;
    }
    private void Update()
    {
        float temp = (cam.transform.position.y * (1 - parallaxEffect));

        float dist = (cam.transform.position.y * parallaxEffect);
        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
