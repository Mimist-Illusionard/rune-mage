using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHardBul : Interactable, IExecute
{
    public GameObject Target;
    public float RotP;
    private float RotSpeed;
    public float Speed;
    public float Damage;
    public float TimeAIM;
    private bool AIM = true;

    public void Execute()
    {
        if (AIM) AIMing();
        gameObject.transform.position += transform.forward * Speed;
    }

    private void AIMing()
    {
        Vector3 direction = Target.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, RotSpeed * Time.deltaTime);
        RotSpeed += RotP;
    }

    void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
        StartCoroutine(AIMTiming());
        
    }

    protected override void OnEnter(Collider other)
    {
        if (other.GetComponent<Health>())
        { other.GetComponent<Health>().RemoveHealth(Damage);
        }
        DDD(); 
    }

    protected override void OnExit(Collider other)
    {
        
    }

    private void DDD()
    {

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }

    private IEnumerator AIMTiming()
    {
        yield return new WaitForSeconds(TimeAIM);
        AIM = false;
        Destroy(gameObject, 8f);
        Speed += 0.1f;
    }
}
