using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UnityPractice.WebRequest
{
    public class PostMethod : MonoBehaviour
    {
        private InputField m_OutputArea;

        private void Start()
        {
            m_OutputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
            GameObject.Find("PostButton").GetComponent<Button>().onClick.AddListener(PostData);
        }

        private void PostData() => StartCoroutine(PostData_Coroutine()); 
        private IEnumerator PostData_Coroutine()
        {
            string uri = "www.fuck.com";
            m_OutputArea.text = "Loading ...";

            WWWForm form = new WWWForm();
            form.AddField("title", "test data");

            using(UnityWebRequest request = UnityWebRequest.Post(uri, form))
            {
                yield return request.SendWebRequest();
                if(request.result == UnityWebRequest.Result.ConnectionError)
                    m_OutputArea.text = request.error;
                else
                    m_OutputArea.text = request.downloadHandler.text;
            }
        }
    }
}