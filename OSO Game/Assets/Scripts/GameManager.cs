using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
 
            return _instance;
        }

    }
    [field: SerializeField] public int MinNumPlayers { get; set; }
    [field: SerializeField] public bool CanStartGame { get; set; }

    [field: SerializeField] public bool IsGameRunning { get; set; }

    public Grid gameGrid;
    [SerializeField] private GameObject gridUI;
    
    void Awake()
    {
        _instance = this;
        CanStartGame = false;
        MinNumPlayers = 2;
        IsGameRunning = false;
    }

    void Start()
    {
        gameGrid = new Grid();
        InitGameUI();
    }

    public void InitGame() 
    {
        if (CanStartGame)
        {
            IsGameRunning = true;
            gameGrid = new Grid();
            InitGameUI();
            CanStartGame = false;
        }
    }

    private void InitGameUI()
    {
        // Configure the grid layout
        GridLayoutGroup layout = gridUI.GetComponent<GridLayoutGroup>();
        layout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
        layout.constraintCount = gameGrid.gridSize;
        // Remove all chilldren (from previous games for example)
        for (int i = 0; i < layout.transform.childCount; i++)
        {
            Transform child = layout.transform.GetChild(i);
            Destroy(child.gameObject);
        }

        // Fill with buttons
        for (int i = 0; i < gameGrid.gridSize; i++)
        {
            for (int j = 0; j < gameGrid.gridSize; j++)
            {
                // Replace with prefab ?
                GameObject newButton = new GameObject(i + "-" + j);
                newButton.AddComponent<RectTransform>();
                newButton.AddComponent<Image>();
                newButton.GetComponent<Image>().sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
                newButton.GetComponent<Image>().color = Color.yellow;
                newButton.AddComponent<Button>();
                newButton.transform.SetParent(layout.transform);

                newButton.AddComponent<ButtonClickInput>();

                // newButton.GetComponent<Button>().onClick.AddListener(() => {
                //     string[] name = newButton.name.Split("-");
                //     Debug.Log(name[0]);
                //     Debug.Log(name[1]);
                //     int i = int.Parse(name[0]);
                //     int j = int.Parse(name[1]);
                //     GameManager.Instance.gameGrid.SetCell(i, j, Grid.osoValues.SYMBOL_O);
                //     this.GetComponent<Image>().color = Color.red;
                // });
            }
        }
    }

    // Change turn

    // 
}
