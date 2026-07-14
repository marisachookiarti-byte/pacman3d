using Pacman;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent cat;
    public NavMeshAgent player;
    void Start()
    {
        cat.speed = Random.Range(1,3);
        player = Object.FindFirstObjectByType<NavMeshAgent>();
    }
    void Update()
    {
        cat.SetDestination(player.transform.position);
    }
}
