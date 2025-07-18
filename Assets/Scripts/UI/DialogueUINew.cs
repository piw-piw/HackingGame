using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUINew : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueUI;

    [SerializeField]
    private Image characterImage;

    [SerializeField]
    private TMP_Text dialogueNameTextField;

    [SerializeField]
    private TMP_Text dialogueSentenceTextField;

    [SerializeField]
    private AudioSource dialogueAudioSource;

    [SerializeField]
    private GameObject nextSentenceHintText;

    private void Awake()
    {
        DialogueManagerNew.NewDialogueSentenceStarted += ShowDialogue;
        DialogueManagerNew.DialogueEnded += HideDialogue;
        DialogueManagerNew.OnCanStartNewSentence += SetNextSentenceHintActive;
        HideDialogue();
    }

    private void ShowDialogue(DialogueManagerNew.DialogueSentence dialogueStatement)
    {
        characterImage.sprite = dialogueStatement.Character.CharacterImage;
        dialogueNameTextField.text = dialogueStatement.Character.CharacterName;
        dialogueSentenceTextField.text = dialogueStatement.Sentence;
        dialogueUI.SetActive(true);

        dialogueAudioSource.clip = dialogueStatement.SentenceAudioClip;
        dialogueAudioSource.Play();
    }

    private void HideDialogue()
    {
        dialogueUI.SetActive(false);
    }

    private void SetNextSentenceHintActive(bool active)
    {
        nextSentenceHintText.SetActive(active);
    }
}