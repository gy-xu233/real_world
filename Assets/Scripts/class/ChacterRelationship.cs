using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacterRelationship
{
    public enum RELATIONSHIP
    {
        FRIEND,
        ENEMY
    }

    public int characterIndex;
    public RELATIONSHIP relation;

    public ChacterRelationship(int _characterIndex, RELATIONSHIP _relation)
    {
        characterIndex = _characterIndex;
        relation = _relation;
    }
}
