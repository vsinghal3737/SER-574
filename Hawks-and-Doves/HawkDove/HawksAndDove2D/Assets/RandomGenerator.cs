using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public GameObject Dove;
    public GameObject Hawk;
    public GameObject Food;
    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _zAxis;
    private Vector3 _randomPosition;
    public bool _canInstantiate;

    // Start is called before the first frame update
    void Start()
    {
        SetRange();
    }

    private void SetRange() 
    {
        Min = new Vector3(2, 4, 0);
        Max = new Vector3(20, 40, 0);
    }

    private void GenerateRandom()
    {
        _xAxis = UnityEngine.Random.Range(Min.x, Max.x);
        _yAxis = UnityEngine.Random.Range(Min.y, Max.y);
        _zAxis = UnityEngine.Random.Range(Min.z, Max.z);
        _randomPosition = new Vector3(_xAxis, _yAxis, _zAxis);
    }
    // Update is called once per frame
    void Update()
    {



        GenerateRandom();
        Instantiate(Dove, _randomPosition, Quaternion.identity);
        GenerateRandom();
        Instantiate(Hawk, _randomPosition, Quaternion.identity);
        GenerateRandom();
        Instantiate(Food, _randomPosition, Quaternion.identity);
        if (_canInstantiate)
        {
            //Instantiate(gameObject, _randomPosition, Quaternion.identity);
        }
    }
}
