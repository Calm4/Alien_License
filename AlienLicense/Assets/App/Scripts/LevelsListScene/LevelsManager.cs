using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Scripts.LevelsListScene
{
    public class LevelsManager : MonoBehaviour
    {
        public static LevelsManager Instance { get; private set; }
    

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(Instance.gameObject);
                Instance = this;
            }
        }


        public void LoadLevel(int levelIndex )
        {
            SceneManager.LoadScene(levelIndex);
        }

        public void MarkLevelAsPassed(int levelIndex)
        {
            PlayerPrefs.SetInt("LevelPassed" + levelIndex, 1);
        }

        public bool IsLevelPassed(int levelIndex)
        {
            return PlayerPrefs.GetInt("LevelPassed" + levelIndex) == 1;
        }
    }
}