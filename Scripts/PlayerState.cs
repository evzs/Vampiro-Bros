using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    private Rigidbody2D rb;
    public HealthManager hm;
    public bool isHurt;
    public float hurtCooldown = 1.0f;
    public float lastHurtTime = -1.0f;
    private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isHurt) return;
        Debug.Log($"Collision detected at time: {Time.time}");
        switch (collision.gameObject.tag)
        {
           
            case "Trap":
                ProcessTrapCollision();
                break;

            default:
                ProcessEnemyCollision(collision.gameObject);
                break;
        }
    }

    private bool IsEnemy(GameObject obj)
    {
        Transform parent = obj.transform.parent;
        while (parent != null)
        {
            if (parent.name == "Enemies")
            {
                return true;
            }
            parent = parent.parent;
        }
        return false;
    }
    private void ProcessTrapCollision()
    {
        Die();
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        GameManager.Instance.GameOver();
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Dynamic;
        isHurt = false;
    }

    private void ProcessEnemyCollision(GameObject enemy)
    {
        if (Time.time - lastHurtTime < hurtCooldown) return;

        if (IsEnemy(enemy))
        {
            hm.TakeDamage(1);
            lastHurtTime = Time.time;

            Debug.Log($"Damage taken at time: {Time.time} | Current Health: {HealthManager.health}");

            if (!HealthManager.IsAlive())
            {
                Die();
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    IEnumerator GetHurt()
    {
        isHurt = true;
        Physics2D.IgnoreLayerCollision(3, 10);
        yield return new WaitForSeconds(hurtCooldown);
        Physics2D.IgnoreLayerCollision(3, 10, false);
        isHurt = false;
    }

}