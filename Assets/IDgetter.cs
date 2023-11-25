using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IDgetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IDCard card = new();

        TextMeshProUGUI fName = gameObject.transform.Find("FName").GetComponent<TextMeshProUGUI>();
        fName.text = card.Name;

        TextMeshProUGUI lName = gameObject.transform.Find("LName").GetComponent<TextMeshProUGUI>();
        lName.text = card.Surname;

        TextMeshProUGUI age = gameObject.transform.Find("Age").GetComponent<TextMeshProUGUI>();
        age.text = card.age.ToString();

        TextMeshProUGUI origin = gameObject.transform.Find("Origin").GetComponent<TextMeshProUGUI>();
        origin.text = card.TownOfOrigin;

        TextMeshProUGUI residence = gameObject.transform.Find("Residence").GetComponent<TextMeshProUGUI>();
        residence.text = card.TownOfResidence;

        TextMeshProUGUI marital = gameObject.transform.Find("Marital").GetComponent<TextMeshProUGUI>();
        marital.text = card.maritalStatus.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
