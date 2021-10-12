using UnityEngine;


public class Zone : Interactable, IDamage, ILifeTime
{
    public float Damage { get; set; }
    public float LifeTime { get; set; }

    private void Start()
    {
        Object.Destroy(this.gameObject, LifeTime);
    }

    protected override void Interact(Collider other)
    {
        if (other.gameObject.GetComponent<Health>())
        {
            other.gameObject.GetComponent<Health>().RemoveHealth(Damage);
        }
    }
}
