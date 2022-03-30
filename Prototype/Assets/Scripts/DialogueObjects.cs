using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObjects")]
public class DialogueObjects : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}
