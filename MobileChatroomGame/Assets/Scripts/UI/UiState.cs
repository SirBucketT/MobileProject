/*
 * This script will manage the status on UI items. 
 */

using UnityEngine;

public class UiState : MonoBehaviour
{
   [SerializeField] UIanimations animator;
   
   public void SettingsOpen()
   {
      animator.OpenSettings();
   }

   public void SettingsClosed()
   {
      animator.CloseSettings();
   }
}
