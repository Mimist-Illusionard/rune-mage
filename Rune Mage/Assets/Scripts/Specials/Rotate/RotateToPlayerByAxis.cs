using UnityEngine;


public class RotateToPlayerByAxis : MonoBehaviour, IExecute
{
    public AxisType axis;
    private Transform _target;
    private Vector3 vector;

    private void Start()
    {
        _target = GameObject.FindObjectOfType<Player>().transform;
        if (axis == AxisType.AxisX) { vector = new Vector3(_target.position.x, _target.position.y, gameObject.transform.position.z); }
        else if (axis == AxisType.AxisY) { vector = new Vector3(_target.position.x, gameObject.transform.position.y, _target.position.z); }
        else if (axis == AxisType.AxisZ) { vector = new Vector3(gameObject.transform.position.x, _target.position.y, _target.position.z); }
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
