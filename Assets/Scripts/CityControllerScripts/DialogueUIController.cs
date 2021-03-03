using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIController : MonoBehaviour
{
    private bool ifStartDialogue;
    private int currentSentence;
    private int currentWord;
    private string dialogueSentence;
    private bool isScrolling;
    [SerializeField]
    private float scrollingTime;
    private Coroutine ScrollingCoroutine;

    public Image characterImage;
    public Text dialogueText;
    CharacterDialogue dialogue;
    private void Awake()
    {
        ifStartDialogue = false;
    }


    void Update()
    {
        if(ifStartDialogue)
        {
            if(Input.anyKeyDown)
            {
                if(isScrolling)
                {
                    StopCoroutine(ScrollingCoroutine);
                    isScrolling = false;
                    dialogueSentence = dialogue.dialogueContent[currentSentence];
                }
                else
                {
                    if (currentSentence + 1 < dialogue.dialogueContent.Count)
                    {
                        currentSentence++;
                        currentWord = 0;
                        ScrollingCoroutine = StartCoroutine(ScrollingText());
                    }
                    else
                    {
                        EndDialogue();
                    }
                }
            }
            dialogueText.text = dialogueSentence;
        }
    }

    private IEnumerator ScrollingText()
    {
        dialogueSentence = "";
        isScrolling = true;
        foreach (var word in dialogue.dialogueContent[currentSentence].ToCharArray())
        {
            dialogueSentence += word;
            currentWord++;
            yield return new WaitForSeconds(scrollingTime);
        }
        isScrolling = false;
    }


    public void StartDialogue(CharacterDialogue _characterDialogue,int characterImageIndex)
    {
        dialogue = _characterDialogue;
        characterImage.sprite = Resources.Load<Sprite>("Image/Character/" + characterImageIndex.ToString());
        dialogueText.text = "";
        currentSentence = 0;
        currentWord = 0;
        gameObject.SetActive(true);
        ScrollingCoroutine = StartCoroutine(ScrollingText());
        ifStartDialogue = true;

    }

    private void EndDialogue()
    {
        StopCoroutine(ScrollingCoroutine);
        ifStartDialogue = false;
        gameObject.SetActive(false);
    }
}
