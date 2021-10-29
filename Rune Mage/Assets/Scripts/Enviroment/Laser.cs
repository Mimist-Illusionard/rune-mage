using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour, IExecute
{
    public Transform StartPoint;
    public Transform EndPoint;

    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        _lineRenderer.SetPosition(0, StartPoint.position);
        _lineRenderer.SetPosition(1, EndPoint.position);
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
