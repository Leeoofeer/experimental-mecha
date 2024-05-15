using TMPro;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NeutralFinal : MonoBehaviour
{
    SceneManagerr sceneManager;
    public GameObject endButton;
    void Start()
    {
        endButton.SetActive(false);
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr>();

        SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent2.Data = new string[] { "the next day your boss decided inform", "", "you that the office has a new", " ", "coffe machine and employees will have a", " ", "transport card to not pay when commuting", " ", "after ending your shift you decided", " ", "to take the bus to arrive home early", " ", "and eat the food from yesterday" };
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
        yield return new WaitForSeconds(32f);
        endButton.SetActive(true);
    }



}
