using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInformationPanel : MonoBehaviour
{
    private Character character;
    public Image characterImage;
    public Text nameText;

    /// <summary>
    /// test code
    /// </summary>
    public GameObject tempGo;
    public Transform tempFather;
    private List<GameObject> relationCash;

    public GameObject tempGoInScroll;
    public ScrollRect tempScrollRect;
    private List<GameObject> messageCash;

    public void SetPanel(int _characterIndex)
    {
        character = GameManagerSingleton.GetInstance.characterList[_characterIndex];         
        characterImage.sprite = Resources.Load<Sprite>("Image/Character/" + character.characterImageIndex.ToString());
        nameText.text = character.CharacterName;
        RefreshRelationPanel();
        RefreshMessagePanel();
    }

    private void RefreshRelationPanel()
    {
        if (relationCash == null) relationCash = new List<GameObject>();

        List<ChacterRelationship> characterRelationList = character.chacterRelation;
        GameObject temporaryGo;
        int i;
        for (i = 0; i < characterRelationList.Count; i++)
        {
            if (i < relationCash.Count)
            {
                temporaryGo = relationCash[i];
            }
            else
            {
                temporaryGo = GameObject.Instantiate(tempGo, tempFather);
                relationCash.Add(temporaryGo);
            }
            temporaryGo.GetComponent<Text>().text = GameManagerSingleton.GetInstance.
                characterList[characterRelationList[i].characterIndex].CharacterName;
            temporaryGo.SetActive(true);
        }
        if (i < relationCash.Count)
        {
            for (; i < relationCash.Count; i++)
            {
                relationCash[i].SetActive(false);
            }
        }
    }
    private void RefreshMessagePanel()
    {
        if (messageCash == null) messageCash = new List<GameObject>();
        List<string> messageList = character.mailInCharacter;
        GameObject temporaryGo;
        int i;
        for (i = 0; i < messageList.Count; i++)
        {
            if (i < messageCash.Count)
            {
                temporaryGo = messageCash[i];
            }
            else
            {
                temporaryGo = GameObject.Instantiate(tempGoInScroll, tempScrollRect.content);
                messageCash.Add(temporaryGo);
            }
            temporaryGo.GetComponent<Text>().text = messageList[i];
            temporaryGo.SetActive(true);
        }
        if (i < messageCash.Count)
        {
            for (; i < messageCash.Count; i++)
            {
                messageCash[i].SetActive(false);
            }
        }
    }


   
}
