using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform currentPoint;
    [SerializeField] private float speed;
    private Vector3 startPosition;

    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        currentPoint = pointB.transform;
    }

    void Update()
    {
       Vector2 point = currentPoint.position - transform.position;
       rb.velocity = (currentPoint == pointB.transform) ? new Vector2(speed, 0) : new Vector2(-speed, 0);
    
       currentPoint = (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform) ? pointA.transform : currentPoint;
       currentPoint = (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform) ? pointB.transform : currentPoint;

        Flip(point);
    }

    private void Flip(Vector2 direction)
    {
        if ((direction.x > 0 && !isFacingRight) || (direction.x < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    public void ResetEnemy()
    {
        gameObject.SetActive(true);
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        currentPoint = pointB.transform;
    }
}