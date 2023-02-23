using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamepuzzle =new List<Sprite> ();

    public List<Button> btn = new List<Button>();
    private bool firstGuess, secondGuess;
    private int countguess;
    private int cointcorrectguess;
    private int gameguess;
    private int firstguessindex, secondguessindex;
    private string firstguesspuzzle, secondguesspuzle;
    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("sprites/fruits");
    }
    // Start is called before the first frame update

    private void Start()
    {
        GetButton();
        AddListeners();
        AddGamepuzzle();
    }
    public void GetButton()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("puzzleButton");
        for (int i = 0; i < obj.Length; i++)
        {
            btn.Add(obj[i].GetComponent<Button>());
            btn[i].image.sprite = bgImage;
            // Update is called once per frame
        }
    }
    void AddGamepuzzle()
    {
        int loop= btn.Count;
        int index = 0;
        for(int i = 0; i < loop; i++)
        {
            if(index == loop/2 )
            {
                index = 0;
            }
            gamepuzzle.Add(puzzles[index]);
            index++;
        }
    }
    void AddListeners()
    {
        foreach(Button bt in btn)
        {
            bt.onClick.AddListener(() => pickPuzzle());
        }
    }
    void pickPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        print("hey");
    }
}
