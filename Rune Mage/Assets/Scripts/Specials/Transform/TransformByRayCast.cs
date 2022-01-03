using UnityEngine;


public class TransformByRayCast : BaseOnStart
{
    public override void Logic()
    {
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, -gameObject.transform.up, out hit);
        gameObject.transform.position = hit.point;
    }
}
