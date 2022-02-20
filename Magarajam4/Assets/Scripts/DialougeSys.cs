using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialougeSys : MonoBehaviour
{
    

    [SerializeField]Dialouge[] dialouges;
    int currentdialouge;
    public TextMeshProUGUI text, author;
    

    void Start()
    {
        currentdialouge = 0;
        Next();
    }

    public void Next()
    {
        text.text = dialouges[currentdialouge].text;
        author.text = dialouges[currentdialouge].ThePersonWhoSaid›t;
        currentdialouge++;
    }


}
