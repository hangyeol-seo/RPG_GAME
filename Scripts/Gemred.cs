using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemred : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Sword_Man swordMan = col.GetComponent<Sword_Man>();
            swordMan.nowHp += 10;
            if (swordMan.nowHp > swordMan.maxHP)
                swordMan.nowHp = swordMan.maxHP;
            Destroy(gameObject);
        }
    }
}
