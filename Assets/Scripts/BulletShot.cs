using UnityEngine;
using UnityEngine.Events;

public class BulletShot : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;

    public UnityEvent shotEnemyEvent;
    public void Setup(Vector3 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
