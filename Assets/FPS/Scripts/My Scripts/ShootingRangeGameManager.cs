using UnityEngine;
using System.Collections.Generic;

namespace AG3953
{
    public class ShootingRangeGameManager : MonoBehaviour
    {
        public static ShootingRangeGameManager Instance;

        public int totalHits = 0;
        public int requiredHitsToWin = 5;
        public float gameDuration = 30f; // 30 seconds to shoot
        private float timer;

        private List<Character> spectators = new List<Character>();

        private bool gameEnded = false;
        private bool gameStarted = false; // To track if the game has started

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            // Find all spectators in scene automatically
            spectators.AddRange(FindObjectsByType<Character>(FindObjectsSortMode.None));
        }

        private void Update()
        {
            if (gameEnded || !gameStarted)
                return;

            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                EndGame();
            }
        }

        // Call this method to start the game
        public void StartGame()
        {
            if (gameStarted) return; // Prevent starting the game multiple times
            gameStarted = true;
            timer = gameDuration;
            Debug.Log("Game Started!");
        }

        public void RegisterHit()
        {
            totalHits++;
            Debug.Log($"Total hits: {totalHits}");
        }

        private void EndGame()
        {
            gameEnded = true;

            bool didWin = totalHits >= requiredHitsToWin;

            foreach (var spectator in spectators)
            {
                if (didWin)
                    spectator.Cheer();
                else
                    spectator.Boo();
            }

            Debug.Log("Game ended! " + (didWin ? "You won!" : "You lost!"));
        }
    }
}
