using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace Pacman
{
    public class PacmanController : MonoBehaviour
    {
        public float speedMul = 5f;
        public UnityEvent<Collision> eatCoinEvent;
        public UnityEvent hitEvent;
        public WASD walk;
        public Shooting reload;
        public TMP_Text bulletNum;

        private void Start()
        {
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"OnCollisionEnter {collision.gameObject.name}");
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
                reload.ammo += 5;
                Destroy(collision.gameObject);
                bulletNum.text = ""+reload.ammo;
            }
        }
    }
}