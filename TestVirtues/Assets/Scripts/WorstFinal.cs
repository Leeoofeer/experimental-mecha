using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorstFinal : MonoBehaviour
{
    SceneManagerr sceneManager;
    public GameObject endButton;
    void Start()
    {
        endButton.SetActive(false);
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr>();

        SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent2.Data = new string[] { "the next day your boss decided inform", "", "that instead of choosing you there is a new", " ", "manager on the team", " ", "after ending you shift you walked towards", " ", "home and in the meantine you landlord", " ", "called and told you that your rent is", " ", "going to be more expensive next month" };
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
        yield return new WaitForSeconds(36f);
        endButton.SetActive(true);
    }



}
