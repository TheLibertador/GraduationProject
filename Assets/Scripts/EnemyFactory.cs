using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject smallTroll;
    [SerializeField] private GameObject fastTroll;
    [SerializeField] private GameObject heavyTroll;
    [SerializeField] private GameObject earlTroll;
    [SerializeField] private GameObject kingTroll;


    public GameObject InstantiateTroll(string type, Transform instantiateZone)
    {
        switch (type)
        {
            case "smallTroll":
                return Instantiate(smallTroll, instantiateZone.position, Quaternion.identity);
            case "fastTroll":
                return Instantiate(fastTroll, instantiateZone.position, Quaternion.identity);
            case "heavyTroll":
                return Instantiate(heavyTroll, instantiateZone.position, Quaternion.identity);
            case "earlTroll":
                return Instantiate(earlTroll, instantiateZone.position, Quaternion.identity);
            case "kingTroll":
                return Instantiate(kingTroll, instantiateZone.position, Quaternion.identity);
            default:
                
                return null;

        }
        
    }


}
