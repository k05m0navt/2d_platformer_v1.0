using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelChange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (Character.isKeyValue == true)
        {
            Application.LoadLevel("Level2");
            Character.isKeyValue = false;
        }
    }
}
