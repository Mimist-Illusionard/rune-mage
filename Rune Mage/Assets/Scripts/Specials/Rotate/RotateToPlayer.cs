using UnityEngine;


public class RotateToPlayer : MonoBehaviour, IExecute
{
    private Transform _target;

    private void Start()
    {
        _target = GameObject.FindObjectOfType<Player>().transform;

        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        if (!_target) return;
        transform.LookAt(_target);
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
