using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButton : MonoBehaviour
{
    [SerializeField]
    private Transform puzzlefield;
    [SerializeField]
    private GameObject btn;
    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0;i< 12;i++)
        {
          GameObject button =Instantiate(btn);
            button.name = " " + i;
            button.transform.SetParent(puzzlefield,false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
