using System.Collections;

using UnityEngine;


public class CoroutineRunner : MonoBehaviour
{
    public IEnumerator MonitorRunning(IEnumerator coroutine)
    {
        Debug.LogWarning($"Monitoring Started: {coroutine}");

        while (coroutine.MoveNext())
        {
            yield return coroutine.Current;
        }

        Destroy(gameObject);
    }

    public void StopAllCorotines()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
