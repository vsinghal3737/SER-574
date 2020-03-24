using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataSource
{
    private int numDoves, numHawks, numFood;
    public static DataSource obj;
    private DataSource(){}

    public int getNumberOfDoves(){ return numDoves; }

    public int getNumberOfHawks() { return numHawks; }

    public int getNumberOfFood() { return numFood; }

    public void setNumberOfDoves(int val) { this.numDoves = val; }

    public void setNumberOfHawks(int val) { this.numHawks = val; }
    public void setNumberOfFood(int val) { this.numFood = val; }

    public int getHealth()
    {
        List<int> health = new List<int>() { 100, 80, 60, 40, 20 };
        return health[new System.Random(Guid.NewGuid().GetHashCode()).Next(health.Count)];
    }


    public static DataSource getSingletonInstance()
    {
        if (obj == null)
            obj = new DataSource();
        return obj;
    }


}
