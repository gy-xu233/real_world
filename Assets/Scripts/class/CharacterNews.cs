using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNews
{
    public int characterIndex;
    public string newsContent;
    public int newsDay;

    public CharacterNews(int _characterIndex, string _newsContent,int _newsDay)
    {
        newsDay = _newsDay;
        characterIndex = _characterIndex;
        newsContent = _newsContent;
    }
}
