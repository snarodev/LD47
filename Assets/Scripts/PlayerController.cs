using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;

    public float circleRadius = 2.5f;

    public Transform circle;

    public Transform ghostCircle;

    float circleProgress = 0;

    int direction = 1;

    bool dead = false;
    bool finish = false;

    public GameObject deathEffects;
    public GameObject finishEffects;

    private void Start()
    {
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        deathEffects.SetActive(false);
        finishEffects.SetActive(false);
    }

    private void Update()
    {
        if (dead || finish)
            return;

        transform.position = new Vector3(circle.position.x + Mathf.Sin (circleProgress) * circleRadius,
                                         circle.position.y + Mathf.Cos (circleProgress) * circleRadius, 0);

        circleProgress += speed * Time.deltaTime * direction;

        ClampCircleProgress();

        Vector3 offset = transform.position - circle.position;


        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown (KeyCode.Space))
        {
            circle.position += offset * 2;
            offset = transform.position - circle.position;

            circleProgress += Mathf.PI;

            ClampCircleProgress();

            direction *= -1;
        }

        ghostCircle.position = circle.position + offset * 2;
    }

    void ClampCircleProgress()
    {
        if (circleProgress > Mathf.PI * 2)
            circleProgress -= Mathf.PI * 2;
        else if (circleProgress < 0)
            circleProgress += Mathf.PI * 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Death

            if (collision.GetComponent<ArrowEnemy>() != null && collision.GetComponent<ArrowEnemy>().good)
                return;

            StartCoroutine("DeathAnimation");

        }
        else if (collision.CompareTag("Finish"))
        {
            StartCoroutine("FinishAnimation");
        }
        else if (collision.CompareTag("CapturedArrow"))
        {
            collision.GetComponent<ArrowEnemy>().Reverse();
        }
    }

    IEnumerator DeathAnimation()
    {
        dead = true;
        deathEffects.SetActive(true);
        GetComponentInChildren<Cinemachine.CinemachineImpulseSource>().GenerateImpulse();
        yield return new WaitForSeconds(1f);
        
        LevelManager.controller.RestartCurrentLevel();
    }
    IEnumerator FinishAnimation()
    {
        finish = true;
        finishEffects.SetActive(true);
        yield return new WaitForSeconds(2);

        LevelManager.controller.ToLevelSelect();
    }
}
