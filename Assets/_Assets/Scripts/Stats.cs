using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Stats")]
public class Stats : ScriptableObject
{
    [Header("PLAYER")]
    public LayerMask playerLayer;

    [Header("MOVEMENT")]
    [Range(120,480)]
    public float speed;
    
    //Gia toc
    public float acceleration = 120f;
    //Luc can
    public float deceleration = 30f;
    
}
