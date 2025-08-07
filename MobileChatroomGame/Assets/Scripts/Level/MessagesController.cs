using ChatRoom.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    [SerializeField] private LevelData levelData;

    private void Start ()
    {
        OnLevelStart();
    }

    private void DisplayMessage(string message, bool isSentByPlayer)
    {
        new MessageData
        {
            avatarIcon = null,
            Message = message,
            isSentByPlayer = isSentByPlayer
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

            DisplayMessage(dialog.dialogueText, false);

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
                        DisplayMessage(selectedResponse.responseText, true);
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
