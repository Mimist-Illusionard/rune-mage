using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAfterDead : ISpecialAction
{
    public List<GameObject> objects = new List<GameObject>();

    public void StartAction(GameObject @object)
    {
        foreach (GameObject bject in objects)
        {
           var a = Object.Instantiate(bject, null);
           a.transform.position = @object.transform.position;
        }
    }
}
