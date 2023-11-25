using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

public class SurnameQClass:IQuestion
{
    public string[] surnames;

    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        int selector = Random.Range(0, 3);
        if (selector == 0)
        {
            GetQ1(card, out question, out answers, out correctAnswers);
        }
        else if (selector == 1)
        {
            GetQ2(card, out question, out answers, out correctAnswers);
        }
        else
        {
            GetQ3(card, out question, out answers, out correctAnswers);
        }
    }
    public void GetQ1(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "Sir, could you please restate your surname?";
        answers = new List<string>();
        correctAnswers = new List<int>();
        //Generating numeric answers. For names, do similar.
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, surnames.Length);
            while (answers.Contains(surnames[index]) || surnames[index] == card.Surname)
            {
                index = (index + 1) % surnames.Length;
            }
            answers.Add(surnames[index]);
        }
        int correctAnswer = Random.Range(0, 2);
        answers[correctAnswer] = card.Surname;
        correctAnswers.Add(correctAnswer);
    }
    public void GetQ2(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "I hope you enjoy your visit Mr. "+card.Surname+".";
        answers = new List<string>();
        correctAnswers = new List<int>();
        //Generating numeric answers. For names, do similar.
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, surnames.Length);
            while (answers.Contains(surnames[index]) || surnames[index] == card.Surname)
            {
                index = (index + 1) % surnames.Length;
            }
            answers.Add(surnames[index]);
        }

        for (int i = 0; i < 3; i++)
        {
            answers[i] = "Thanks. It's Mr. "+answers[i]+" though.";
        }
        int correctAnswer = Random.Range(0, 2);
        answers[correctAnswer] = "Thanks.";
        correctAnswers.Add(correctAnswer);
    }
    public void GetQ3(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "Hmmmm. Your surname sounds familiar...";
        answers = new List<string>();
        correctAnswers = new List<int>();
        //Generating numeric answers. For names, do similar.
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, surnames.Length);
            while (answers.Contains(surnames[index]) || surnames[index] == card.Surname)
            {
                index = (index + 1) % surnames.Length;
            }
            answers.Add(surnames[index]);
        }
        int correctAnswer = Random.Range(0, 2);
        answers[correctAnswer] = card.Surname;
        correctAnswers.Add(correctAnswer);
        for (int i = 0; i < 3; i++)
        {
            answers[i] = "Do you know another "+answers[i]+"?";
        }
    }
}

public class TownQClass : IQuestion
{
    public string[] towns;
    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        int selector = Random.Range(0, 3);
        if (selector == 0)
        {
            GetQ1(card, out question, out answers, out correctAnswers);
        }
        else if (selector == 1)
        {
            GetQ2(card, out question, out answers, out correctAnswers);
        }
        else
        {
            GetQ3(card, out question, out answers, out correctAnswers);
        }
    }
    public void GetQ1(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        string townToUse = null;
        int selector = Random.Range(0, 4);
        if (selector == 0)
        {
            townToUse = card.TownOfOrigin;
        }
        else if (selector == 1)
        {
            townToUse = card.TownOfResidence;
        }
        else
        {
            townToUse= towns[Random.Range(0, towns.Length)];
        }
        question = "You know, have you ever been to "+ townToUse+"?";
        answers = new List<string>();        
        correctAnswers = new List<int>();
        answers.Append("I was born there.");
        if(card.TownOfOrigin == townToUse)
        {
            correctAnswers.Add(0);
        }
        answers.Append("I live there, actually.");
        if(card.TownOfResidence == townToUse)
        {
            correctAnswers.Add(1);
        }
        answers.Append("I may have visited it, but I don't live there nor was I born there.");
        if(correctAnswers.Count == 0)
        {
            correctAnswers.Add(2);
        }
    }
    public void GetQ2(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "So, where do you live?";
        answers = new List<string>();
        correctAnswers = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, towns.Length);
            while (answers.Contains(towns[index]) || towns[index] == card.TownOfResidence)
            {
                index = (index + 1) % towns.Length;
            }
            answers.Add(towns[index]);
        }
        int correctAnswer = Random.Range(0, 2);
        answers[correctAnswer] = card.TownOfResidence;
        correctAnswers.Add(correctAnswer);
    }
    public void GetQ3(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "So, where were you born? I thing I am from the same city";
        answers = new List<string>();
        correctAnswers = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, towns.Length);
            while (answers.Contains(towns[index]) || towns[index] == card.TownOfOrigin)
            {
                index = (index + 1) % towns.Length;
            }
            answers.Add(towns[index]);
        }
        int correctAnswer = Random.Range(0, 2);
        answers[correctAnswer] = card.TownOfOrigin;
        correctAnswers.Add(correctAnswer);
    }
}

public class MarriageQClass : IQuestion
{
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
    private void GetQ1(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "Condolences about your wife.";
        answers = new List<string>();
        correctAnswers = new List<int>();
        answers.Append("I don't have a wife.");
        if (card.maritalStatus == MaritalStatus.single || card.maritalStatus==MaritalStatus.divorced)
        {
            correctAnswers.Add(0);
        }
        answers.Append("I'm still happily married.");
        if (card.maritalStatus == MaritalStatus.married)
        {
            correctAnswers.Add(1);
        }
        answers.Append("Thank you. It was hard to deal with.");
        if (card.maritalStatus==MaritalStatus.widower)
        {
            correctAnswers.Add(2);
        }
    }
    private void GetQ2(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers)
    {
        question = "Married? I hope I'm as lucky as you one day.";
        answers = new List<string>();
        correctAnswers = new List<int>();
        answers.Append("Nah, still looking for that special someone.");
        if (card.maritalStatus == MaritalStatus.single || card.maritalStatus == MaritalStatus.divorced)
        {
            correctAnswers.Add(0);
        }
        answers.Append("I have a great wife. Unlike most of my friends, it's not easy to find the one.");
        if (card.maritalStatus == MaritalStatus.married)
        {
            correctAnswers.Add(1);
        }
        answers.Append("Please don't talk... About her. She's gone.");
        if (card.maritalStatus == MaritalStatus.widower)
        {
            correctAnswers.Add(2);
        }
    }
}