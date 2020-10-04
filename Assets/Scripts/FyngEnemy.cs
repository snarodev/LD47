using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FyngEnemy : MonoBehaviour
{
    public SpriteRenderer leftEye;
    public SpriteRenderer rightEye;

    public GameObject arrowEnemyPrefab;

    Vector3 leftEyeStartPos;
    Vector3 rightEyeStartPos;

    Vector3 targetOffset;

    Transform player;

    Vector3 startPos;

    private void Start()
    {
        leftEyeStartPos = leftEye.transform.localPosition;
        rightEyeStartPos = rightEye.transform.localPosition;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        startPos = transform.position;

        StartCoroutine("NewOffsetPosition");
        StartCoroutine("Angry");
    }

    private void Update()
    {
        leftEye.transform.localPosition = Vector3.Lerp(leftEye.transform.localPosition, leftEyeStartPos + targetOffset, 0.1f);
        rightEye.transform.localPosition = Vector3.Lerp(rightEye.transform.localPosition, rightEyeStartPos + targetOffset, 0.1f);

        transform.position = startPos + new Vector3(Mathf.Sin(Time.time), Mathf.Cos(Time.time));
    }

    IEnumerator NewOffsetPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));

            targetOffset = new Vector3(Random.Range(-0.2f, 0.1f), Random.Range(-0.2f, 0.1f));
        }
    }

    IEnumerator Angry()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));

            for (float i = 0; i < 1; i += Time.deltaTime * 0.5f)
            {
                leftEye.color = Color.Lerp(Color.white, Color.cyan, i);

                yield return 0;
            }

            GameObject go = Instantiate(arrowEnemyPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(go, 20);
            go = Instantiate(arrowEnemyPrefab, transform.position, Quaternion.Euler(0, 0, 45));
            Destroy(go, 20);
            go = Instantiate(arrowEnemyPrefab, transform.position, Quaternion.Euler(0, 0, 90));
            Destroy(go, 20);
            go = Instantiate(arrowEnemyPrefab, transform.position, Quaternion.Euler(0, 0, 135));
            Destroy(go, 20);
            go = Instantiate(arrowEnemyPrefab, transform.position, Quaternion.Euler(0, 0, 180));
            Destroy(go, 20);
            go = Instantiate(arrowEnemyPrefab, transform.position, Quaternion.Euler(0, 0, 225));
            Destroy(go, 20);
            go = Instantiate(arrowEnemyPrefab, transform.position, Quaternion.Euler(0, 0, 270));
            Destroy(go, 20);
            go = Instantiate(arrowEnemyPrefab, transform.position, Quaternion.Euler(0, 0, 315)); 
            Destroy(go, 20);



            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                leftEye.color = Color.Lerp(Color.cyan, Color.white, i);

                yield return 0;
            }
        }
    }
}
