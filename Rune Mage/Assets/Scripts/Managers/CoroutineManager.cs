using System.Collections;

using UnityEngine;


public class CoroutineManager : BaseSingleton<CoroutineManager>
{
    public static CoroutineManager Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }

    public CoroutineRunner RunCoroutine(IEnumerator coroutine)
    {
        var createdCorutine = new GameObject($"CorutineRunner: {coroutine}");
        DontDestroyOnLoad(createdCorutine);

        var runner = createdCorutine.AddComponent<CoroutineRunner>();

        runner.StartCoroutine(runner.MonitorRunning(coroutine));

        return runner;
    }   
}
