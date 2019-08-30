using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRestartGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (Character.isKeyValue == true)
        {
            Character.scoreAmount = 0;
            Character.isKeyValue = false;
            Application.LoadLevel("SampleScene");
        }
    }
}
