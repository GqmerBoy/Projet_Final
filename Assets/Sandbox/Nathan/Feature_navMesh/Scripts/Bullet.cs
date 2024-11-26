using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _tower;

    [SerializeField] private float _speed = 70f;

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

        Vector3 dir = _tower.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTower();
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTower()
    {
        //Debug.Log("TOUCHÉ");
        Destroy(gameObject);
    }
}
