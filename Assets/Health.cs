using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;

    public AudioSource sfxSource;
    public AudioClip meowSound;

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
            sfxSource.PlayOneShot(meowSound);
            Destroy(collision.gameObject);
        }
    }
}
