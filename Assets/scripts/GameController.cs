using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public List<Button> btn = new List<Button> ();
    // Start is called before the first frame update

    public void GetButton()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("puzzleButton");
        for(int i = 0;i< obj.Length; i++)
        {
           // btn.Add(obj[i].GetComponents<Button>);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
