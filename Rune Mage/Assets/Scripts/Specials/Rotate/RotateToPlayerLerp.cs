using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayerLerp : MonoBehaviour, IExecute
{

    private Transform Player;

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
        Player = PlayerManager.Singleton.GetPlayer().transform;
    }

    public void Execute()
    {
        var targetRotation = Quaternion.LookRotation(Player.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.01f);
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
