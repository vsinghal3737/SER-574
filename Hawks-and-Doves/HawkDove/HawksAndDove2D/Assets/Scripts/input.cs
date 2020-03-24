using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class input : MonoBehaviour
{
    // Start is called before the first frame update

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

    public GameObject hawkContainer, DoveGameObeject, FoodGameObject;

    void Start()
    {
        
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
        UpdateStartCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void UpdateStartCharacters()
    {

        DataSource obj = DataSource.getSingletonInstance();
        // if (Input.GetKeyDown(KeyCode.D))
        Debug.Log(obj.getNumberOfDoves());
        Debug.Log("Hello World");
        Debug.Log(obj.getNumberOfHawks());
        for (int i = 0; i < obj.getNumberOfDoves(); i++)
        {

            GenerateRandom();
            Instantiate(DoveGameObeject, _randomPosition, Quaternion.identity);

        }
        obj.setNumberOfDoves(obj.getNumberOfDoves() + 100);
        // if (Input.GetKeyDown(KeyCode.H))
        for (int i = 0; i < obj.getNumberOfHawks(); i++)
        {

            GenerateRandom();
            Instantiate(hawkContainer, _randomPosition, Quaternion.identity);

        }
        obj.setNumberOfHawks(obj.getNumberOfHawks() + 100);
        // if (Input.GetKeyDown(KeyCode.F))
        for (int i = 0; i < obj.getNumberOfFood(); i++)
        {

            GenerateRandom();
            Instantiate(FoodGameObject, _randomPosition, Quaternion.identity);
        }
        obj.setNumberOfFood(obj.getNumberOfFood() + 100);

        if (_canInstantiate)
        {
            //Instantiate(gameObject, _randomPosition, Quaternion.identity);
        }


    }
}
