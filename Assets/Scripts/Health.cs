using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;

    public AudioSource sfxSource;
    public AudioClip meowSound;

    void Awake()
    {
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
            //colorChange(Color.red);
            //Invoke("colorChange", .1);
        }
    }
    //private void colorChange(Color c)
    //{
    //    GetComponent<MeshRenderer>().material.color = c;
    //}
    //private void colorChange()
    //{
    //    GetComponent<MeshRenderer>().material.color = Color.white;
    //}
    private void checkHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
