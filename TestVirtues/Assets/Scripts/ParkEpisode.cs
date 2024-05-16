using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ParkEpisode : MonoBehaviour
{
    SceneManagerr sceneManager;
    private List<SelectableOption> options;
    [SerializeField]
    private GameObject disagreeButton;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject agreeButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
           SceneManager.LoadScene("BestDecisions");
        }
    }
    void Start()
    {
        disagreeButton.SetActive(false);
        agreeButton.SetActive(false);
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr   >();
        options = new List<SelectableOption>
        {
        new SelectableOption(new string[] { "you decided to hide and walk continue ", " ", "towards your home and ignore it" }, -2),
        new SelectableOption(new string[] { "you decide to call his girlfriend and", " ", "tell her what is happening" }, -1),
        new SelectableOption(new string[] { "you decided continue walking despite of", " ", "that your friend saw you" }, 0),
        new SelectableOption(new string[] { "you decided to talk to your friend and", " ", "suggest to stop doing it" }, +1),
        new SelectableOption(new string[] { "you confront your friend and make him", " ", "to take sense of his actions" }, +2)
        };


    SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent2.Data = new string[] { "suddlenly you saw you friend cheating his", " ", "girlfriend with another unknown girl", " ", "then seems that both of them", " ", "starts walking towards you", " " };
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
        if (PlayerPrefs.GetInt("Karma") == 0)
        {
            SceneManager.LoadScene("NeutralDecisions");
        }
        else if (PlayerPrefs.GetInt("Karma") > 0 && PlayerPrefs.GetInt("Karma") <= 2)
        {
            SceneManager.LoadScene("GoodDecisions");
        }
        else if (PlayerPrefs.GetInt("Karma") > 2)
        {
            SceneManager.LoadScene("BestDecisions");
        }
        else if (PlayerPrefs.GetInt("Karma") >= -2 && PlayerPrefs.GetInt("Karma") < 0)
        {
            SceneManager.LoadScene("NotThatBadDecision");
        }
        else if (PlayerPrefs.GetInt("Karma") < -2)
        {
            SceneManager.LoadScene("BadDecision1");
        }

    }

    int newDialogueIndex = 0;
    private void CreateDialogOption()
    {
        SceneManagerr sceneManagerComponent = gameObject.AddComponent<SceneManagerr>();
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
        if (options.Count > 0)
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

    IEnumerator GiveOption()
    {
        //(25);
        yield return new WaitForSeconds(25f);
        CreateDialogOption();
        yield return new WaitForSeconds(6f);
        agreeButton.SetActive(true);
        disagreeButton.SetActive(true);
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

    private void RemoveOption(int index)
    {
        if (index >= 0 && index < options.Count())
        {
            options.RemoveAt(index);
            var cursor = GameObject.Find("Cursor");
            Destroy(cursor);
        }
    }


}
