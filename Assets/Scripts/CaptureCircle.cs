using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureCircle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ArrowEnemy arrow = collision.GetComponent<ArrowEnemy>();

        if (arrow != null)
        {
            if (arrow.good)
            {
                Quaternion rotation = Quaternion.LookRotation(transform.position - arrow.transform.position, arrow.transform.TransformDirection(Vector3.up));
                arrow.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

                arrow.transform.eulerAngles += new Vector3(0, 0, 180);

                arrow.Capture();
            }
        }
    }
}
