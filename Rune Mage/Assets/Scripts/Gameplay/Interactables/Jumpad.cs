using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpad : MonoBehaviour
{
    public float force;
    public Transform p;
    private void Jump(Rigidbody rb)
    {
       rb.AddForce(-(rb.gameObject.transform.position - p.position) * 3, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //other.gameObject.GetComponent<CharacterController>().enabled = false;
            //other.gameObject.GetComponent<CharacterController>().SimpleMove(-(other.gameObject.transform.position - p.position) * 1000);
            //Jump(other.gameObject.GetComponent<Rigidbody>());
            TransformEngine.CharasterControllerImpulse(other.gameObject, p.position, force);
           //StartCoroutine(tt(other.gameObject.GetComponent<CharacterController>()));
        }
    }

    IEnumerator tt(CharacterController c)
    {
        yield return new WaitForSeconds(1f);
        c.enabled = true;
    }
}
