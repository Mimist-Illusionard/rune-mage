using System.Collections.Generic;


public class GameManager : BaseSingleton<GameManager>
{
    private List<IExecute> _executes = new List<IExecute>();

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
}
