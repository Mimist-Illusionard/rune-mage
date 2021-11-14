using System.Collections;
using UnityEngine;


public class CoroutineManager : MonoBehaviour
{
    public static CoroutineManager Singleton { get; private set; }

    private void Awake()
    {
        Singleton = this;
    }

    public Coroutine RunCoroutine(IEnumerator coroutine)
    {
        var createdCorutine = new GameObject($"CorutineRunner: {coroutine}");
        DontDestroyOnLoad(createdCorutine);

        var runner = createdCorutine.AddComponent<CoroutineRunner>();

        var corutine = runner.StartCoroutine(runner.MonitorRunning(coroutine));

        return corutine;
    }   
}
