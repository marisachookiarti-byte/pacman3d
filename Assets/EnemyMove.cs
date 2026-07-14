using Pacman;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent cat;
    private NavMeshAgent _player;
    void Start()
    {
        cat.speed = Random.Range(1,3);
        
        _player = GameController.Instance.pac.GetComponentInChildren<NavMeshAgent>();
    }
    void Update()
    {
        if (_player != null)
        {
            cat.SetDestination(_player.transform.position);
        }
    }
}
