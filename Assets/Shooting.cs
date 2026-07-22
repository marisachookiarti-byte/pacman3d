using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Camera cam;

    public GameObject bullet;

    public AudioSource sfxSource;
    public AudioClip bulletSound;

    public Animator anim;

    public int ammo = 0;
    public TMP_Text bulletNum;
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame&&ammo>0)
        {
            anim.SetBool("Shoot", true);
            sfxSource.PlayOneShot(bulletSound);
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            var bul = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            bul.GetComponent<BulletShot>().Setup((hit.point - gameObject.transform.position).normalized);
            anim.SetBool("Shoot", false);
            ammo--;
            bulletNum.text =""+ammo;
        }
    }
}
