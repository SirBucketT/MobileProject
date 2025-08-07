using ChatRoom.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChatRoom
{
    public class PostGameScreen : MonoBehaviour
    {
        [SerializeField] private GameObject container;
        [SerializeField] private GameObject nextLevelButton;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI headerText;
        

        private void OnEnable ()
        {
            Broker.Subscribe<ShowPostGameScreenEvent>(OnShow);
        }
        private void OnDisable ()
        {
            Broker.Unsubscribe<ShowPostGameScreenEvent>(OnShow);
        }
        private void OnShow (ShowPostGameScreenEvent data)
        {
            nextLevelButton.SetActive(data.isLevelPassed && data.nextLevelExists);
            headerText.text = data.isLevelPassed ? "Level Passed" : "Level Failed";
            scoreText.text = $"Score: {data.score}";

            container.SetActive(true);
        }

        public void RestartButton_OnClick ()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void NextLevelButton_OnClick ()
        {
            new LoadNextLevelEvent().InvokeExtension();
        }
        public void MainMenuButton_OnClick ()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
