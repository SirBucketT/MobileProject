/*
 * This script will manage the status on UI items. 
 */

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class UiState : MonoBehaviour
{
   public UnityEvent onSettingsOpen;
   public UnityEvent onSubmenuClose;
   public UnityEvent onPlayStart;

   public void SettingsOpen()
   {
      onSettingsOpen?.Invoke();
   }

   public void OpenPlay()
   {
      onPlayStart?.Invoke();
   }

   public void SettingsClosed()
   {
      onSubmenuClose?.Invoke();
   }
}
