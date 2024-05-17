using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfterNeutralOpt : MonoBehaviour
{
    SceneManagerr sceneManager;
    public GameObject endButton;
    void Start()
    {
        endButton.SetActive(false);
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr>();

        SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent2.Data = new string[] { "you remain honest because already have", "", "plans and so you couldnt take it", " ", "your relationship doesnt change at all", " ", "and the work environment remains calm" };
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
        yield return new WaitForSeconds(19f);
        endButton.SetActive(true);
    }

    public void NextButton()
    {
        SceneManager.LoadScene("Menu 2");
    }



}
