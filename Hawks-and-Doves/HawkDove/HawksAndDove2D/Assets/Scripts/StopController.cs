using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StopController : MonoBehaviour
{
    public Button stopButton;
    private TextMeshProUGUI textButton;
    // Start is called before the first frame update
    void Start()
    {
        textButton = stopButton.GetComponentInChildren<TextMeshProUGUI>();
        btnValue();

    }

    public void btnValue()
    {
        textButton.text = "Stop Button";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LetsStopQuit()
    {
        Application.Quit();
    }
}
