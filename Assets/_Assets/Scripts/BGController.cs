using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    public GameObject playerPosition;
    

    private void Update()
    {
        transform.position = playerPosition.transform.position;
        Vector3 bgPosition = transform.position;
        bgPosition.y = 0;
        transform.position = bgPosition;
    }
}
