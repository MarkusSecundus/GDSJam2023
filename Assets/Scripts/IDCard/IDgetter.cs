using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IDgetter : MonoBehaviour
{
    public static int counter = -1;
    [SerializeField] string level0;
    [SerializeField] string level1;
    [SerializeField] string level2;
    [SerializeField] string end;
    // Start is called before the first frame update
    void Start()
    {
        counter++;
        IDCard card = IDCard.Instance;

        TextMeshProUGUI fName = gameObject.transform.Find("FName").GetComponent<TextMeshProUGUI>();
        fName.text = card.FirstName;

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

        StartCoroutine("ChangeScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void InnitCounter()
    {
        counter = -1;
    }

    IEnumerator ChangeScene()
    {
        if(counter == 3)
        {
            counter = 0;
            SceneManager.LoadScene(end);
        }

        yield return new WaitForSeconds(5f);
        switch (counter)
        {
            case 0:
                SceneManager.LoadScene(level0);
                break;
            case 1:
                SceneManager.LoadScene(level1);
                break;
            case 2:
                SceneManager.LoadScene(level2);
                break;
            default:
                break;
        }
        
    }
}
