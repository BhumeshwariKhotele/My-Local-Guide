using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//using Newtonsoft.Json;

public class ListViewData : MonoBehaviour
{
    string url = "https://tools.learningcontainer.com/sample-json.json";

    // Start is called before the first frame update
    void Start()
    {
        if(SceneController.keyword != null)
        {
            StartCoroutine(GetRequest(url));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }

            CreateListOfData(webRequest.downloadHandler.text);
        }
    }

    private void CreateListOfData(string JSONtext)
    {
        Root root = new Root();
     //   Newtonsoft.Json.JsonConvert.PopulateObject(JSONtext, root);
        Debug.Log(root.firstName);


    }
}


public class Address
{
    public string streetAddress { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string postalCode { get; set; }
}

public class PhoneNumber
{
    public string type { get; set; }
    public string number { get; set; }
}

public class Root
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string gender { get; set; }
    public int age { get; set; }
    public Address address { get; set; }
    public List<PhoneNumber> phoneNumbers { get; set; }
} 
