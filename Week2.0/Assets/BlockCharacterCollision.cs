using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacterCollision : MonoBehaviour
{
    public CapsuleCollider2D CharacterCollider;
    public CapsuleCollider2D CharacterColliderBlocker;

    void Start()
    {
        Physics2D.IgnoreCollision(CharacterCollider, CharacterColliderBlocker,true);
    }
}
