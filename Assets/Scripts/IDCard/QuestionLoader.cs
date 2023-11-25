using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuestionLoader : ScriptableObject
{
    //public TextAsset dsa;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
public interface IQuestion
{
    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers);
    
}
/// <summary>
/// Age question generator
/// </summary>
public class AgeQClass : IQuestion
{
    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        int selector=Random.Range(0, 2);
        if(selector == 0)
        {
            getQ1(card, out question, out answers, out correctAnswers);
        }
        else
        {
            getQ2(card, out question, out answers, out correctAnswers);
        }
    }
    private void getQ1(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "Could you just repeat how old you are again?";
        answers = new List<string>();
        correctAnswers = new List<int>();
        //Generating numeric answers. For names, do similar.
        for (int i = 0; i < 3; i++)
        {
            int ageToAdd = Random.Range(21, 51);
            while (answers.Contains(ageToAdd.ToString()) || ageToAdd == card.age)
            {
                ageToAdd++;
            }
            answers.Add(ageToAdd.ToString());
        }
        int correctAnswer = Random.Range(0, 2);
        answers[correctAnswer] = card.age.ToString();
        correctAnswers.Add(correctAnswer);
    }
    private void getQ2(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "By the way, this bar is recommended for ages 30-40.";
        answers= new List<string>();
        answers.Add("I'm a bit young then, but I will manage.");
        answers.Add("I'm your target audience then.");
        answers.Add("I wish to experience how I felt when I was younger.");
        correctAnswers = new List<int>();
        if (card.age <= 30)
        {
            correctAnswers.Add(0);
        }
        if(card.age >= 40)
        {
            correctAnswers.Add(2);
        }
        if(card.age >=30 && card.age <= 40)
        {
            correctAnswers.Add(1);
        }
    }
}

public class NameQClass: IQuestion
{
    public string[] names;//TODO init this.
    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        int selector = Random.Range(0, 2);
        if (selector == 0)
        {
            GetQ1(card, out question, out answers, out correctAnswers);
        }
        else
        {
            GetQ2(card, out question, out answers, out correctAnswers);
        }
    }
    public void GetQ1(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "Just to be sure, could you repeat what your name is?";
        answers = new List<string>();
        correctAnswers = new List<int>();
        //Generating numeric answers. For names, do similar.
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, names.Length);
            while (answers.Contains(names[index]) || names[index] == card.FirstName)
            {
                index = (index + 1) % names.Length;
            }
            answers.Add(names[index]);
        }
        int correctAnswer = Random.Range(0, 2);
        answers[correctAnswer] = card.FirstName;
        correctAnswers.Add(correctAnswer);
    }
    public void GetQ2(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "Oh, I think my first name is the same as yours.";
        answers = new List<string>();
        correctAnswers = new List<int>();
        //Generating numeric answers. For names, do similar.
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, names.Length);
            while (answers.Contains(names[index]) || names[index] == card.FirstName)
            {
                index = (index + 1) % names.Length;
            }
            answers.Add(names[index]);
        }
        int correctAnswer = Random.Range(0, 2);
        answers[correctAnswer] = card.FirstName;
        correctAnswers.Add(correctAnswer);
        for(int i = 0;i < 3; i++)
        {
            answers[i] = "Is your name " + answers[i] + " as well?";
        }
    }
}