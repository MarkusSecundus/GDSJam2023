using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] string nextScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void loadQuestion(IDCard id)
    {
        string bouncerTalk;
        List<string> responses;

        IQuestion question = questionLoader.getNextQuestion();
        question.GetCompleteQuestionDetails(id, out bouncerTalk, out responses, out correctChoices, out bouncerAnswerOnSucces);
        bouncerText.text = bouncerTalk;
        choice0.text = responses[0];
        choice1.text = responses[1];
        choice2.text = responses[2];
        currentIDCard = id;
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
        int maxQuestionsPerBouncer = 2;
        questionsDone++;
        if (questionsDone < maxQuestionsPerBouncer)
        {
            loadQuestion(currentIDCard);
            //Deactivate answer UI, activate the question UI again
        }
        else
        {
            //load next scene
            resetQLoader();
            currentIDCard = null;
            SceneManager.LoadScene(nextScene);
        }

    }

    public void processButtonPress(int buttonID)
    {
        if (correctChoices.Contains(buttonID))
        {
            bouncerAnswer.text = bouncerAnswerOnSucces;
            choice0.enabled = false;
            choice1.enabled = false;
            choice2.enabled = false;
        }
        else
        {
            bouncerAnswer.text = "That doesn't match the ID. Are you lying to me?";
            //Game over man! Strike/gameover screen on pressing 'next' button.
            Button nextButton = transform.Find("ButtonNext").GetComponent<Button>();
            nextButton.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
