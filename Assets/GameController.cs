using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        private static GameController _instance;

        public int score = 0;
        public int maxCoin = 0;//-5

        public GameObject coin;
        public GameObject pac;
        public PacmanController pacman;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            pacman.eatCoinEvent.AddListener(OnPacmanEatCoin);
            AdvanceLevel();
        }

        void AdvanceLevel()
        {
            maxCoin += 5;
            pac.transform.Translate(0, 0, 0);
            for (int i = 0; i < maxCoin; i++)
            {
                Instantiate(coin, new Vector3(Random.Range(-12, 12), 1.5f, Random.Range(-12, 12)), pacman.transform.rotation);
            }

        }

        public void Update()
        {
            if (score >= maxCoin)
            {
                score = 0;
                AdvanceLevel();
            }
        }

        private void OnPacmanEatCoin(Collision collision)
        {
            score++;
            Destroy(collision.gameObject);
        }

        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}