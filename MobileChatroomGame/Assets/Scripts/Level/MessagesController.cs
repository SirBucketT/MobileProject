using ChatRoom.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MessagesController : MonoBehaviour
{
    private LevelData levelData;

    private void OnEnable ()
    {
        Broker.Subscribe<OnLevelStartData>(OnLevelStart);
    }
    private void OnDisable ()
    {
        Broker.Unsubscribe<OnLevelStartData>(OnLevelStart);
    }

    private void Start ()
    {
        levelData = LevelDataLoader.Instance.GetCurrenntLevelData();
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

    private void OnLevelStart (OnLevelStartData data)
    {
        StartCoroutine(ProgressLevelForward());
    }

    private IEnumerator ProgressLevelForward ()
    {


        yield return null;

        yield return new WaitForSeconds(Random.Range(1, 2));
        foreach (Dialogue dialog in levelData.levelDialogueList)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));

            DisplayMessage(dialog.dialogueText, false);

            yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));

            bool isResponseSelected = true;
            if(dialog.responsesList.Count > 0)
            {
                isResponseSelected = false;
                new PlayerResponseData
                {
                    responses = dialog.responsesList.ToArray(),
                    callback = (selectedResponse) =>
                    {
                        // Inform karma manager about which response was selected
                        isResponseSelected = true;
                        DisplayMessage(selectedResponse.responseText, true);
                    }
                }.InvokeExtension();
            }

            yield return new WaitUntil(() => isResponseSelected);


        }

        // Level Ends here - Invoke an event to let UI manager know to enable level pass/fail screen
    }
}
