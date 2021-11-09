using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private List<IExecute> _executes = new List<IExecute>();
    private List<CancellationTokenSource> _cancellations = new List<CancellationTokenSource>();
    public static GameManager Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        Application.targetFrameRate = 100;
        AplicationStator();
    }

    private void Update()
    {
        for (var i = 0; i < _executes.Count; i++)
        {
            var updatable = _executes[i];
            updatable.Execute();
        }
    }

    public void AddExecuteObject(IExecute executeGameObject)
    {
        _executes.Add(executeGameObject);
    }

    public void RemoveExecuteObject(IExecute executeGameObject)
    {
        _executes.Remove(executeGameObject);
    } 

    public void ClearAllExecuteObjects()
    {
        _executes.Clear();
    }

    private void OnDestroy()
    {
        ClearAllExecuteObjects();
    }

    public CancellationTokenSource CreateCancellationTokenSource()
    {
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        _cancellations.Add(cancelTokenSource);
        return cancelTokenSource;
    }

    private async void AplicationStator()
    {
        
        while (true)
        {
            await Task.Yield();
            if (!Application.isPlaying)
            {
                break;
            }
        }
        foreach (var item in _cancellations)
        {
            item.Cancel();
            item.Dispose();
        }
        _cancellations.Clear();
    }
}
