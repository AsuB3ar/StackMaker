using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingPlate : MonoBehaviour
{
    private const string PLUS_STACK = "PlusStack";
    private const string SUBTRACT_STACK = "SubtractStack";
    private const string STACKED = "Stacked";
 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trgger");
        if(other.CompareTag(PLUS_STACK))
        {
            other.gameObject.tag = STACKED;
            other.gameObject.layer = 0;
            PlayerScript.instance.PlusStack(other.gameObject);

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = other.gameObject.AddComponent<Rigidbody>();
            }
            
            rb.isKinematic = true;
            rb.useGravity = false;

            other.gameObject.AddComponent<StackingPlate>();
        }

        if(other.CompareTag(SUBTRACT_STACK))
        {
            Destroy(other);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ok");
    }
}
