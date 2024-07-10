using UnityEngine;

public enum CatEncounter
{
    CAT_01,
    CAT_02,
    CAT_03,
    CAT_04,
    CAT_05,
    CAT_11,
    CAT_12
}

public class TriggerAction : MonoBehaviour
{
    public CatEncounter Encounter;
    public Sprite newSprite;

    private bool isPlayerInTrigger = false;
    private bool _alreadyInteracted = false;
    private SpriteRenderer spriteRenderer;  

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            Debug.Log("Player entered the trigger area");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            Debug.Log("Player exited the trigger area");
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E) && !_alreadyInteracted)
        {
            GameEvents.CatEncounter(Encounter);
            PerformAction();
            _alreadyInteracted = true;
        }
    }

    private void PerformAction()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
            Debug.Log("Sprite changed!");
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite is not assigned");
        }
    }
}
