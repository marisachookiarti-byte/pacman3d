using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Yarn.Unity;
using Random = UnityEngine.Random;

namespace Pacman
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        public int score = 0;
        public int maxCoin = 0;//-5
        public int maxCat = 1;

        public GameObject coin;
        public GameObject pac;
        public GameObject enemy;
        public GameObject magazine;
        public PacmanController pacman;
        [FormerlySerializedAs("textMeshPro")] public TMP_Text scoreTMP;
        public TMP_Text bulletTMP;

        public DialogueRunner dialogueRunner;
        public string[] node = { "A", "B", "C", "D", "E" };

        //private int[] spawns = { -10, -2, 5, 11 };

        public int level = 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            dialogueRunner.StartDialogue("Start");
            pacman.eatCoinEvent.AddListener(OnPacmanEatCoin);
            pacman.hitEvent.AddListener(OnEnemyHit);
            AdvanceLevel();
        }

        void AdvanceLevel()
        {
            if (level > 0)
            {
                SceneManager.LoadScene(level);
                return;
            }
            if (level < 2)
            {
                level++;
            }
            else
            {
                level = 0;
            }

            pac = GameObject.FindWithTag("player");
            pacman = pac.GetComponent<PacmanController>();
            scoreTMP = GameObject.Find("score").GetComponent<TMP_Text>();
            bulletTMP = GameObject.Find("ammo").GetComponent<TMP_Text>();
            dialogueRunner = GameObject.Find("Dialogue System").GetComponent<DialogueRunner>();

            score = 0;
            maxCoin += 5;
            pac.transform.Translate(0, 0, 0);
            dialogueRunner.StartDialogue(node[Random.Range(0, node.Length)]);
            for (int i = 0; i < maxCoin; i++)
            {
                Instantiate(coin, new Vector3(Random.Range(-12, 12), 1.5f, Random.Range(-12, 12)), pacman.transform.rotation);
            }
            for (int i = 0; i < maxCat++; i++)
            {
                Instantiate(enemy, new Vector3(Random.Range(-12, 12), 0f, Random.Range(-12, 12)), pacman.transform.rotation);
                Instantiate(magazine, new Vector3(Random.Range(-12, 12), .5f, Random.Range(-12, 12)), pacman.transform.rotation);
            }
        }


        private void OnPacmanEatCoin(Collision collision)
        {
            score++;
            Destroy(collision.gameObject);
            scoreTMP.text = score.ToString();
            
            if (score >= maxCoin)
            {
                AdvanceLevel();
            }
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