using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class initiating : MonoBehaviour
{
    public Sword_Man swordman;
    public CameraFollow cams;
    void Start()
    {
        swordman = FindObjectOfType<Sword_Man>();
        cams = FindObjectOfType<CameraFollow>();
        DontDestroyOnLoad(swordman.gameObject);
        swordman.maxHP = 50;
        swordman.nowHp = 50;
        swordman.atkDmg = 5;
        swordman.jumpPower = 30;
        swordman.moveSpeed = 2;
        swordman.transform.position = new Vector3(-1, -1, 0);
        cams.transform.position = new Vector3(-1, -1, 0);
        DontDestroyOnLoad(cams.gameObject);
        SceneManager.LoadScene("Stage1");
    }
}
