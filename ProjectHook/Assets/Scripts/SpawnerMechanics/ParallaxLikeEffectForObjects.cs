using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLikeEffectForObjects : MonoBehaviour
{
    float startpos;
    GameObject cam;
    public float parallaxEffect;
    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        startpos = transform.position.y;
    }
    void Update()
    {
        float dist = (cam.transform.position.y * parallaxEffect);
        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);
    }
}
