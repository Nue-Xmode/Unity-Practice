using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityPractice.XMLLoad
{
    public class XmlTest : MonoBehaviour
    {
        private void Start()
        {
            Test newTest = XMLToIns<Test>.ToIns("Assets/XMLLoad/Resources/Test.xml");
            Debug.Log(newTest.name);
            Debug.Log(newTest.github);
            Debug.Log(newTest.age);   
        }
    }

    public class Test
    {
        public string name;
        public string github;
        public int age;
    }
}