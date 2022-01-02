using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleAfterEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem particle = gameObject.GetComponent<ParticleSystem>();
        Destroy(gameObject, particle.duration);
    } 
}
