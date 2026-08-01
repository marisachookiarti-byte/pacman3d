using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
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
        //public string[] node = { "A", "B", "C", "D", "E" };

        //private int[] spawns = { -10, -2, 5, 11 };

        public string currentLevel;

        [SerializeField] public List<string> levels;

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
            OnSceneLoaded(null);
        }

        void AdvanceLevel()
        {
            Debug.Log(currentLevel);
            var currentIndex = levels.FindIndex(l =>
            {
                //Debug.Log($"[AdvanceLevel] Searching levels index result={string.CompareOrdinal(l, currentLevel) == 0} l={l} currentLevel={currentLevel}");
                return string.CompareOrdinal(l, currentLevel) == 0;
            });
            
            int nextLevelIndex = currentIndex + 1;
            //Debug.Log($"[AdvanceLevel] currentIndex = {currentIndex} nextLevelIndex = {nextLevelIndex}");
            //Debug.Log($"[AdvanceLevel] levels.Count = {levels.Count} levels.Count >= nextLevelIndex = {levels.Count >= nextLevelIndex}");
            if (levels.Count <= nextLevelIndex) nextLevelIndex = 0;
            var op = SceneManager.LoadSceneAsync(levels[nextLevelIndex]);
            op.completed += OnSceneLoaded;
        }
        
        void ResetLevel()
        {
            var op = SceneManager.LoadSceneAsync(currentLevel);
            op.completed += OnSceneLoaded;

        }
        
        

        void OnSceneLoaded(AsyncOperation op)
        {
            currentLevel = SceneManager.GetActiveScene().name;
            
            //Debug.Log($"AdvanceLevel: finding references");
            pac = GameObject.FindWithTag("player");
            pacman = pac.GetComponent<PacmanController>();
            scoreTMP = GameObject.Find("score").GetComponent<TMP_Text>();
            bulletTMP = GameObject.Find("ammo").GetComponent<TMP_Text>();

            score = 0;
            maxCoin = 5;
            pac.transform.Translate(0, 0, 0);
            
            for (int i = 0; i < maxCoin; i++)
            {
                Instantiate(coin, new Vector3(Random.Range(-12, 12), 1.5f, Random.Range(-12, 12)), pacman.transform.rotation);
            }
            for (int i = 0; i < maxCat; i++)
            {
                Instantiate(enemy, new Vector3(Random.Range(-12, 12), 0f, Random.Range(-12, 12)), pacman.transform.rotation);
                Instantiate(magazine, new Vector3(Random.Range(-12, 12), .5f, Random.Range(-12, 12)), pacman.transform.rotation);
            }
            
            // Registering events
            pacman.eatCoinEvent.AddListener(OnPacmanEatCoin);
            pacman.hitEvent.AddListener(OnEnemyHit);
        }


        private void OnPacmanEatCoin(Collision collision)
        {
            score++;
            Destroy(collision.gameObject);
            scoreTMP.text = score.ToString();
            
            if (score >= maxCoin)
            {
                Console.Write("check1");
                AdvanceLevel();
            }
        }
        
        private void OnEnemyHit()
        {
            ResetLevel();
        }
    }

}