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

    public GameObject sc1, sc2, sc3, sc4, sc5, sc6, sc7;
    public GameObject cat1m, cat2m, cat3m, cat4m, cat5m, cat11m, cat12m;

    private void PerformAction()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            //spriteRenderer.sprite = newSprite;
            if (Encounter == CatEncounter.CAT_01)
            {
                sc1.SetActive(true);
                cat1m.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else if (Encounter == CatEncounter.CAT_02)
            {
                sc2.SetActive(true);
                cat2m.SetActive(true);
                this.gameObject.SetActive(false);

            }
            else if (Encounter == CatEncounter.CAT_03)
            {
                sc3.SetActive(true);
                cat3m.SetActive(true);
                this.gameObject.SetActive(false);

            }
            else if (Encounter == CatEncounter.CAT_04)
            {
                sc4.SetActive(true);
                cat4m.SetActive(true);
                this.gameObject.SetActive(false);

            }
            else if (Encounter == CatEncounter.CAT_05)
            {
                sc5.SetActive(true);
                cat5m.SetActive(true);
                this.gameObject.SetActive(false);

            }
            else if (Encounter == CatEncounter.CAT_11)
            {
                sc6.SetActive(true);
                cat11m.SetActive(true);
                this.gameObject.SetActive(false);

            }
            else if (Encounter == CatEncounter.CAT_12)
            {
                sc7.SetActive(true);
                cat12m.SetActive(true);
                this.gameObject.SetActive(false);

            }
            Debug.Log("Sprite changed!");
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite is not assigned");
        }
    }



}
