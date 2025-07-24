using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChatRoom
{
    public class ChatControllerUI : MonoBehaviour
    {
        [SerializeField] private ChatMessageUI sentMessagePrefab;
        [SerializeField] private ChatMessageUI receivedMessagePrefab;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private TMP_InputField inputField;
        

        public void AddMessage (string message, bool isSentByUser)
        {
            var prefab = isSentByUser ? sentMessagePrefab : receivedMessagePrefab;
            var msgGO = Instantiate(prefab, scrollRect.content);

            msgGO.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, msgGO.GetComponent<RectTransform>().sizeDelta.y);

            msgGO.Initalize(message);

            //Debug.LogError(scrollRect.content.rect.width);
            //msgGO.UpdateParentWidth(scrollRect.content.rect.width);

            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f; // Scroll to bottom

            msgGO.UpdateRects();
        }

        public void UserMessageTest ()
        {
            AddMessage (inputField.text, true);
        }
        public void OtherMessageTest ()
        {
            AddMessage (inputField.text, false);
        }
    }
}
