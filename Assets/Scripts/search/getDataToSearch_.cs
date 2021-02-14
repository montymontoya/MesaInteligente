using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class getDataToSearch_ : MonoBehaviour
{
    public TMP_InputField vehicleInput;
    public TMP_InputField mediaInput;
    public TMP_InputField crimeInput;
    public TMP_InputField nameInput;
    public TMP_InputField modusInput;
    public TMP_InputField locationInput;
    public TMP_InputField objectInput;
    public TMP_InputField generalInput;

    private string vehicleString;
    private string mediaString;
    private string crimeString;
    private string nameString;
    private string modusString;
    private string locationString;
    private string objectString;
    private string generalString;

    public Button searchButton;

    

    // Start is called before the first frame update
    void Start()
    {
        Button btn = searchButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {

        vehicleString = vehicleInput.text;
        mediaString = mediaInput.text;
        crimeString = crimeInput.text;
        nameString = nameInput.text;
        modusString = modusInput.text;
        locationString = locationInput.text;
        objectString = objectInput.text;
        generalString = generalInput.text;


        Debug.Log(vehicleString);
        Debug.Log(mediaString);
        Debug.Log(crimeString);
        Debug.Log(nameString);
        Debug.Log(modusString);
        Debug.Log(locationString);
        Debug.Log(objectString);
        Debug.Log(generalString);

    }
}
