using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChatRoom.UI
{
    public class MessageData : IMessage
    {
        public string Message { get; set; }
        public Sprite avatarIcon;
        public bool isSentByPlayer;
    }
    public class PlayerResponseData : IMessage
    {
        public Response[] responses;
        public Action<Response> callback;
    }
    public class OnLevelStartData : IMessage
    {

    }
    public class OnResponseSelected : IMessage
    {
        public Response SelectedResponse;
    }
}
