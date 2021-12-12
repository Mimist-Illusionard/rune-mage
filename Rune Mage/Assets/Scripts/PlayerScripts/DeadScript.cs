using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DeadScript : MonoBehaviour, IExecute
{
    public AudioMixer Mixer;

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        if (PlayerManager.Singleton.GetHealth().CurrentHealth <= 0)
        {
            Mixer.SetFloat("Master Volume", -80);
            gameObject.GetComponent<Image>().color += new Color(0, 0, 0, 1);
            if (gameObject.GetComponent<Image>().color.a >= 255)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
