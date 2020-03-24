using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Temp : MonoBehaviour
{
    private int FileCount = 0;
    public void addRecord()
    {
        FileCount++;

        DataSource obj = DataSource.getSingletonInstance();

        string fileName = Directory.GetParent(Application.dataPath.ToString())+ "/file-" + DateTime.Now.ToString("HH-mm-ss-MM-dd-yyyy") + ".csv";

        File.AppendAllText(fileName, "ID,Health,Type\n");

        for (int i = 1; i <= obj.getNumberOfDoves() + obj.getNumberOfHawks(); i++)
        {
            int ID = i;
            int Health = obj.getHealth();
            string Type = "Dove";
            if (!Type.Equals("Hawk") && (i > obj.getNumberOfDoves()))
                Type = "Hawk";
            File.AppendAllText(fileName, ID.ToString() + "," + Health.ToString() + "," + Type + "\n");
        }
    }

    private void OnDestroy()
    {
        FileCount = 0;
    }
}
