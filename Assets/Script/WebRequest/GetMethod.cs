using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

namespace UnityPractice.WebRequest
{
    public class GetMethod : MonoBehaviour
    {
        private InputField m_outputArea;

        private void Start()
        {
            m_outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
            GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);    
        }

        private void GetData() => StartCoroutine(GetData_Coroutine());
        private IEnumerator GetData_Coroutine()
        {
            m_outputArea.text = "Loading ...";

            string uri = "www.fuck.com";
            using(UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError)
                    m_outputArea.text = request.error;
                else
                    m_outputArea.text = request.downloadHandler.text;
            }
        }
    }
}