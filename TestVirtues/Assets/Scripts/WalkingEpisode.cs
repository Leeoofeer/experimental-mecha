using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEpisode : MonoBehaviour
{
    SceneManager sceneManager;
    private SelectableOption[] options;
    
    void Start()
    {
        sceneManager = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        options = new SelectableOption[5];
        options[0] = new SelectableOption((new string[] { "you finish working and decided to walk"," ", "towards your home after some blocks", " ","you found a lost purse on the street", " ", "it seems to be nobody on your street", " ", "you decided to grab the money that was in"," ","and discard the purse on a near trash bin" }), -2);
        options[1] = new SelectableOption(new string[] { "hello there", "lets talk a little bit", " ", "im going to ask you questions", "and you answer them" }, -1);
        options[2] = new SelectableOption(new string[] { "hello there", "lets talk a little bit", " ", "im going to ask you questions", "and you answer them" }, 0);
        options[3] = new SelectableOption(new string[] { "hello there", "lets talk a little bit", " ", "im going to ask you questions", "and you answer them" }, +1);
        options[4] = new SelectableOption(new string[] { "hello there", "lets talk a little bit", " ", "im going to ask you questions", "and you answer them" }, +2);

        //sceneManager.UpdateData(options[0].Data);
        SceneManager sceneManagerComponent = gameObject.AddComponent<SceneManager>();
        sceneManagerComponent.Data = options[0].Data;
        sceneManagerComponent.letter = sceneManager.letter;
        sceneManagerComponent.cursor = sceneManager.cursor;
        sceneManagerComponent.typeSound = sceneManager.typeSound;
        sceneManagerComponent.endOfLineSound = sceneManager.endOfLineSound;
        sceneManagerComponent.characters = sceneManager.characters;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
