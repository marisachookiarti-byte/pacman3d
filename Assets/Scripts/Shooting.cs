using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource sfxSource;
    public AudioClip bulletSound;
    
    public int ammo = 0;
    public TMP_Text bulletNum;

    public void Shoot(Ray shootingRay, Animator anim)
    {
        anim.SetBool("Shoot", true);
        sfxSource.PlayOneShot(bulletSound);
        RaycastHit hit;
        Physics.Raycast(shootingRay, out hit);
        var bul = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        bul.GetComponent<BulletShot>().Setup((hit.point - gameObject.transform.position).normalized);
        anim.SetBool("Shoot", false);
        ammo--;
        bulletNum.text =""+ammo;
    }
}
