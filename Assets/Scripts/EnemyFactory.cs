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


    public GameObject InstantiateTroll(string type)
    {
        switch (type)
        {
            case "smallTroll":
                return Instantiate(smallTroll);
                break;
            case "fastTroll":
                return Instantiate(fastTroll);
                break;
            case "heavyTroll":
                return Instantiate(heavyTroll);
                break;
            case "earlTroll":
                return Instantiate(earlTroll);
                break;
            case "kingTroll":
                return Instantiate(kingTroll);
                break;
            default:
                
                return null;

        }
        
    }


}
