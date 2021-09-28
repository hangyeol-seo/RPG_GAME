using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mgr : MonoBehaviour
{
    public Sword_Man swordman;
    public CameraFollow cams;
    public void LoadGame()
    {
        swordman = FindObjectOfType<Sword_Man>();
        cams = FindObjectOfType<CameraFollow>();
        if(swordman && cams)
        {
            swordman.maxHP = 50;
            swordman.nowHp = 50;
            swordman.atkDmg = 4;
            swordman.jumpPower = 30;
            swordman.moveSpeed = 2;
            swordman.transform.position = new Vector3(-1, -1, 0);
            cams.transform.position = new Vector3(-1, -1, 0);
            SceneManager.LoadScene("Stage1");
        }
        else
            SceneManager.LoadScene("Initiate");
    }
}
