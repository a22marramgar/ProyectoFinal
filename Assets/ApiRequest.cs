using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ApiRequest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GetRequest", "http://localhost:3666/");
        loginData loginData = new loginData();
        loginData.username = "Juan";
        loginData.password = "1234";
        StartCoroutine(PostRequest("http://localhost:3666/login", JsonUtility.ToJson(loginData)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            if(webRequest.result == UnityWebRequest.Result.Success)
            {
                string responseText = webRequest.downloadHandler.text;
                messageData messageData = JsonUtility.FromJson<messageData>(responseText);
                Debug.Log(messageData.msg);
            }
            else
            {
                Debug.Log("Error: " + webRequest.error);
            }
        }
    }

    IEnumerator PostRequest(string url, string body)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(url, body, "application/json"))
        {
            yield return request.SendWebRequest();
            if(request.result == UnityWebRequest.Result.Success)
            {
                string responseText = request.downloadHandler.text;
                messageData messageData = JsonUtility.FromJson<messageData>(responseText);
                Debug.Log(messageData.msg);
            }
            else
            {
                Debug.Log("Error: " + request.error);
            }   
        }
    }

}
[System.Serializable]
public class messageData
{
    public string msg;
}

[System.Serializable]
public class loginData
{
    public string username;
    public string password;
}
