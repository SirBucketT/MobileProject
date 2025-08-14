/*
 * This script will manage the status on UI items. 
 */

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ChatRoom.UI;

public class UiState : MonoBehaviour
{
   bool _openSettings, _onSubmenuCloser, _onPlayStart;

   void Start()
   {
      _openSettings = false; 
      _onSubmenuCloser = false; 
      _onPlayStart = false;
   }

   public void SettingsOpen()
   {
      _openSettings = !_openSettings;
      _onSubmenuCloser = false;
      SendUpdateUiMessage();
   }

   public void ContinuePlaying()
   {
      Debug.Log ("Player pressed continue button");
   }

   public void OpenPlay()
   {
      _onPlayStart = !_onPlayStart;
      _onSubmenuCloser = false;
      SendUpdateUiMessage();
   }

   public void SettingsClosed()
   {
      _onSubmenuCloser = !_onSubmenuCloser;
      _openSettings = false;
      _onPlayStart = false;
      SendUpdateUiMessage();
   }
   
   void SendUpdateUiMessage()
   {
      new UiUpdateMessage{OnSettingsOpen = _openSettings, 
         OnSubmenuClose = _onSubmenuCloser,
         OnPlayStarter = _onPlayStart}.InvokeExtension();
   }
}
