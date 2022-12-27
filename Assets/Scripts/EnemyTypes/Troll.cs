using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Troll : MonoBehaviour
{
    protected virtual Transform FindNearestEnemy(float radius, Transform currentTarget)
    {
        // Find all colliders within the radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        // Iterate over the colliders and retrieve the Transform component of each GameObject
        foreach (Collider collider1 in colliders)
        {
            Transform newTarget = collider1.gameObject.GetComponent<Transform>();
            if (currentTarget.CompareTag("Player"))
            {
                return currentTarget;
            }
            else if (newTarget.CompareTag("Player") && currentTarget.CompareTag("Building"))
            {
                return newTarget.transform;
            }
        }

        return currentTarget;

    }
    
    protected virtual void Walk()
    {
        Debug.Log("I walk");
    }

    protected virtual void Attack()
    {
        
    }
    
    
}
