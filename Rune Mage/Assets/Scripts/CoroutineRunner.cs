using System.Collections;
using UnityEngine;


public class CoroutineRunner : MonoBehaviour
{
    public IEnumerator MonitorRunning(IEnumerator coroutine)
    {
        while (coroutine.MoveNext())
        {
            yield return coroutine.Current;
        }

        Destroy(gameObject);
    }
}
