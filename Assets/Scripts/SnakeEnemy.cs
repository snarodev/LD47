using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SnakeEnemy : MonoBehaviour
{
    public float speed = 4;

    Transform[] snakeParts;

    private void Start()
    {
        snakeParts = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            snakeParts[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;

        for (int i = 0; i < snakeParts.Length; i++)
        {
            snakeParts[i].localPosition = new Vector3(i, Mathf.Lerp(0, Mathf.Sin(Time.time * 4 + i) * 0.5f,(float)i / (float)snakeParts.Length));
        }


    }
}
