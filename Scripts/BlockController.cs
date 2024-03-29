using System.Collections;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float bounceHeight = 0.5f;
    public float bounceSpeed = 4.0f;
    public Sprite emptyBlockSprite;
    public Sprite originalSprite;
    public GameObject crystalPrefab;
    public float crystalMoveSpeed = 8f;
    public float crystalMoveHeight = 3f;
    public float crystalFallDistance = 2f;

    private Vector2 originalPos;

    private bool canBounce = true;

    void Awake()
    {
       originalPos = transform.localPosition;

    }

    public void BlockBounce()
    {
        if (canBounce)
        {
            canBounce = false;
            StartCoroutine(Bounce());
        }
    }

 

    void Update()
    {
        
    }

    void ChangeSprite()
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = false;
        }
        GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
    }

    void PresentCrystal()
    {
        if (crystalPrefab != null)
        {
            GameObject crystal = Instantiate(crystalPrefab, transform.parent);
            crystal.transform.localPosition = new Vector2(originalPos.x, originalPos.y + 0.5f);
            StartCoroutine(MoveCrystal(crystal));

            Crystal crystalComponent = crystal.GetComponent<Crystal>();
            if (crystalComponent != null)
            {
                crystalComponent.Collect();
                crystalComponent.PlayCollectSound();
            }
        }
    }
    IEnumerator Bounce()
    {
        ChangeSprite();
        PresentCrystal();
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y >= originalPos.y + bounceHeight)
                break;
            yield return null;
        }

        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y <= originalPos.y)
            {
                transform.localPosition = originalPos;
                break;
            }

            yield return null;
        }
    }

    IEnumerator MoveCrystal(GameObject crystal)
    {
        while (true)
        {
            crystal.transform.localPosition = new Vector2(crystal.transform.localPosition.x, crystal.transform.localPosition.y + crystalMoveSpeed * Time.deltaTime);
            if (crystal.transform.localPosition.y >= originalPos.y + crystalMoveHeight + 0.5f)
                break;
            yield return null;
        }

        while (true)
        {
            crystal.transform.localPosition = new Vector2(crystal.transform.localPosition.x, crystal.transform.localPosition.y - crystalMoveSpeed * Time.deltaTime);
            if (crystal.transform.localPosition.y <= originalPos.y + crystalFallDistance + 0.5f)
            {
                crystal.transform.localPosition = new Vector2(crystal.transform.localPosition.x, originalPos.y + crystalFallDistance);
                Destroy(crystal.gameObject);
                break;
            }

            yield return null;
        }
    }

    public void ResetBlock()
    {
        canBounce = true;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = true;
        }

        spriteRenderer.sprite = originalSprite;
    }
}
