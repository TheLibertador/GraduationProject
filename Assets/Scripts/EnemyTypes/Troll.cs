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
            if (currentTarget.CompareTag("Target") && newTarget.CompareTag("Player"))
            {
                return newTarget.transform;
            }
            if (currentTarget.CompareTag("Player"))
            {
                return currentTarget.transform;
            }

            if (newTarget.CompareTag("Player") && currentTarget.CompareTag("Building"))
            {
                return newTarget.transform;
            }
        }

        return currentTarget.transform;

    }

    protected void KillTroll(float health, GameObject itself)
    {
        if (health <= 0)
        {
            Destroy(itself);
            GameManager.Instance.numberOfActiveEnemies--;
        }
    }
    
    
}
