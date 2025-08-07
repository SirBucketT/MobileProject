using ChatRoom.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChatRoom
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int passScore = 2;
        [SerializeField] private int currentLevel;
        [SerializeField] private int maxLevels;

        private int currentScore;

        private void OnEnable ()
        {
            Broker.Subscribe<OnResponseSelectedEvent>(OnResponseSelected);
            Broker.Subscribe<OnLevelEndEvent>(OnLevelEnd);
            Broker.Subscribe<LoadNextLevelEvent>(OnLoadNextLevel);
        }

        

        private void OnDisable ()
        {
            Broker.Unsubscribe<OnResponseSelectedEvent>(OnResponseSelected);
            Broker.Unsubscribe<OnLevelEndEvent>(OnLevelEnd);
            Broker.Unsubscribe<LoadNextLevelEvent>(OnLoadNextLevel);
        }

        private void OnLevelEnd (OnLevelEndEvent data)
        {
            new ShowPostGameScreenEvent 
            { 
                score = currentScore, 
                isLevelPassed = currentScore >= passScore,
                nextLevelExists = currentLevel <= maxLevels
            }.InvokeExtension();
        }

        private void OnResponseSelected (OnResponseSelectedEvent data)
        {
            currentScore += data.SelectedResponse.responseValue;
        }
        private void OnLoadNextLevel (LoadNextLevelEvent data)
        {
            if (currentScore + 1 > maxLevels) return;
            SceneManager.LoadScene($"Level{currentLevel + 1}");
        }
    }
}
