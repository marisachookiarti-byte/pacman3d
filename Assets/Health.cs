using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health--;
            Destroy(collision.gameObject);
        }
    }
}
