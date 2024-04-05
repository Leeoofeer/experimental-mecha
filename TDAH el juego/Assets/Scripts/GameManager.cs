using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;
using System.Xml.Linq;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject managerObject = new GameObject("GameManager");
                _instance = managerObject.AddComponent<GameManager>();
                DontDestroyOnLoad(managerObject);
            }
            return _instance;
        }
    }
    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Screen.SetResolution(550, 975, false);
    }
    #endregion

    // Funcionalidad abajo
    private int mainGoalClicks = 199;
    private int currentClicks = 0;
    public GameObject buttonSideQuest;
    public GameObject SideQuestContainer;
    public GameObject CaveQuestContainer;
    public GameObject MineQuestContainer;
    public GameObject questRewardContainer;
    public GameObject questReward;
    private int quantityClicksSideQuest = 0;
    private int sideQuestsCompleted = 0;

    public GameObject endGamePanel;
    public TextMeshProUGUI endGameText;
    public int CurrentClicks { get => currentClicks; set => currentClicks = value; }

    public GameObject ButtonCaveQuest;
    public GameObject ButtonMineQuest;
    public GameObject ContainerCaveQuest;
    public GameObject ContainerMineQuest;




    public void UpdateSideQuestCounter(int clicks)
    {
        quantityClicksSideQuest += clicks;
        sideQuestsCompleted++;
        GameObject newReward = Instantiate(questReward, questRewardContainer.transform);
        newReward.name = "Reward";
        Debug.Log("SideQuest completada. Reward otorgado");
    }

    public void PlayerWalked()
    {
        
        CurrentClicks ++;
        Debug.Log("Player walked. Steps Walked: " + CurrentClicks);
        CheckCurrentClicks(CurrentClicks);
        if (CurrentClicks >= mainGoalClicks)
        {
            Debug.Log("Partida finalizada");
            SideQuestContainer.SetActive(false);
            endGamePanel.SetActive(true);
            endGameText.text = "Felicidades, llegaste al objetivo. En el camino te has destinado esfuerzos extra al hacer " + quantityClicksSideQuest + " clicks en " + sideQuestsCompleted + " misiones secundarias.";
        }
        else if (CurrentClicks == 83)
        {
            ActivateQuest(go: ButtonCaveQuest);
            FillQuestContainer( 4,  3,  1, ContainerCaveQuest);
        }
        else if (CurrentClicks == 130)
        {
            ActivateQuest(go: ButtonMineQuest);
            FillQuestContainer(6, 2, 2, ContainerMineQuest);
        }
    }

    private void CheckCurrentClicks(int currentClicks)
    {
        switch (currentClicks)
        {
            case 15:
                CreateSideQuest(0,1);
                break;
            case 29:
                CreateSideQuest(0,2);
                break;
            case 41:
                CreateSideQuest(0, 2);
                CreateSideQuest(1, 1);
                break;
            case 62:
                CreateSideQuest(0, 1);
                CreateSideQuest(1, 2);
                break;
            case 83:
                CreateSideQuest(0, 1);
                CreateSideQuest(2, 1);
                //CREAR BOSQUE AQUI
                break;
            case 104:
                CreateSideQuest(0, 1);
                CreateSideQuest(1, 1);
                CreateSideQuest(2, 1);
                break;
            case 115:
                CreateSideQuest(2, 2);
                break;
            case 126:
                CreateSideQuest(0, 1);
                CreateSideQuest(2, 2);
                break;
            case 137:
                CreateSideQuest(1, 1);
                CreateSideQuest(2, 2);
                //CREAR CUEVA AQUI
                break;
            case 158:
                CreateSideQuest(2, 3);
                break;
            default:
                //Debug.LogWarning("Valor de currentClicks: " + currentClicks + " no manejado en el switch.");
                break;
        }
    }

    public void CreateSideQuest(int buttonIndex, int quantity)
    {
        Debug.Log("Creando " + quantity + " sidequests de nivel " + (buttonIndex + 1));
        for (int i = 0; i < quantity; i++)
        {
            GameObject newButton = Instantiate(buttonSideQuest, SideQuestContainer.transform);
            ButtonClickHandler buttonClickHandler = newButton.GetComponent<ButtonClickHandler>();
            buttonClickHandler.indicator = buttonIndex;
            newButton.name = "SideQuest LvL" + (buttonIndex + 1);
        }        
    }

    public void CreateQuestReward()
    {
        Debug.Log("Otorgando reward por quest completada");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { PlayerWalked(); }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ActivateQuest(GameObject go)
    {
        go.SetActive(true);        
    }

    public void FillQuestContainer(int quantityA, int quantityB, int quantityC, GameObject container)
    {
        for (int i = 0; i < quantityA; i++)
        {
            GameObject newButton = Instantiate(buttonSideQuest, container.transform);
            ButtonClickHandler buttonClickHandler = newButton.GetComponent<ButtonClickHandler>();
            buttonClickHandler.indicator = 0;
            newButton.name = "Quest LvL" + (0 + 1);
            TextMeshProUGUI text = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if(container.name == "ContainerCaveQuest")
            {
                text.text = "CaveQuest";
            }
            else if (container.name == "ContainerMineQuest")
            {
                text.text = "MineQuest";
            }
            else
            {
                text.text = "SideQuest";
            }
        }
        for (int i = 0; i < quantityB; i++)
        {
            GameObject newButton = Instantiate(buttonSideQuest, container.transform);
            ButtonClickHandler buttonClickHandler = newButton.GetComponent<ButtonClickHandler>();
            buttonClickHandler.indicator = 1;
            newButton.name = "Quest LvL" + (1 + 1);
            TextMeshProUGUI text = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if (container.name == "ContainerCaveQuest")
            {
                text.text = "CaveQuest";
            }
            else if (container.name == "ContainerMineQuest")
            {
                text.text = "MineQuest";
            }
            else
            {
                text.text = "SideQuest";
            }

        }
        for (int i = 0; i < quantityC; i++)
        {
            GameObject newButton = Instantiate(buttonSideQuest, container.transform);
            ButtonClickHandler buttonClickHandler = newButton.GetComponent<ButtonClickHandler>();
            buttonClickHandler.indicator = 2;
            newButton.name = "Quest LvL" + (2 + 1);
            TextMeshProUGUI text = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if (container.name == "ContainerCaveQuest")
            {
                text.text = "CaveQuest";
            }
            else if (container.name == "ContainerMineQuest")
            {
                text.text = "MineQuest";
            }
            else
            {
                text.text = "SideQuest";
            }
        }
    }

    public void ChangeActiveState(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }
}
