using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AfterEpisode : MonoBehaviour
{
    SceneManager sceneManager;
    private SelectableOption[] options;
    [SerializeField]
    private GameObject disagreeButton;
    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        options = new SelectableOption[5];
        options[2] = new SelectableOption(new string[] { "you decided to cover his shift tonight", " ", "and not go out for drinks" }, -2);
        options[0] = new SelectableOption(new string[] { "you decide to tell your boss that you", " ", "want to take your coworker shift" }, -1);
        options[1] = new SelectableOption(new string[] { "you told your coworker that you cant", " ", "and you head to the bar" }, 0);        
        options[3] = new SelectableOption(new string[] { "you suggest your coworker to tell your", " ", "boss to not do the shift" }, +1);
        options[4] = new SelectableOption(new string[] { "you helped your coworker to finish his", " ", "pending work so he leaves early" }, +2);


        SceneManager sceneManagerComponent2 = this.gameObject.AddComponent<SceneManager>();
        sceneManagerComponent2.Data = new string[] { "you finish working and decided to go out", " ", "for drinks with your coworkers ", " ", "then a colleague ask you to cover", " ", "his nightshift tonight", " " };
        sceneManagerComponent2.letter = sceneManager.letter;
        sceneManagerComponent2.cursor = sceneManager.cursor;
        sceneManagerComponent2.typeSound = sceneManager.typeSound;
        sceneManagerComponent2.endOfLineSound = sceneManager.endOfLineSound;
        sceneManagerComponent2.characters = sceneManager.characters;
        sceneManagerComponent2.showCursor = false;

        StartCoroutine(GiveOption());

    }

    public void AgreeButton()
    {
        CreditKarma(options[newDialogueIndex].Karma);
    }

    int newDialogueIndex = 0;
    private void CreateDialogOption()
    {
        SceneManager sceneManagerComponent = gameObject.AddComponent<SceneManager>();
        newDialogueIndex = SelectRandomOption();
        sceneManagerComponent.Data = options[newDialogueIndex].Data;
        sceneManagerComponent.letter = sceneManager.letter;
        sceneManagerComponent.cursor = sceneManager.cursor;
        sceneManagerComponent.typeSound = sceneManager.typeSound;
        sceneManagerComponent.endOfLineSound = sceneManager.endOfLineSound;
        sceneManagerComponent.characters = sceneManager.characters;
        sceneManagerComponent.startPos = new Vector2(0f, -0.15f);
        sceneManagerComponent.showCursor = false;
        RemoveOption(newDialogueIndex);

    }

    public void CleanOption()
    {
        if (options.Length > 0)
        {
            var testComponent = gameObject.GetComponents<SceneManager>();
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

    IEnumerator GiveOption()
    {
        //(25);
        yield return new WaitForSeconds(20f);
        CreateDialogOption();
    }

    private IEnumerator CleanText(SceneManager sMc)
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


}
