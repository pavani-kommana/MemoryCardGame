using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Button> btn = new List<Button>();
    // Start is called before the first frame update

    private void Start()
    {
        GetButton();
    }
    public void GetButton()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("puzzleButton");
        for (int i = 0; i < obj.Length; i++)
        {
            btn.Add(obj[i].GetComponent<Button>());
            // Update is called once per frame
        }
}
