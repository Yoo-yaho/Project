using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObjects testDialogue;

    private TypewriteEffect typewriteEffect;

    private void Start()
    {
        typewriteEffect = GetComponent<TypewriteEffect>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObjects dialogueObjects)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObjects));
    }

    private IEnumerator StepThroughDialogue(DialogueObjects dialogueObjects)
    {
        yield return new WaitForSeconds(2);

        foreach(string dialogue in dialogueObjects.Dialogue)
        {
            yield return typewriteEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
