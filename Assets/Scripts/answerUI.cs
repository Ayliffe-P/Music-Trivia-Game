using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class answerUI : MonoBehaviour
{
    public static answerUI _instance;

    public GameObject panel;
    public GameObject inputField;
    public GameObject dropDown;

    // Start is called before the first frame update
    void Start()
    {
       // insantiateInputField("Insert Year of Origin");
    }
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject insantiateInputField(string boxText) {

        GameObject temp = Instantiate(inputField);
        temp.GetComponent<TMP_InputField>().text = boxText;
        temp.transform.SetParent(panel.transform);
        return temp;

    }

    public void insantiateDropDown(List<string> options)
    {

        GameObject temp = Instantiate(dropDown);
        temp.GetComponent<TMP_Dropdown>().AddOptions(options);
        temp.transform.SetParent(panel.transform);
    }

}
