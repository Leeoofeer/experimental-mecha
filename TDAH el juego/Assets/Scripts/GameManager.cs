using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel;
using System.Xml.Linq;
using System;

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
    public GameObject AllQuestContainer;
    public GameObject questRewardContainer;
    public GameObject questReward;
    private int quantityClicksSideQuest = 0;
    private int sideQuestsCompleted = 0;

    public GameObject endGamePanel;
    public TextMeshProUGUI endGameText;
    public int CurrentClicks { get => currentClicks; set => currentClicks = value; }

    public GameObject ButtonSideQuest;
    public GameObject ButtonCaveQuest;
    public GameObject ButtonMineQuest;
    public GameObject ContainerCaveQuest;
    public GameObject ContainerMineQuest;
    public GameObject player, playerPath;
    public TextMeshProUGUI playerFinal;
    private bool isGameFinished = false;
    public bool isGameStarted = false;
    public void UpdateSideQuestCounter(int clicks)
    {
        quantityClicksSideQuest += clicks;
        sideQuestsCompleted++;
        GameObject newReward = Instantiate(questReward, questRewardContainer.transform);
        newReward.name = "Reward";
        Debug.Log("SideQuest completada. Reward otorgado");
    }

    public void StartGame()
    {
        isGameStarted = true;        
        ActivateQuest(go: player);
        ActivateQuest(go: playerPath);

    }

    public void PlayerWalked()
    {
        
        CurrentClicks ++;
        Debug.Log("Player walked. Steps Walked: " + CurrentClicks);
        CheckCurrentClicks(CurrentClicks);
        if (CurrentClicks >= mainGoalClicks)
        {
            Debug.Log("Partida finalizada");
            AllQuestContainer.SetActive(false);
            DeactivateQuest(go: playerPath);
            DeactivateQuest(go: player);
            ChoosePlayerFinal();
            isGameFinished = true;
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
            DeactivateQuest(go: ButtonCaveQuest);
            DeactivateQuest(go: ContainerCaveQuest);
            FillQuestContainer(6, 2, 2, ContainerMineQuest);
        }
        else if (CurrentClicks == 180)
        {
            DeactivateQuest(go: ButtonMineQuest);
            DeactivateQuest(go: ContainerMineQuest);
            
        }
    }

    private void DeactivateQuest(GameObject go)
    {
        go.SetActive(false);
    }

    private void ChoosePlayerFinal()
    {
        if (CurrentClicks+ quantityClicksSideQuest <= 199)
        {
            playerFinal.text = "Final 1: Llegar al objetivo sin distracciones es un logro, no muchos pueden mantener tal nivel de concentracion. Pero la pregunta final es: ¿Que te perdiste simplemente por no haberte permitido hacer otra cosa? Hay cosas que solo estuvieron a tu alcance en su momento ahora no puedes retroceder a buscarlas.";
        }
        else if (CurrentClicks+ quantityClicksSideQuest > 199 && CurrentClicks+ quantityClicksSideQuest <= 230)
        {
            playerFinal.text = "Final 2: Te has moderado en cuanto a que hacerle foco y que no, reflexionando sobre tus decisiones. Algunas veces nos distraemos en la ruta para llegar a nuestro verdadero objetivo. Si esto sucede que valga la pena, sino el tiempo perdido no podrá ser recuperado.";
        }
        else if (CurrentClicks+ quantityClicksSideQuest > 230)
        {
            playerFinal.text = "Final 3: Le has dedicado tiempo a cualquier cosa que se te ha cruzado, llegaste al final pero a que costo, el tiempo ha pasado y no podra ser recuperado. Ahora sin energia y sin ganas de nada, te recuestas y reflexionas sobre el por qué no te concentraste cuando debias.";

        }
        endGamePanel.SetActive(true);

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
            newButton.GetComponent<Image>().color = ButtonSideQuest.GetComponent<Image>().color;
        }        
    }

    public void CreateQuestReward()
    {
        Debug.Log("Otorgando reward por quest completada");
    }

    private void Update()
    {
        if(isGameFinished == false && isGameStarted)
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
            if(container.name == "CaveQuestContainer")
            {
                newButton.GetComponent<Image>().color = ButtonCaveQuest.GetComponent<Image>().color;
            }
            else if (container.name == "MineQuestContainer")
            {
                text.text = "MineQuest";
                newButton.GetComponent<Image>().color = ButtonMineQuest.GetComponent<Image>().color;
            }
            else
            {
                text.text = "SideQuest";
                newButton.GetComponent<Image>().color = ButtonSideQuest.GetComponent<Image>().color;
            }
        }

        for (int i = 0; i < quantityB; i++)
        {
            GameObject newButton = Instantiate(buttonSideQuest, container.transform);
            ButtonClickHandler buttonClickHandler = newButton.GetComponent<ButtonClickHandler>();
            buttonClickHandler.indicator = 1;
            newButton.name = "Quest LvL" + (1 + 1);
            TextMeshProUGUI text = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if (container.name == "CaveQuestContainer")
            {
                newButton.GetComponent<Image>().color = ButtonCaveQuest.GetComponent<Image>().color;
            }
            else if (container.name == "MineQuestContainer")
            {
                text.text = "MineQuest";
                newButton.GetComponent<Image>().color = ButtonMineQuest.GetComponent<Image>().color;
            }
            else
            {
                text.text = "SideQuest";
                newButton.GetComponent<Image>().color = ButtonSideQuest.GetComponent<Image>().color;
            }

        }
        for (int i = 0; i < quantityC; i++)
        {
            GameObject newButton = Instantiate(buttonSideQuest, container.transform);
            ButtonClickHandler buttonClickHandler = newButton.GetComponent<ButtonClickHandler>();
            buttonClickHandler.indicator = 2;
            newButton.name = "Quest LvL" + (2 + 1);
            TextMeshProUGUI text = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if (container.name == "CaveQuestContainer")
            {
                newButton.GetComponent<Image>().color = ButtonCaveQuest.GetComponent<Image>().color;
            }
            else if (container.name == "MineQuestContainer")
            {
                text.text = "MineQuest";
                newButton.GetComponent<Image>().color = ButtonMineQuest.GetComponent<Image>().color;
            }
            else
            {
                text.text = "SideQuest";
                newButton.GetComponent<Image>().color = ButtonSideQuest.GetComponent<Image>().color;
            }
        }
    }

    public void ChangeActiveState(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }
}
