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
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            sfxSource.PlayOneShot(bulletSound);
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            var bul = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            bul.GetComponent<BulletShot>().Setup((hit.point - gameObject.transform.position).normalized);
        }
    }
}
