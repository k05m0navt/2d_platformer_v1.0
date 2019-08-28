using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Character.isKeyValue = true;
        Destroy(gameObject);
    }

}
