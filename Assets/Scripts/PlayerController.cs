using UnityEngine;
using UnityEngine.Events;

namespace Pacman
{
    public class PacmanController : MonoBehaviour
    {
        public float speedMul = 5f;
        public UnityEvent<Collision> eatCoinEvent;
        public WASD walk;

        private void Start()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("coin"))
            {
                eatCoinEvent.Invoke(collision);
            }
        }
    }
}