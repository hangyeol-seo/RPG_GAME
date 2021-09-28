using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    private float time=0;
    public string NextMapName;
    public Sword_Man swordman;
    public CameraFollow cams;
    void Update()
    {
        swordman = FindObjectOfType<Sword_Man>();
        cams = FindObjectOfType<CameraFollow>();
        swordman.transform.position = new Vector3(-0.5f, -1.5f, 0);
        cams.transform.position = new Vector3(-0.5f, -1.5f, 0);
        time += Time.deltaTime;
        if (time > 2.5f)
        {
            SceneManager.LoadScene(NextMapName);
        }

    }
}
