using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusic : MonoBehaviour
{
    public AudioSource First;
    public AudioSource Second;

    private float PlayTime;

    private void Start()
    {
        PlayTime = First.time;
        First.Play();
        StartCoroutine(WaitEnd());
    }

    private IEnumerator WaitEnd()
    {
        yield return new WaitForSeconds(PlayTime);
        Second.Play();
    }
}
