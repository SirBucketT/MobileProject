/*
 * This script will manage the status on UI items. 
 */

using UnityEngine;

public class UiState : MonoBehaviour
{
   private bool openSettings; 
   private bool onSubmenuCloser; 
   private bool onPlayStart;

   void Start()
   {
      openSettings = false; 
      onSubmenuCloser = false;
      onPlayStart = false;
   }

   public void SettingsOpen()
   {
      openSettings = !openSettings;
      onSubmenuCloser = false;
      SendUpdateUiMessage();
   }

   public void OpenPlay()
   {
      onPlayStart = !onPlayStart;
      onSubmenuCloser = false;
      SendUpdateUiMessage();
   }

   public void SettingsClosed()
   {
      onSubmenuCloser = !onSubmenuCloser;
      openSettings = false;
      onPlayStart = false;
      SendUpdateUiMessage();
   }
   
   void SendUpdateUiMessage(){
      // Send UI Message to all scripts that are listening.
      // {beween brackets is your payload in where a bool opens or closes UI menu items on the main menu.}
      new UiUpdateMessage{OnSettingsOpen = openSettings, 
         OnSubmenuClose = onSubmenuCloser,
         OnPlayStarter = onPlayStart}.InvokeExtension();
   }
}
