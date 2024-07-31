using System.Collections;
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
            Debug.Log("Player interacted with the trigger area");
            GameEvents.CatEncounter(Encounter);
            PerformAction();
            _alreadyInteracted = true;
        }
    }

    public GameObject sc1, sc2, sc3, sc4, sc5, sc6, sc7;
    public GameObject cat1m, cat2m, cat3m, cat4m, cat5m, cat11m, cat12m;
    public GameObject bb1,bb2,bb3,bb4,bb5,bb11,bb12;
    public GameObject cb1, cb2, cb3, cb4, cb5;

    private void PerformAction()
    {
        if (Encounter == CatEncounter.CAT_11)
        {
            sc6.SetActive(true);
            StartCoroutine(DelayedActionSix());

        }
        else if (Encounter == CatEncounter.CAT_12)
        {
            sc7.SetActive(true);
            StartCoroutine(DelayedActionSeven());

        }
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite;
            if (Encounter == CatEncounter.CAT_01)
            {
                bb1.SetActive(true);
                cb1.SetActive(true);
                StartCoroutine(DelayedActionOne());
                
            }
            else if (Encounter == CatEncounter.CAT_02)
            {
                bb2.SetActive(true);
                cb2.SetActive(true);
                StartCoroutine(DelayedActionTwo());

            }
            else if (Encounter == CatEncounter.CAT_03)
            {
                bb3.SetActive(true);
                cb3.SetActive(true);
                StartCoroutine(DelayedActionThree());

            }
            else if (Encounter == CatEncounter.CAT_04)
            {
                bb4.SetActive(true);
                cb4.SetActive(true);
                StartCoroutine(DelayedActionFour());

            }
            else if (Encounter == CatEncounter.CAT_05)
            {
                bb5.SetActive(true);
                cb5.SetActive(true);
                StartCoroutine(DelayedActionFive());

            }
            
            Debug.Log("Sprite changed!");
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite is not assigned");
        }
    }

    private IEnumerator DelayedActionOne()
    {
        yield return new WaitForSeconds(3f);
        cb1.SetActive(false);
        bb1.SetActive(false);
        sc1.SetActive(true);
        cat1m.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private IEnumerator DelayedActionTwo()
    {
        yield return new WaitForSeconds(3f);
        cb2.SetActive(false);
        bb2.SetActive(false);
        sc2.SetActive(true);
        cat2m.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private IEnumerator DelayedActionThree()
    {
        yield return new WaitForSeconds(3f);
        cb3.SetActive(false);
        bb3.SetActive(false);
        sc3.SetActive(true);
        cat3m.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private IEnumerator DelayedActionFour()
    {
        yield return new WaitForSeconds(3f);
        cb4.SetActive(false);
        bb4.SetActive(false);
        sc4.SetActive(true);
        cat4m.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private IEnumerator DelayedActionFive()
    {
        yield return new WaitForSeconds(3f);
        cb5.SetActive(false);
        bb5.SetActive(false);
        sc5.SetActive(true);
        cat5m.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private IEnumerator DelayedActionSix()
    {
        yield return new WaitForSeconds(3f);
        sc6.SetActive(false);
    }

    private IEnumerator DelayedActionSeven()
    {
        yield return new WaitForSeconds(3f);
        sc7.SetActive(false);

    }

}
