using UnityEngine;
using System.Collections;

public class UpAndDownMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float upHeight = 2f;
    public float holdDuration = 1f;
    void Start()
    {
        StartCoroutine(MoveEnemy());
    }

    IEnumerator MoveEnemy()
    {
        while (true)
        {
            // move up
            float startTime = Time.time;
            Vector3 startPos = transform.position;
            while (Time.time - startTime < upHeight / moveSpeed)
            {
                transform.position = Vector3.Lerp(startPos, startPos + Vector3.up * upHeight, (Time.time - startTime) * moveSpeed);
                yield return null;
            }

            // hold position
            yield return new WaitForSeconds(holdDuration);

            // move down
            startTime = Time.time;
            startPos = transform.position;
            while (Time.time - startTime < upHeight / moveSpeed)
            {
                transform.position = Vector3.Lerp(startPos, startPos - Vector3.up * upHeight, (Time.time - startTime) * moveSpeed);
                yield return null;
            }
        }
    }
}