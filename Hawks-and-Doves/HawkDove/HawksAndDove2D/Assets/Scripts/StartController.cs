using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StartController : MonoBehaviour
{
    public Button startButton;
    private TextMeshProUGUI textButton;
    public TMP_InputField hawks;
    // Start is called before the first frame update
    void Start()
    {

       
        textButton = startButton.GetComponentInChildren<TextMeshProUGUI>();
        if (hawks != null)
        {
           // hawks.get
        }
        btnValue();
    }

    public void btnValue()
    {
        textButton.text = "Start Button";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
