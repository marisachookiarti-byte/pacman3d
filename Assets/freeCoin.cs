using Pacman;
using UnityEngine;
using UnityEngine.AI;

public class freeCoin : MonoBehaviour
{
    public NavMeshAgent obj;

    void Start()
    {
        if (!obj.isOnNavMesh)
        {
            if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            {
                obj.Warp(hit.position);
            }
        }
        Invoke("disable", 1);
    }
    private void disable()
    {
        obj.enabled = false;
    }
}
