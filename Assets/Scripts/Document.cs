using UnityEngine;
using TMPro;

public class Document : MonoBehaviour
{
    public GameObject searchWarrant;
    public GameObject arrestWarrant;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSearchWarrant()
    {
        searchWarrant.SetActive(true);
        SetWarrantName(ConversationManager.Instance.selected_conversation.landmark.residentName);
        SetWarrantDate("April 24, 2026");
        SetWarrantAddress(ConversationManager.Instance.selected_conversation.landmark.houseAddress);
        SetWarrantSignature("Judge Baron Edwards");
        arrestWarrant.SetActive(false);
    }

    public void SetArrestWarrant()
    {
        searchWarrant.SetActive(false);
        SetWarrantName(ConversationManager.Instance.selected_conversation.landmark.residentName);
        arrestWarrant.SetActive(true);
    }

    public void SetWarrantName(string name)
    {
        searchWarrant.transform.Find("Name").GetComponent<TMP_Text>().text = string.Format("{0},", name);
        arrestWarrant.transform.Find("Name").GetComponent<TMP_Text>().text = string.Format("{0},", name);
    }

    public void SetWarrantDate(string date)
    {
        searchWarrant.transform.Find("Date").GetComponent<TMP_Text>().text = date;
    }

    public void SetWarrantAddress(string address)
    {
        searchWarrant.transform.Find("Address").GetComponent<TMP_Text>().text = address;
    }

    public void SetWarrantSignature(string signature)
    {
        searchWarrant.transform.Find("Signature").GetComponent<TMP_Text>().text = signature;
    }
}
