using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class instanceTowers : MonoBehaviour
{

    [SerializeField] private GameObject scriptObj;

    [SerializeField] public TMP_Text prixCanon1;
    [SerializeField] public TMP_Text prixCanon2;
    [SerializeField] public TMP_Text prixCanon3;
    // Start is called before the first frame update
    void Start()
    {
        prixCanon1.text = scriptObj.GetComponent<SpawnTower>().prixTour1.ToString() + "$";
        prixCanon2.text = scriptObj.GetComponent<SpawnTower>().prixTour2.ToString() + "$";
        prixCanon3.text = scriptObj.GetComponent<SpawnTower>().prixTour3.ToString() + "$";
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
