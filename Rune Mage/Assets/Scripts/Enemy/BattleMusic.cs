using System.Collections;
using UnityEngine;


public class BattleMusic : MonoBehaviour
{
    public AudioSource First;
    public AudioSource Second;

    private float PlayTime;

    private void Start()
    {
        PlayTime = First.clip.length;
        First.Play();
        StartCoroutine(WaitEnd());
    }

    private IEnumerator WaitEnd()
    {
        yield return new WaitForSeconds(PlayTime);
        Second.Play();
    }
}
