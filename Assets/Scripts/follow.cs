using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float YHeight = 0.0f;
    [SerializeField]
    private float ZDistance = -10.0f;


    private void Follow()
    {
       // transform.position = new Vector3(target.position.x, YHeight, target.position.z - ZDistance);
        transform.position = new Vector3(target.position.x, YHeight, ZDistance);

    }

    private void Update()
    {
        Follow();
    }
}