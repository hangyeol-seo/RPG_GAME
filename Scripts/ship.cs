using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    public CameraFollow cams;
    public Sword_Man Theplayer;
    public Transform target;
    public Transform playertrans;
    public float smoothSpeed = 0.02f;
    public float maxposition = 10;
    public float speed;
    public float startpoint;
    public float lastpoint;
    private void Start()
    {
        cams = FindObjectOfType<CameraFollow>();
        Theplayer = FindObjectOfType<Sword_Man>();
        playertrans = Theplayer.transform;
        target = cams.transform;
        speed = 0.006f * smoothSpeed;
        startpoint = transform.position.x;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(maxposition, transform.position.y,transform.position.z);
        if (playertrans.position.x > 8 && transform.position.x < 75.6f)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
            lastpoint = transform.position.x - startpoint;
        }
    }
}
