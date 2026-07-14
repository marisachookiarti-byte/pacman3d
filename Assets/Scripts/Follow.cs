using UnityEngine;

namespace Pacman
{
    public class Follow : MonoBehaviour
    {
        public GameObject player;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = player.transform.position + new Vector3(0,6,0);
        }
    }
}
