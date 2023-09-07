using System.Xml;
using UnityEngine;

namespace UnityPractice.XMLLoad
{
    public class XmlTest : MonoBehaviour
    {
        private void Start()
        {
            XmlTarget newTest = XMLToIns<XmlTarget>.ToIns("Assets/XMLLoad/Resources/XmlTest.xml");
            
            Debug.Log(newTest.name);
            Debug.Log(newTest.github);
            Debug.Log(newTest.age);
        }
    }
}