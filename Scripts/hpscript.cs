using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpscript : MonoBehaviour
{
    public Sword_Man Player;
    public Image nowHpbar;
    void Update()
    {
        nowHpbar.fillAmount = (float)Player.nowHp / (float)Player.maxHP;
    }
}
