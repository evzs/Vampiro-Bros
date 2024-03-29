using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3;
    public int maxHearts = 3;
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private GameObject emptyHeartPrefab;

    void Awake()
    {
        health = maxHearts;
        DrawHearts();
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Max(health - damage, 0);
        DrawHearts();
        Debug.Log("Health decreased by " + damage + " / Current health: " + health);
    }

    public static bool IsAlive()
    {
        return health > 0;
    }

    public void DrawHearts()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHearts; i++)
        {
            GameObject heartPrefabSelection = (i + 1 <= health) ? heartPrefab : emptyHeartPrefab;
            GameObject heart = Instantiate(heartPrefabSelection, transform.position, Quaternion.identity);
            heart.transform.parent = transform;
        }

    }
    public void ResetHealth()
    {
        health = maxHearts;
        DrawHearts();
    }
}