using System.Collections;
using System.Collections.Generic;
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
        //[SerializeField] private TMP_InputField inputField;

        private void OnEnable ()
        {
            Broker.Subscribe<MessageData>(AddMessage);
        }
        private void OnDisable ()
        {
            Broker.Unsubscribe<MessageData>(AddMessage);
        }

        public void AddMessage (MessageData data)
        {
            var prefab = data.isSentByPlayer ? sentMessagePrefab : receivedMessagePrefab;
            var msgGO = Instantiate(prefab, scrollRect.content);

            msgGO.GetComponent<RectTransform>().sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, msgGO.GetComponent<RectTransform>().sizeDelta.y);

            msgGO.Initalize(data.Message);


            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;

            msgGO.UpdateRects();
        }

        //public void UserMessageTest ()
        //{
        //    AddMessage (inputField.text, true);
        //}
        //public void OtherMessageTest ()
        //{
        //    AddMessage (inputField.text, false);
        //}
    }
}
