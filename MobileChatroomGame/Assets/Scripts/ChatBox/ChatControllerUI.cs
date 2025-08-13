using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChatRoom.UI
{
    public class ChatControllerUI : MonoBehaviour
    {
        [SerializeField] private ChatMessageUI sentMessagePrefab;
        [SerializeField] private ChatMessageUI receivedMessagePrefab;
        [SerializeField] private ScrollRect scrollRect;

        // Player Response
        [SerializeField] private PlayerResponseUI responsePrefab;

        private Action<Response> callback;

        private List<GameObject> currentResponses;

        private float maxBubbleWidth;

        private void OnEnable ()
        {
            Broker.Subscribe<MessageData>(AddMessage);
            Broker.Subscribe<PlayerResponseData>(ShowResponses);
        }
        private void OnDisable ()
        {
            Broker.Unsubscribe<MessageData>(AddMessage);
            Broker.Unsubscribe<PlayerResponseData>(ShowResponses);
        }
        private void Start ()
        {
            maxBubbleWidth = scrollRect.content.rect.width / 1.5f;
            currentResponses = new List<GameObject>();
        }
        public void AddMessage (MessageData data)
        {
            var prefab = data.isSentByPlayer ? sentMessagePrefab : receivedMessagePrefab;
            var msgGO = Instantiate(prefab, scrollRect.content);

            msgGO.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, msgGO.GetComponent<RectTransform>().sizeDelta.y);

            msgGO.Initalize(data.Message, data.avatarIcon, maxBubbleWidth);


            Canvas.ForceUpdateCanvases();

            msgGO.UpdateRects();

            StartCoroutine(ScrollToEnd());
        }

        private IEnumerator ScrollToEnd ()
        {
            yield return null;
            scrollRect.verticalNormalizedPosition = 0f;
        }
        private void ShowResponses (PlayerResponseData responseData)
        {
            callback = responseData.callback;
            RemoveAllResponses();
            foreach (var response in responseData.responses)
            {
                var msgGO = Instantiate(responsePrefab, scrollRect.content);

                msgGO.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, msgGO.GetComponent<RectTransform>().sizeDelta.y);

                msgGO.Initalize(response, maxBubbleWidth);
                msgGO.OnResponseSelected += OnResponseSelected;

                Canvas.ForceUpdateCanvases();

                msgGO.UpdateRects();

                currentResponses.Add(msgGO.gameObject);

                StartCoroutine(ScrollToEnd());
            }

        }
        private void RemoveAllResponses ()
        {
            for (int i = 0; i < currentResponses.Count; i++)
            {
                Destroy(currentResponses[i]);
            }
            currentResponses.Clear();
        }
        private void OnResponseSelected (Response response)
        {
            RemoveAllResponses ();
            callback?.Invoke(response);
            callback = null;
        }
    }
}
