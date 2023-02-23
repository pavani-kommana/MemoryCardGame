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
    private int countcorrectguess;
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
        shuffle(gamepuzzle);
        gameguess = gamepuzzle.Count / 2;
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
       // string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        if(!firstGuess)
        {
            firstGuess = true;
            firstguessindex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstguesspuzzle = gamepuzzle[firstguessindex].name;

            btn[firstguessindex].image.sprite = gamepuzzle[firstguessindex];
        }
        else if(!secondGuess)
            {
            secondGuess = true;
            secondguessindex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondguesspuzle = gamepuzzle[secondguessindex].name;
            btn[secondguessindex].image.sprite = gamepuzzle[secondguessindex];
            if(firstguesspuzzle == secondguesspuzle)
            {
                print("matched");
            }
            else
            {
                print("not matched");
            }
            StartCoroutine(checkthepuzzlematch());
        }
    }
    IEnumerator checkthepuzzlematch()
    {
        yield return new WaitForSeconds(0.5f);

        if (firstguesspuzzle==secondguesspuzle)
        {
            yield return new WaitForSeconds(0.5f);
            btn[firstguessindex].interactable = false;
            btn[secondguessindex].interactable =false;

            btn[firstguessindex].image.color= new Color(0,0,0,0);
            btn[secondguessindex].image.color = new Color(0, 0, 0, 0);
        }
        else
        {
            btn[firstguessindex].image.sprite = bgImage;
            btn[secondguessindex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds(0.5f);
        firstGuess = secondGuess = false;

    }
    void checkthegamefinish()
    {
        countcorrectguess++;
        if(countcorrectguess==gameguess)
        {
            print(" ");
        }
    }
    void shuffle(List<Sprite> list)
    {
        for(int i = 0;i< list.Count; i++)
        {
            Sprite temp=    list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i]=list[randomIndex];
            list[randomIndex]=temp;

        }
    }
}
