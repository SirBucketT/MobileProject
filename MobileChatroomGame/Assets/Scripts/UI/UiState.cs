/*
 * This script will manage the status on UI items. 
 */

using UnityEngine;
using UnityEngine.Events;

public class UiState : MonoBehaviour
{
   [SerializeField] UiAnimations animator;
   
   public UnityEvent onSettingsOpen;
   public UnityEvent onSettingsClose;

   public void SettingsOpen()
   {
      onSettingsOpen?.Invoke();
   }

   public void SettingsClosed()
   {
      onSettingsClose?.Invoke();
   }
}
