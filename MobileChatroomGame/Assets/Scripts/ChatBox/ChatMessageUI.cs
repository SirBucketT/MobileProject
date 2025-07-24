using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChatRoom
{
    public class ChatMessageUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private LayoutElement messageTextLayoutElement;
        [SerializeField] private LayoutElement layoutElement;
        [SerializeField] private Image avatarIcon;
        [SerializeField] private RectTransform messageBg;
        [SerializeField] private float textBgPadding;
        [SerializeField] private float maxBubbleWidth;


        public void Initalize(string message)
        {
            messageText.text = message;
        }

        public void UpdateRects ()
        {
            if(messageText.rectTransform.sizeDelta.x > maxBubbleWidth)
            {
                messageTextLayoutElement.preferredWidth = maxBubbleWidth;
                Canvas.ForceUpdateCanvases();
            }

            float prefferredWidth = messageText.rectTransform.sizeDelta.x + textBgPadding;
            float prefferredHeight = messageText.rectTransform.sizeDelta.y + textBgPadding;

            messageBg.sizeDelta = new Vector2(prefferredWidth, prefferredHeight);
            //layoutElement.preferredWidth = prefferredWidth + avatarIcon.rectTransform.sizeDelta.x;
            layoutElement.preferredHeight = prefferredHeight;
        }
        public void UpdateParentWidth(float width)
        {
            layoutElement.preferredWidth = width;
        }
    }
}
