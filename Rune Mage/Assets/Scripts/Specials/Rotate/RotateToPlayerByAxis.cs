using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayerByAxis : MonoBehaviour, IExecute
{
    public Axiss axis;
    private Transform _target;
    private Vector3 vector;

    private void Start()
    {
        _target = GameObject.FindObjectOfType<Player>().transform;
        if (axis == Axiss.X) { vector = new Vector3(_target.position.x, _target.position.y, gameObject.transform.position.z); }
        else if (axis == Axiss.Y) { vector = new Vector3(_target.position.x, gameObject.transform.position.y, _target.position.z); }
        else if (axis == Axiss.Z) { vector = new Vector3(gameObject.transform.position.x, _target.position.y, _target.position.z); }
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        transform.LookAt(new Vector3(_target.position.x, gameObject.transform.position.y, _target.position.z));
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}

public enum Axiss
{
    X,
    Y,
    Z
}
