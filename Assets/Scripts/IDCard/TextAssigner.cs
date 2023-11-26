using MarkusSecundus.MultiInput;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextAssigner : MonoBehaviour
{
    public TextMeshProUGUI bouncerText;
    public TextMeshProUGUI choice0;
    public TextMeshProUGUI choice1;
    public TextMeshProUGUI choice2;
    public TextMeshProUGUI bouncerAnswer;
    public QuestionLoader questionLoader = new QuestionLoader();
    List<int> correctChoices;
    private string bouncerAnswerOnSucces = null;
    int questionsDone = 0;
    IDCard currentIDCard = null;
    [SerializeField] GameObject nextButton;
    [SerializeField] string nextScene;
    [SerializeField] string failScene;

    [SerializeField] GameObject Button0, Button1, Button2;

    bool fail = false;
    // Start is called before the first frame update
    void Start()
    {
        fail = false;
    }

    public void loadQuestion(IDCard id)
    {
        string bouncerTalk;
        List<string> responses;
        nextButton.SetActive(false);

        IQuestion question = questionLoader.getNextQuestion();
        question.GetCompleteQuestionDetails(id, out bouncerTalk, out responses, out correctChoices, out bouncerAnswerOnSucces);
        bouncerText.text = bouncerTalk;
        choice0.text = responses[0];
        choice1.text = responses[1];
        choice2.text = responses[2];
        currentIDCard = id;

        bouncerAnswer.enabled = false;
    }
    public void resetQLoader()
    {
        questionLoader.resetUsedQs();
        questionsDone = 0;
    }
    public void button0Press() { processButtonPress(0); }
    public void button1Press() { processButtonPress(1); }
    public void button2Press() { processButtonPress(2); }
    public void buttonNextPress()
    {
        if (fail)
        {
            resetQLoader();
            currentIDCard = null;
            IDCard.NullOutID();
            //SceneManager.LoadScene(failScene);          
            StartCoroutine("ChangeSceneAfterSec");
            return;
        }

        int maxQuestionsPerBouncer = 2;
        questionsDone++;
        if (questionsDone < maxQuestionsPerBouncer)
        {
            loadQuestion(currentIDCard);
            //Deactivate answer UI, activate the question UI again
            bouncerText.enabled = true;
            /*choice0.enabled = true;
            choice1.enabled = true;
            choice2.enabled = true;*/
            Button0.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(true);
            nextButton.SetActive(false);
        }
        else
        {
            //load next scene
            resetQLoader();
            currentIDCard = null;
            IDCard.NullOutID();
            SceneManager.LoadScene(nextScene);
        }

    }

    IEnumerator ChangeSceneAfterSec()
    {

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(failScene);
    }

    public void processButtonPress(int buttonID)
    {
        bouncerAnswer.enabled = true;
        nextButton.SetActive(true);
        Button0.SetActive(false); Button1.SetActive(false); Button2.SetActive(false);
        bouncerText.enabled = false;
        if (correctChoices.Contains(buttonID))
        {
            bouncerAnswer.text = bouncerAnswerOnSucces;            
            /*choice0.enabled = false;
            choice1.enabled = false;
            choice2.enabled = false;*/            
        }
        else
        {
            bouncerAnswer.text = "That doesn't match the ID. Are you lying to me?";
            fail = true;
            //Game over man! Strike/gameover screen on pressing 'next' button.
            nextButton.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
