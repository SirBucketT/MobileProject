using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChatRoom.UI
{
    public class PlayerResponseManager : MonoBehaviour
    {
        [SerializeField] private PlayerResponseUI responsePrefab;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private GameObject container;

        private Action<Response> callback;

        private void OnEnable ()
        {
            Broker.Subscribe<PlayerResponseData>(ShowResponses);
        }
        private void OnDisable ()
        {
            Broker.Unsubscribe<PlayerResponseData>(ShowResponses);
        }

        private void ShowResponses(PlayerResponseData responseData)
        {
            callback = responseData.callback;
            RemoveAllResponses();
            container.SetActive(true);
            foreach (var response in responseData.responses)
            {
                var msgGO = Instantiate(responsePrefab, scrollRect.content);

                msgGO.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, msgGO.GetComponent<RectTransform>().sizeDelta.y);

                msgGO.Initalize(response);
                msgGO.OnResponseSelected += OnResponseSelected;

                Canvas.ForceUpdateCanvases();
                scrollRect.verticalNormalizedPosition = 0f;

                msgGO.UpdateRects();
            }
            
        }
        private void RemoveAllResponses ()
        {
            for(int i = 0; i < scrollRect.content.childCount; i++)
            {
                Destroy(scrollRect.content.GetChild(i).gameObject);
            }
        }
        private void OnResponseSelected(Response response) 
        {
            callback?.Invoke(response);
            callback = null;
            container.SetActive(false);
        }
    }
}
