/*
 * This script will manage the status on UI items. 
 */

using UnityEngine;

public class UiState : MonoBehaviour
{
   bool _openSettings; 
   bool _onSubmenuCloser; 
   bool _onPlayStart;

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
   
   void SendUpdateUiMessage(){
      // Send UI Message to all scripts that are listening.
      // {beween brackets is your payload in where a bool opens or closes UI menu items on the main menu.}
      new UiUpdateMessage{OnSettingsOpen = _openSettings, 
         OnSubmenuClose = _onSubmenuCloser,
         OnPlayStarter = _onPlayStart}.InvokeExtension();
   }
}
