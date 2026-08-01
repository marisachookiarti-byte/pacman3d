using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;

    public AudioSource sfxSource;
    public AudioClip meowSound;

    public Material skin;
    public Rigidbody rb;

    void Awake()
    {
        //skin = new Material(skin);
        sfxSource.mute = false;
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            health--;
            sfxSource.PlayOneShot(meowSound);
            Destroy(collision.gameObject);
            checkHealth();
            colorChange(Color.red);
            Invoke("colorChange", .1f);
        }
    }
    private void colorChange(Color c)
    {
        skin.color = c;
    }
    private void colorChange()
    {
        skin.color = Color.white;
    }
    private void checkHealth()
    {
        if (health <= 0)
        {
            colorChange(Color.blueViolet);
            while (transform.position.y<5) {
                Console.Write("floating");
                transform.position += transform.up*Time.deltaTime;
            }
            Destroy(gameObject);
        }
    }
}
