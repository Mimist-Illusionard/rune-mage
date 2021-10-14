using System.Threading;
using System.Threading.Tasks;

using UnityEngine;


public class TestAsync : MonoBehaviour
{    
    private void Start()
    {
        var waitOneSecondTokenSource = CreateCancellationTokenSource();
        var waitSixtyFramesTokenSource = CreateCancellationTokenSource();
        var whatTaskFasterTokenSource = CreateCancellationTokenSource();

        WaitOneSecond(waitOneSecondTokenSource.Token);
        WaitSixtyFrames(waitSixtyFramesTokenSource.Token);

        WhatTaskFasterAsync(whatTaskFasterTokenSource.Token, WaitOneSecond(waitOneSecondTokenSource.Token), WaitSixtyFrames(waitSixtyFramesTokenSource.Token));
    }

    private CancellationTokenSource CreateCancellationTokenSource()
    {
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();        

        return cancelTokenSource;
    }

    private async Task WaitOneSecond(CancellationToken token)
    {
        Debug.LogError("Start WaitOneSecond Task");
        await Task.Delay(1000);
        Debug.LogError("End WaitOneSecond Task");        
    }

    private async Task WaitSixtyFrames(CancellationToken token)
    {
        Debug.LogWarning("Start WaitSixtyFrames Task");
        var framesCount = 0;
        while (framesCount <= 60)
        {
            if (token.IsCancellationRequested)
            {
                Debug.LogWarning("WaitSixtyFrames end becouse token");
                break;
            }

            await Task.Yield();
            framesCount += 1;

            Debug.LogWarning($"WaitSixtyFrames. Frame(s):{framesCount}");
        }

        Debug.LogWarning("End WaitSixtyFrames Task");
        return;
    }

    private async Task<bool> WhatTaskFasterAsync(CancellationToken token, Task task1, Task task2)
    {
        Debug.Log("What task faster Start");
        while (true)
        {
            if (token.IsCancellationRequested)
            {
                Debug.LogError("WhatTaskFasterAsync ended by token");
                return false;
            }

            if (task1.IsCompleted)
            {
                Debug.Log($"Task1 is complete: {task1.IsCompleted}");
                task2.Dispose();
                return task1.IsCompleted;
            }

            if (task2.IsCompleted)
            {
                Debug.Log($"Task2 is complete: {task2.IsCompleted}");
                task1.Dispose();
                return task2.IsCompleted;
            }

            await Task.Yield();
        }
    }
}
