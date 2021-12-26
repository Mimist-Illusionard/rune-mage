using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateYDown : ISpecialAction
{
    public GameObject SpawnObj;

    public void StartAction(GameObject @object)
    {
        RaycastHit hit;
        Physics.Raycast(@object.transform.position, -@object.transform.up, out hit);
        var obj = Object.Instantiate(SpawnObj, null);
        obj.transform.position = hit.point;
    }
}
