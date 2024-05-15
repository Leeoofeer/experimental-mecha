using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NotThatBadFinal : MonoBehaviour
{
    SceneManagerr sceneManager;
    public GameObject endButton;
    void Start()
    {
        endButton.SetActive(false);
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr>();

        SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent2.Data = new string[] { "after evaluating your decisions", "the karma gives you this future", " ", " ", "before laying down on your bed you decided", " ", "to take a hot shower then started to", " ", "cry because you knew that you could", " ", "do it better after all before lie down", " ",  "you took tranquilizers and went to sleep" };
        sceneManagerComponent2.letter = sceneManager.letter;
        sceneManagerComponent2.cursor = sceneManager.cursor;
        sceneManagerComponent2.typeSound = sceneManager.typeSound;
        sceneManagerComponent2.endOfLineSound = sceneManager.endOfLineSound;
        sceneManagerComponent2.characters = sceneManager.characters;
        sceneManagerComponent2.showCursor = false;
        StartCoroutine(TurnOnEndButton());
    }

    IEnumerator TurnOnEndButton()
    {
        yield return new WaitForSeconds(35f);
        endButton.SetActive(true);
    }

    public void EndButton()
    {
        SceneManager.LoadScene("BadFinal");
    }

}
