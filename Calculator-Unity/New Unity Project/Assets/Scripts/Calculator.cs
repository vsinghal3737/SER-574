using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CALCULATOR_DLL;

public class Calculator : MonoBehaviour
{
    public Calc helper = new Calc();
    public InputField InputX;
    public InputField InputY;


    public float X;
    public float Y;
    // public float ans;
    
    public Text Answer;

    // Start is called before the first frame update
    void Start(){
        Answer.text = "";
    }

    public void GetX(){
        X = float.Parse(InputX.text);
    }

    public void GetY(){
        Y = float.Parse(InputY.text);
    }

    public void Sum(){
        Answer.text = "" + helper.add(X, Y);
    }

    public void Sub(){
        Answer.text = "" + helper.subtract(X, Y);
    }

    public void Mul(){
        Answer.text = "" + helper.multiply(X, Y);
    }

    public void Div(){
        Answer.text = "" + helper.divide(X, Y);
    }

}
