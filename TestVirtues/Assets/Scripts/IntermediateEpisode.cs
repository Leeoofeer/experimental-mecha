using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntermediateEpisode : MonoBehaviour
{
    SceneManagerr sceneManager;
    private SelectableOption[] options;
    [SerializeField]
    private GameObject disagreeButton;
    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        walkButton.SetActive(false);
        drinkButton.SetActive(false);
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr>();
        options = new SelectableOption[5];
        options[0] = new SelectableOption((new string[] { "you continued walkingTTTTTTTTTTTTTTTTTTTT", " ", "towards homeTTTTTTTTTTTTTTTTTTT" }), -2);
        options[1] = new SelectableOption(new string[] { "TTTTTTTTTTTTTTTTTTTTTyou decided to", " ", "TTTTTTTTTTTTTTTTTTTTTgo around the park" }, -1);
        options[2] = new SelectableOption(new string[] { "you decided to not grab the money that was", " ", "in and left the purse where it was" }, 0);
        options[3] = new SelectableOption(new string[] { "you decided to grab the purse and take it", " ", "to the nearby police station" }, +1);



        SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent2.Data = new string[] { "you have already experienced a decision", "taking in real life now lets once", "more give you some options", " ", "you reached the corner of the block" };
        sceneManagerComponent2.letter = sceneManager.letter;
        sceneManagerComponent2.cursor = sceneManager.cursor;
        sceneManagerComponent2.typeSound = sceneManager.typeSound;
        sceneManagerComponent2.endOfLineSound = sceneManager.endOfLineSound;
        sceneManagerComponent2.characters = sceneManager.characters;
        sceneManagerComponent2.showCursor = false;

        StartCoroutine(GiveOption());
        StartCoroutine(GiveOption2());
    }

    public void AgreeButton()
    {
        CreditKarma(options[newDialogueIndex].Karma);
    }

    int newDialogueIndex = 0;
    private void CreateDialogOption()
    {
        SceneManagerr sceneManagerComponent = gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent.Data = options[0].Data;
        sceneManagerComponent.letter = sceneManager.letter;
        sceneManagerComponent.cursor = sceneManager.cursor;
        sceneManagerComponent.typeSound = sceneManager.typeSound;
        sceneManagerComponent.endOfLineSound = sceneManager.endOfLineSound;
        sceneManagerComponent.characters = sceneManager.characters;
        sceneManagerComponent.startPos = new Vector2(-6.8f, -0.15f);
        sceneManagerComponent.showCursor = false;

    }

    private void CreateDialogOption2()
    {
        SceneManagerr sceneManagerComponent = gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent.startPos = new Vector2(-6.8f, -0.15f);
        sceneManagerComponent.Data = options[1].Data;
        sceneManagerComponent.letter = sceneManager.letter;
        sceneManagerComponent.cursor = sceneManager.cursor;
        sceneManagerComponent.typeSound = sceneManager.typeSound;
        sceneManagerComponent.endOfLineSound = sceneManager.endOfLineSound;
        sceneManagerComponent.characters = sceneManager.characters;

        sceneManagerComponent.showCursor = false;

    }

    public void CleanOption()
    {
        if (options.Length > 0)
        {
            var testComponent = gameObject.GetComponents<SceneManagerr>();
            var getLastComponent = testComponent[testComponent.Length - 1];
            StartCoroutine(CleanText(getLastComponent));
        }
        else
        {
            // disagreeButton.SetActive(false);
            disagreeButton.GetComponent<Button>().interactable = false;
            disagreeButton.GetComponent<Image>().enabled = false;
            text.text = "NO MORE OPTIONS!";
        }

    }
    public GameObject walkButton, drinkButton;
    IEnumerator GiveOption()
    {
        //(25);
        yield return new WaitForSeconds(18f);
        CreateDialogOption();
        yield return new WaitForSeconds(6f);
        walkButton.SetActive(true);
    }
    IEnumerator GiveOption2()
    {
        //(25);
        yield return new WaitForSeconds(25f);
        CreateDialogOption2();
        yield return new WaitForSeconds(5f);
        drinkButton.SetActive(true);
    }

    private IEnumerator CleanText(SceneManagerr sMc)
    {
        yield return new WaitForSeconds(0.1f);
        sMc.ClearText();
        yield return new WaitForSeconds(0.1f);
        Destroy(sMc);
        newDialogueIndex = 0;
        CreateDialogOption();
    }

    public void CreditKarma(int karma)
    {
        GameManager.Instance.AddKarma(karma);
    }
    int auxKarma;

    public int SelectRandomOption()
    {
        if (options.Length > 0)
        {
            int randomIndex = Random.Range(0, options.Length);
            auxKarma = options[randomIndex].Karma;

            if (options.Length <= 0)
            {
                // disagreeButton.SetActive(false);
                disagreeButton.GetComponent<Button>().interactable = false;
                disagreeButton.GetComponent<Image>().enabled = false;
                text.text = "NO MORE OPTIONS!";
            }
            return randomIndex;
        }
        else
        {
            Debug.LogWarning("No hay más opciones disponibles.");
            return -1;
        }
    }

    private void RemoveOption(int index)
    {
        List<SelectableOption> tempList = new List<SelectableOption>(options);
        tempList.RemoveAt(index);
        options = tempList.ToArray();
        var cursor = GameObject.Find("Cursor");
        Destroy(cursor);
    }

    public void LoadAbuse()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadPark()
    {
        SceneManager.LoadScene(5);
    }

}
