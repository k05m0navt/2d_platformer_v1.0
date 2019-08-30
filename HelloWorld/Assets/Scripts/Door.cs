using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite open_door;
    private SpriteRenderer sr;

    void Start()
    {
        sr = gameObject.    GetComponent<SpriteRenderer>();
    }

    void checkCharacterKey()
    {
        if (Character.isKeyValue == true)
        {
            sr.sprite = open_door;
        }
    }

    void Update()
    {
        checkCharacterKey();
    }
}
