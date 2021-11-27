using UnityEngine;


public class RotateToPlayerAxisY : MonoBehaviour, IExecute
{
    private Transform _target;

    private void Start()
    {
        _target = GameObject.FindObjectOfType<Player>().transform;

        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        transform.LookAt(new Vector3(_target.position.x,gameObject.transform.position.y, _target.position.z));
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
