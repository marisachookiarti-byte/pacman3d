using System;
using Pacman;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
    public bool isEnabled = true;
    
    public NavMeshAgent cat;
    private NavMeshAgent _player;
    private Health _catHealth;

    void Awake()
    {
        _catHealth = GetComponent<Health>();
        _catHealth.onDeath.AddListener(onDeath);
    }
    
    void Start()
    {
        cat.speed = Random.Range(1,3);
        
        _player = GameController.Instance.pac.GetComponentInChildren<NavMeshAgent>();
    }

    private void OnDestroy()
    {
        _catHealth.onDeath.RemoveListener(onDeath);
    }

    void onDeath()
    {
        isEnabled = false;
        cat.enabled = false;
    }
    
    void Update()
    {
        if (!isEnabled) return;
        
        if (cat.isOnNavMesh)
        {
            cat.SetDestination(_player.transform.position);
        }
        else
        {
            if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            {
                cat.Warp(hit.position);
            }
        }
    }
    
    
}
