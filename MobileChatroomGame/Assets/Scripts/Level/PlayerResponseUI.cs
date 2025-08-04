using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChatRoom.UI
{
    public class PlayerResponseUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private LayoutElement messageTextLayoutElement;
        [SerializeField] private LayoutElement layoutElement;
        [SerializeField] private RectTransform messageBg;
        [SerializeField] private float textBgPadding;
        [SerializeField] private float maxBubbleWidth;

        public event Action<Response> OnResponseSelected;

        private Response response;

        public void Initalize (Response response)
        {
            this.response = response;
            messageText.text = response.responseText;
        }

        public void UpdateRects ()
        {
            if (messageText.rectTransform.sizeDelta.x > maxBubbleWidth)
            {
                messageTextLayoutElement.preferredWidth = maxBubbleWidth;
                Canvas.ForceUpdateCanvases();
            }

            float prefferredWidth = messageText.rectTransform.sizeDelta.x + textBgPadding;
            float prefferredHeight = messageText.rectTransform.sizeDelta.y + textBgPadding;

            messageBg.sizeDelta = new Vector2(prefferredWidth, prefferredHeight);
            layoutElement.preferredHeight = prefferredHeight;
        }
        public void OnClicked ()
        {
            OnResponseSelected?.Invoke (response);
        }
    }
}
