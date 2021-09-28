using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemblue : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Sword_Man swordMan = col.GetComponent<Sword_Man>();
            swordMan.jumpPower *=1.3f;
            Destroy(gameObject);
        }
    }
}
