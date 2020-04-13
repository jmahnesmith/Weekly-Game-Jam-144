using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private float length, startposX;
    public GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        startposX = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startposX + dist, 2, transform.position.z);

        if (temp > startposX + length) startposX += length;
        else if (temp < startposX - length) startposX -= length;
    }
}
