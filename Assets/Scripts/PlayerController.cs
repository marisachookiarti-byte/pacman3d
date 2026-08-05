using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

namespace Pacman
{
    public class PacmanController : MonoBehaviour
    {
        public float speedMul = 5f;
        public UnityEvent<Collision> eatCoinEvent;
        public UnityEvent hitEvent;
        public WASD walk;

        public Shooting Shot;
        public Camera cam;
        public TMP_Text bulletNum;
        public int ammo = 100;
        public Animator anim;

        public void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame && ammo > 0)
            {
                Console.Write("clicked");
                Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                Shot.Shoot(ray, anim);
                ammo--;
                bulletNum.text = "" + ammo;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            //Debug.Log($"OnCollisionEnter {collision.gameObject.name}");
            if (collision.gameObject == null) return;
            if (collision.gameObject.CompareTag("coin"))
            {
                eatCoinEvent.Invoke(collision);
            }
            else if (collision.gameObject.CompareTag("enemy"))
            {
                hitEvent.Invoke();
            }
            else if (collision.gameObject.CompareTag("magazine"))
            {
                ammo += 5;
                Destroy(collision.gameObject);
                bulletNum.text = ""+ammo;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == null) return;
            if (other.gameObject.CompareTag("enemy"))
            {
                hitEvent.Invoke();
            }
        }
    }
}