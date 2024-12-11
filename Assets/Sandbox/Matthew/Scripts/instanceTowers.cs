using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanceTowers : MonoBehaviour
{

    [SerializeField] private GameObject scriptObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tour1(){
        scriptObj.GetComponent<SpawnTower>().numero = 1;
        Debug.Log("tour1");
    }

    public void Tour2(){
        scriptObj.GetComponent<SpawnTower>().numero = 2;
        Debug.Log("tour2");
    }

    public void Tour3(){
        scriptObj.GetComponent<SpawnTower>().numero = 3;
        Debug.Log("tour3");
    }
}
