using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformByRayCast : MonoBehaviour
{

    private void Start()
    {
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, -gameObject.transform.up, out hit);
        gameObject.transform.position = hit.point;
    }

}
