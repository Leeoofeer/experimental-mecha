using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WalkingEpisode : MonoBehaviour
{
    SceneManagerr sceneManager;
    private SelectableOption[] options;
    [SerializeField]
    private GameObject disagreeButton;
    [SerializeField]
    private TextMeshProUGUI text;
    
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr>();
        options = new SelectableOption[5];        
        options[0] = new SelectableOption((new string[] { "you decided to grab the money that was in", " ", "and discard the purse on a near trash bin" }), -2);
        options[1] = new SelectableOption(new string[] { "you decided to grab the money that was in", " ", "and left the purse where it was" }, -1);
        options[2] = new SelectableOption(new string[] {  "you decided to not grab the money that was", " ", "in and left the purse where it was" }, 0);
        options[3] = new SelectableOption(new string[] {  "you decided to grab the purse and take it", " ", "to the nearby police station" }, +1);
        options[4] = new SelectableOption(new string[] { "you saw a mobile number in it and called", " ", "the owner to return the purse" }, +2);


        SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr   >();
        sceneManagerComponent2.Data = new string[] { "you finish working and decided to walk", " ", "towards your home and after some blocks", " ", "you found a lost purse on the street", " ", "it seems to be nobody on your street", " " };
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
        SceneManager.LoadScene("Menu 2");
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

    IEnumerator GiveOption()
    {
        //(25);
        yield return new WaitForSeconds(20f);
        CreateDialogOption();
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


}
