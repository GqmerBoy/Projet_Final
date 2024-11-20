using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;

    public float _health = 100;

    private GameObject _enemy;
    
    [SerializeField]
    private Material _color100;
    [SerializeField]
    private Material _color75;
    [SerializeField]
    private Material _color50;
    [SerializeField]
    private Material _color25;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindAnyObjectByType<ClickToMove>().transform;
        _enemy = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_player.position);
    }

    private void EnemyHealth()
    {
        if(_health < _health*0.75f)
        {
            Debug.Log(_health);
            _enemy.GetComponent<Renderer>().material = _color75;
        }
    }
}
