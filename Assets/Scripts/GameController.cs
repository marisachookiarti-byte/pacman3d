using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Yarn.Unity;

namespace Pacman
{
    public class GameController : MonoBehaviour
    {
        private static GameController _instance;

        public int score = 0;
        public int maxCoin = 0;//-5

        public GameObject coin;
        public GameObject pac;
        public GameObject enemy;
        public PacmanController pacman;
        public TMP_Text textMeshPro;

        public DialogueRunner dialogueRunner;
        public string[] node = { "A", "B", "C", "D", "E" };

        private int[] spawns = { -10, -2, 5, 11 };


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            pacman.eatCoinEvent.AddListener(OnPacmanEatCoin);
            pacman.hitEvent.AddListener(OnEnemyHit);
            AdvanceLevel();
        }

        void AdvanceLevel()
        {
            maxCoin += 5;
            pac.transform.Translate(0, 0, 0);
            for (int i = 0; i < maxCoin; i++)
            {
                Instantiate(coin, new Vector3(spawns[Random.Range(0,spawns.Length)], 1.5f, Random.Range(-12, 12)), pacman.transform.rotation);
            }
            Instantiate(enemy, new Vector3(spawns[Random.Range(0, spawns.Length)], 1.5f, Random.Range(-12, 12)), pacman.transform.rotation);
        }

        public void Update()
        {
            if (score >= maxCoin)
            {
                dialogueRunner.StartDialogue(node[Random.Range(0, node.Length)]);
                score = 0;
                AdvanceLevel();
            }
        }

        private void OnPacmanEatCoin(Collision collision)
        {
            score++;
            Destroy(collision.gameObject);
            textMeshPro.text = score.ToString();
        }
        private void OnEnemyHit()
        {
            Reset();
        }
        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}