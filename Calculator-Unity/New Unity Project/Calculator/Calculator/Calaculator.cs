using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace CALCULATOR_DLL
{
    public class Calc
    {
        public float add(float x, float y)
        {
            return x + y;
        }
        public float divide(float x, float y)
        {
            return x / y;
        }
        public float multiply(float x, float y)
        {
            return x * y;
        }
        public float subtract(float x, float y)
        {
            return x - y;
        }

    }
}
