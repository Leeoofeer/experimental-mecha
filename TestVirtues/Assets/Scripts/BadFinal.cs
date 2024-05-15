using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadFinal : MonoBehaviour
{
    SceneManagerr sceneManager;  
    public GameObject endButton;
    void Start()
    {
        endButton.SetActive(false);
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManagerr>();
        
        SceneManagerr sceneManagerComponent2 = this.gameObject.AddComponent<SceneManagerr>();
        sceneManagerComponent2.Data = new string[] { "after evaluating your decisions", "the karma gives you this future", " "," ", "you layed down on your bed and expended", " ", "all night drinking and smoking while", " ", "watching tv shows like nothing", " ", "that happened today affected you after all", " ", };
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
        yield return new WaitForSeconds(30f);        
        endButton.SetActive(true);
    }

    public void EndButton()
    {
        SceneManager.LoadScene("BadFinal");
    }

}
