using ChatRoom.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private AvatarSettings avatarSettings;

    [SerializeField] private Sprite playerAvatarIcon;

    private void Start ()
    {
        OnLevelStart();
    }

    private void DisplayMessagePlayer(string message)
    {
        new MessageData
        {
            avatarIcon = playerAvatarIcon,
            Message = message,
            isSentByPlayer = true
        }.InvokeExtension();
    }

    private void DisplayMessage (Dialogue dialogue)
    {
        new MessageData
        {
            avatarIcon = avatarSettings.GetAvatarIcon(dialogue.dialogueOwner),
            Message = dialogue.dialogueText,
            isSentByPlayer = false
        }.InvokeExtension();
    }


    private void OnLevelStart ()
    {
        StartCoroutine(ProgressLevelForward());
    }

    private IEnumerator ProgressLevelForward ()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));

        foreach (Dialogue dialog in levelData.levelDialogueList)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));

            DisplayMessage(dialog);

            yield return new WaitForSeconds(Random.Range(1f, 2f));

            bool isResponseSelected = true;
            if(dialog.responsesList.Count > 0)
            {
                isResponseSelected = false;
                new PlayerResponseData
                {
                    responses = dialog.responsesList.ToArray(),
                    callback = (selectedResponse) =>
                    {
                        isResponseSelected = true;
                        DisplayMessagePlayer(selectedResponse.responseText);
                        // Inform karma manager about which response was selected
                        new OnResponseSelectedEvent { SelectedResponse = selectedResponse }.InvokeExtension();
                    }
                }.InvokeExtension();
            }

            yield return new WaitUntil(() => isResponseSelected);


        }

        yield return new WaitForSeconds(2);
        // Level Ends here - Invoke an event to let UI manager know to enable level pass/fail screen
        new OnLevelEndEvent().InvokeExtension();
    }
}
