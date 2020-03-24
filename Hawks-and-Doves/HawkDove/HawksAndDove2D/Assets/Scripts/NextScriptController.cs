using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NextScriptController : MonoBehaviour
{
    public GameObject hawkContainer,DoveGameObeject,FoodGameObject;

    public TextMeshProUGUI Hawks;
    public TextMeshProUGUI Doves;
    public TextMeshProUGUI Food;

    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis;
    private Vector3 _randomPosition;
    public bool _canInstantiate;

    public Button nextButton;
    private TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {

        SetRange();
        Update();
/*
        int test = RandomNumber(1, 4);
        for (int i = 1; i <= test; i++)
        {
            createHawk(i);
            createDove(i);
            createFood(i);

        }


        buttonText = nextButton.GetComponentInChildren<TextMeshProUGUI>();
        btnValue();
        */
    }

    public void check()
    {
        DataSource obj = DataSource.getSingletonInstance();
        obj.setNumberOfHawks(Int32.Parse(Hawks.text.Replace("\u200B", "").ToString()));
        obj.setNumberOfDoves(Int32.Parse(Doves.text.Replace("\u200B", "").ToString()));
        obj.setNumberOfFood(Int32.Parse(Food.text.Replace("\u200B", "").ToString()));
        Debug.Log(obj.getNumberOfDoves());
        Debug.Log(obj.getNumberOfHawks());
        Debug.Log(obj.getNumberOfFood());
        
    }

    private void SetRange()
    {
        Min = new Vector3(-4.2f, -2.7f, 0);
        Max = new Vector3(4.2f, 2.7f, 0);
    }
    private void GenerateRandom()
    {
        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);
    }

    public void btnValue()
    {
        buttonText.text = "Next Button";
    }

    // Update is called once per frame
   public void UpdateCharacters()
    {

        DataSource obj = DataSource.getSingletonInstance();
        // if (Input.GetKeyDown(KeyCode.D))
        for (int i = 0; i < 10; i++)
        {

            GenerateRandom();
            Instantiate(DoveGameObeject, _randomPosition, Quaternion.identity);

        }
        obj.setNumberOfDoves(obj.getNumberOfDoves() + 10);
        // if (Input.GetKeyDown(KeyCode.H))
        for (int i = 0; i < 10; i++)
        {

            GenerateRandom();
            Instantiate(hawkContainer, _randomPosition, Quaternion.identity);

        }
        obj.setNumberOfHawks(obj.getNumberOfHawks() + 10);
        // if (Input.GetKeyDown(KeyCode.F))
        for (int i = 0; i < 10; i++)
        {

            GenerateRandom();
            Instantiate(FoodGameObject, _randomPosition, Quaternion.identity);
        }
        obj.setNumberOfFood(obj.getNumberOfFood() + 10);

        if (_canInstantiate)
        {
            //Instantiate(gameObject, _randomPosition, Quaternion.identity);
        }

    }
    private void Update()
    {
        
    }

    public int RandomNumber(int min, int max)
    {
         System.Random random = new System.Random();
        // return random.Next(min, max);

        int num = random.Next(min,max);
        return num;
    }

    public void createHawk(float x)
    {
        Vector3 hawkposition = new Vector3(x, 0.0f, 0.0f);
        Vector3 hawkRotation = new Vector3(0.0f, 0.0f, 0.0f);
        Instantiate(hawkContainer, hawkposition, transform.rotation);
    }

    public void createDove(float x)
    {
        Vector3 doveposition = new Vector3(2.0f*x, 0.0f, 0.0f);
        Vector3 doveRotation = new Vector3(0.0f, 0.0f, 0.0f);
        Instantiate(DoveGameObeject, doveposition, transform.rotation);

    }

    public void createFood(float x)
    {
        Vector3 foodposition = new Vector3(1.5f*x, 0.0f, 0.0f);
        Vector3 foodRotation = new Vector3(0.0f, 0.0f, 0.0f);
        Instantiate(FoodGameObject, foodposition, transform.rotation);

    }
}
