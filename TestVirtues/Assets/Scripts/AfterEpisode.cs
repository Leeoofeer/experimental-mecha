using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class AfterEpisode : MonoBehaviour
{
    SceneManagerr sceneManager;
    private List<SelectableOption> options;
    [SerializeField]
    private GameObject disagreeButton;
    [SerializeField]
    private GameObject agreeButton;
    [SerializeField]
    private TextMeshProUGUI text;

    void Start()
    {
        disagreeButton.SetActive(false);
        agreeButton.SetActive(false);
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr>();
        options = new List<SelectableOption>
        {
            new SelectableOption(new string[] { "you decided to cover his shift tonight", " ", "and not go out for drinks" }, -2),
            new SelectableOption(new string[] { "you decide to tell your boss that you", " ", "want to take your coworker shift" }, -1),
            new SelectableOption(new string[] { "you told your coworker that you cant", " ", "and you head to the bar" }, 0),
            new SelectableOption(new string[] { "you suggest your coworker to tell your", " ", "boss to not do the shift" }, +1),
            new SelectableOption(new string[] { "you helped your coworker to finish his", " ", "pending work so he leaves early" }, +2)
        };

        SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr>();
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
        if (newDialogueIndex >= 0 && newDialogueIndex < options.Count)
        {
            int karma = options[newDialogueIndex].Karma;
            CreditKarma(karma);
            RemoveOption(newDialogueIndex);
            LoadSceneBasedOnKarma(karma);
        }
        else
        {
            if (newDialogueIndex <= 0)
            {
                int karma = auxOptions.Karma;
                CreditKarma(karma);
                LoadSceneBasedOnKarma(karma);
            }
            Debug.LogWarning("newDialogueIndex is out of range.");
        }
    }

    private void LoadSceneBasedOnKarma(int karma)
    {
        string sceneName = "";

        switch (karma)
        {
            case -2:
                sceneName = "AfterVeryBadOpt";
                break;
            case -1:
                sceneName = "AfterBadOpt";
                break;
            case 0:
                sceneName = "AfterNeutralOpt";
                break;
            case 1:
                sceneName = "AfterGoodOpt";
                break;
            case 2:
                sceneName = "AfterVeryGoodOpt";
                break;
            default:
                Debug.LogError("Karma value out of expected range.");
                return;
        }

        SceneManager.LoadScene(sceneName);
    }

    public int newDialogueIndex = 0;
    private void CreateDialogOption()
    {
        SceneManagerr sceneManagerComponent = gameObject.AddComponent<SceneManagerr>();
        newDialogueIndex = SelectRandomOption();
        if (newDialogueIndex >= 0 && newDialogueIndex < options.Count)
        {
            sceneManagerComponent.Data = options[newDialogueIndex].Data;
            sceneManagerComponent.letter = sceneManager.letter;
            sceneManagerComponent.cursor = sceneManager.cursor;
            sceneManagerComponent.typeSound = sceneManager.typeSound;
            sceneManagerComponent.endOfLineSound = sceneManager.endOfLineSound;
            sceneManagerComponent.characters = sceneManager.characters;
            sceneManagerComponent.startPos = new Vector2(0f, -0.15f);
            sceneManagerComponent.showCursor = false;
        }
        else
        {
            Debug.LogError("Failed to create dialogue option: newDialogueIndex is out of range.");
        }
    }

    public void CleanOption()
    {
        RemoveOption(newDialogueIndex);
        if (options.Count > 0)
        {
            var testComponent = gameObject.GetComponents<SceneManagerr>();
            var getLastComponent = testComponent[testComponent.Length - 1];
            StartCoroutine(CleanText(getLastComponent));
            agreeButton.SetActive(false);
            disagreeButton.SetActive(false);
            StartCoroutine(ReactivateButtons());
        }
        else
        {
            disagreeButton.GetComponent<Button>().interactable = false;
            disagreeButton.GetComponent<Image>().enabled = false;
            text.text = "NO MORE OPTIONS!";
        }

    }
    IEnumerator ReactivateButtons()
    {
        yield return new WaitForSeconds(9f);
        disagreeButton.SetActive(true);
        agreeButton.SetActive(true);
    }
    IEnumerator GiveOption()
    {
        //(25);
        yield return new WaitForSeconds(20f);
        CreateDialogOption();
        yield return new WaitForSeconds(9f);
        disagreeButton.SetActive(true);
        agreeButton.SetActive(true);
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
        if (options.Count > 0)
        {
            int randomIndex = Random.Range(0, options.Count);
            auxKarma = options[randomIndex].Karma;
            return randomIndex;
        }
        else
        {
            Debug.LogWarning("No hay más opciones disponibles.");
            return -1;
        }
    }

    SelectableOption auxOptions;

    private void RemoveOption(int index)
    {
        if (index >= 0 && index < options.Count())
        {
            if (options.Count <= 1)
            {
                auxOptions = options[index];
            }
            options.RemoveAt(index);
            var cursor = GameObject.Find("Cursor");
            Destroy(cursor);
        }

    }


}
