using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health = 3;

    public AudioSource sfxSource;
    public AudioClip meowSound;

    public Material skin;
    public Rigidbody rb;
    public Collider attackCollider;

    public UnityEvent onDeath;

    void Awake()
    {
        if (skin != null)
        {
            Material sharedSkin = skin;
            skin = new Material(sharedSkin);

            foreach (Renderer renderer in GetComponentsInChildren<Renderer>(true))
            {
                Material[] materials = renderer.sharedMaterials;
                for (int i = 0; i < materials.Length; i++)
                {
                    if (materials[i] == sharedSkin)
                        materials[i] = skin;
                }
                renderer.sharedMaterials = materials;
            }
        }
        sfxSource.mute = false;
        
        attackCollider.GetComponent<Collider>();
            
        onDeath.AddListener(catFloatOnDeath);
        onDeath.AddListener(() => colorChange(Color.blueViolet));

    }

    private void OnDestroy()
    {
        if (skin != null)
            Destroy(skin);
    }
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter object={other.gameObject.name}");

        if (!other.CompareTag("bullet"))
            return;

        health--;
        sfxSource.PlayOneShot(meowSound);
        Destroy(other.gameObject);

        if (checkHealth())
            catColorBlink(Color.red, 0.1f);
    }
    
    private void colorChange(Color c)
    {
        skin.color = c;
    }
    private void colorChange()
    {
        skin.color = Color.white;
    }
    
    private bool checkHealth()
    {
        if (health <= 0)
        {
            onDeath.Invoke();
            return false;
        }

        return true;
    }

    private async void catFloatOnDeath()
    {
        rb.useGravity = false;
        
        
        float startingY = transform.position.y;
        float endingY = startingY + 5;
        //Debug.Log($"catFloatOnDeath startingY={startingY} endingY={endingY}");

        while (transform.position.y < endingY) {
            //Debug.Log($"catFloatOnDeath whileLoop transform.position.y= {transform.position.y} {transform.position.y < endingY} = transform.position.y < endingY");

            transform.position += transform.up * Time.deltaTime;
            await Task.Yield();
        }
        
        Destroy(gameObject);
    }
    
    private async void catColorBlink(Color c, float waitTimeSecond)
    {
        colorChange(Color.red);
        await Awaitable.WaitForSecondsAsync(waitTimeSecond);
        colorChange();
    }
}
