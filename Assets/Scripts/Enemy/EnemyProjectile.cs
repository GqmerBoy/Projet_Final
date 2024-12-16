using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Transform _tower;

    [SerializeField] BulletSO bulletSO;
    [SerializeField] TowerSO towerSO;

    public void Seek(Transform _target){
        _tower = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(_tower == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _tower.position - transform.position; //La direction dans laquelle l'enemie tir
        float distanceThisFrame = bulletSO.vitesseDeplacement * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTower(); //Appel lorsque la distance entre le projectile et la tour est 0
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTower()
    {
        Destroy(gameObject); //Détruit le projectile lorsqu'il touche la tour
        towerSO.health -= bulletSO.dommages;
        return;
    }
}
