using UnityEngine;


public class DestroyParticleAfterEnd : BaseOnStart
{
    public override void Logic()
    {
        ParticleSystem particle = gameObject.GetComponent<ParticleSystem>();
        Destroy(gameObject, particle.main.duration);
    }
}
