using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    public float parallaxFactor = 0.5f;


    private void Update()
    { 
       
    }
    private void FixedUpdate()
    {
        Vector3 bgPosition = Camera.main.transform.position;
        bgPosition.y = 0;
        bgPosition.z = 0;
        transform.position = bgPosition;
    }
}
