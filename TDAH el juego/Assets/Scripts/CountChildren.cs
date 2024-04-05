using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountChildren : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int childrenCount;
    public GameObject container;
    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    
    }

    private void Update()
    {
        childrenCount = container.transform.childCount;
        if (gameObject.name == "SideQuestButton")
        {
            text.text = "SideQuests: " + childrenCount.ToString();
        }else if (gameObject.name == "CaveQuestButton")
        {
            text.text = "CaveQuests: " + childrenCount.ToString();
        }else if (gameObject.name == "MineQuestButton")
        {
            text.text = "MineQuests: " + childrenCount.ToString();
        }
          
    }

}
