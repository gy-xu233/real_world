﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterListRow : MonoBehaviour
{
    public Text characterName;
    public void setInformation(Character _character)
    {
        characterName.text = _character.CharacterName;
    }
}
