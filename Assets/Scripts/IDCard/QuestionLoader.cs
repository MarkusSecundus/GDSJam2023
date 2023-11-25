using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class QuestionLoader
{
    public List<IQuestion> questions=new List<IQuestion>();
    public List<IQuestion> currentlyNotUsedQuestions=new List<IQuestion>();
    //public TextAsset dsa;
    public QuestionLoader()
    {
        questions = new List<IQuestion>();
        questions.Add(new AgeQClass());
        questions.Add(new NameQClass());
        questions.Add(new SurnameQClass());
        questions.Add(new TownQClass());
        questions.Add(new MarriageQClass());
        //Question types added, yay.
        resetUsedQs();
    }

    public void resetUsedQs()
    {
        currentlyNotUsedQuestions.Clear();
        foreach (IQuestion question in questions)
        {
            currentlyNotUsedQuestions.Add(question);
        }
    }
    public IQuestion getNextQuestion()
    {
        int rand=Random.Range(0,currentlyNotUsedQuestions.Count());
        var returnval = currentlyNotUsedQuestions[rand];
        currentlyNotUsedQuestions.Remove(returnval);
        return returnval;
    }
}
public interface IQuestion
{
    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess);
    
}
/// <summary>
/// Age question generator
/// </summary>
public class AgeQClass : IQuestion
{
    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
    {
        int selector=Random.Range(0, 2);
        if(selector == 0)
        {
            getQ1(card, out question, out answers, out correctAnswers,out bouncerAOnSuccess);
        }
        else
        {
            getQ2(card, out question, out answers, out correctAnswers,out bouncerAOnSuccess);
        }
    }
    private void getQ1(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
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
        int correctAnswer = Random.Range(0, 3);
        answers[correctAnswer] = card.age.ToString();
        correctAnswers.Add(correctAnswer);
        bouncerAOnSuccess = "OK, that checks out.";
    }
    private void getQ2(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
    {
        question = "By the way, this bar is recommended for ages 30-40.";
        answers= new List<string>();
        answers.Add("I'm a bit young then, but I will manage.");
        answers.Add("I'm your target audience then.");
        answers.Add("I wish to experience how I felt when I was younger.");
        correctAnswers = new List<int>();
        bouncerAOnSuccess = "All right, I won't discourage you.";
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
            bouncerAOnSuccess = "I hope you enjoy yourself then.";
        }
    }
}

public class NameQClass: IQuestion
{
    public string[] names=NameLists.GetNames();//TODO init this.
    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
    {
        int selector = Random.Range(0, 2);
        if (selector == 0)
        {
            GetQ1(card, out question, out answers, out correctAnswers, out bouncerAOnSuccess);
        }
        else
        {
            GetQ2(card, out question, out answers, out correctAnswers, out bouncerAOnSuccess);
        }
    }
    public void GetQ1(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
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
        int correctAnswer = Random.Range(0, 3);
        answers[correctAnswer] = card.FirstName;
        correctAnswers.Add(correctAnswer);
        bouncerAOnSuccess="Yep, that checks out.";
    }
    public void GetQ2(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
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
        int correctAnswer = Random.Range(0, 3);
        answers[correctAnswer] = card.FirstName;
        correctAnswers.Add(correctAnswer);
        int bouncerNameRNG=Random.Range(0, 3);

        if (correctAnswers.Contains(bouncerNameRNG))
        {
            bouncerAOnSuccess = "Always nice to meet another " + answers[correctAnswer] + ".";
        }
        else
        {
            bouncerAOnSuccess = "I do apologise for my mistake. My name is " + answers[bouncerNameRNG] +".";
        }

        for (int i = 0;i < 3; i++)
        {
            answers[i] = "Is your name " + answers[i] + " as well?";
        }
       
    }
}

public class SurnameQClass:IQuestion
{
    public string[] surnames=NameLists.GetSurnames();

    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
    {
        int selector = Random.Range(0, 3);
        if (selector == 0)
        {
            GetQ1(card, out question, out answers, out correctAnswers,out bouncerAOnSuccess);
        }
        else if (selector == 1)
        {
            GetQ2(card, out question, out answers, out correctAnswers, out bouncerAOnSuccess);
        }
        else
        {
            GetQ3(card, out question, out answers, out correctAnswers, out bouncerAOnSuccess);
        }
    }
    public void GetQ1(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
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
        int correctAnswer = Random.Range(0, 3);
        answers[correctAnswer] = card.Surname;
        correctAnswers.Add(correctAnswer);
        bouncerAOnSuccess = "All right, that checks out.";
    }
    public void GetQ2(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
    {
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
        int correctAnswer = Random.Range(0, 3);
        answers[correctAnswer] = card.Surname;

        int pickedName=Random.Range(0, 3);
        question = "I hope you enjoy your visit Mr. " + answers[pickedName] + ".";

        if (pickedName == correctAnswer)
        {
            bouncerAOnSuccess = "Very well.";
        }
        else
        {
            bouncerAOnSuccess = "I am sorry for the confusion sir.";
        }
        for (int i = 0; i < 3; i++)
        {
            answers[i] = "Thanks. It's Mr. "+answers[i]+" though.";
        }       

        answers[pickedName] = "Thanks.";
        correctAnswers.Add(correctAnswer);
    }
    public void GetQ3(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
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
        int correctAnswer = Random.Range(0, 3);
        answers[correctAnswer] = card.Surname;
        correctAnswers.Add(correctAnswer);
        for (int i = 0; i < 3; i++)
        {
            answers[i] = "Do you know another "+answers[i]+"?";
        }
        bouncerAOnSuccess = "I do know the " + answers[correctAnswer] + " family who lives nearby, but not well.";
    }
}

public class TownQClass : IQuestion
{
    public string[] towns=NameLists.GetCities();
    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
    {
        int selector = Random.Range(0, 3);
        if (selector == 0)
        {
            GetQ1(card, out question, out answers, out correctAnswers, out bouncerAOnSuccess);
        }
        else if (selector == 1)
        {
            GetQ2(card, out question, out answers, out correctAnswers, out bouncerAOnSuccess);
        }
        else
        {
            GetQ3(card, out question, out answers, out correctAnswers, out bouncerAOnSuccess);
        }
    }
    public void GetQ1(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
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
        answers.Add("I was born there.");
        if(card.TownOfOrigin == townToUse)
        {
            correctAnswers.Add(0);
        }
        answers.Add("I live there, actually.");
        if(card.TownOfResidence == townToUse)
        {
            correctAnswers.Add(1);
        }
        answers.Add("I may have visited it, but I don't live there nor was I born there.");
        if(correctAnswers.Count == 0)
        {
            bouncerAOnSuccess = "That's a shame, I have family there.";
            correctAnswers.Add(2);
        }
        else
        {
            bouncerAOnSuccess = "Oh? I have family there, actually.";
        }
    }
    public void GetQ2(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
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
        int correctAnswer = Random.Range(0, 3);
        answers[correctAnswer] = card.TownOfResidence;
        correctAnswers.Add(correctAnswer);
        bouncerAOnSuccess = "I don't know the place that well, as a bouncer you don't get around much.";
    }
    public void GetQ3(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
    {
        question = "So, where were you born? I think I am from the same city";
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
        int correctAnswer = Random.Range(0, 3);
        answers[correctAnswer] = card.TownOfOrigin;
        correctAnswers.Add(correctAnswer);
        int wasSameCity = Random.Range(0, 3);
        if (wasSameCity == 0)
        {
            bouncerAOnSuccess = "Cool, I was also born there.";
        }
        else
        {
            bouncerAOnSuccess = "Shame, I was born elsewhere.";
        }
    }
}

public class MarriageQClass : IQuestion
{
    public void GetCompleteQuestionDetails(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
    {
        int selector = Random.Range(0, 2);
        if (selector == 0)
        {
            GetQ1(card, out question, out answers, out correctAnswers, out bouncerAOnSuccess);
        }
        else
        {
            GetQ2(card, out question, out answers, out correctAnswers, out bouncerAOnSuccess);
        }
    }
    private void GetQ1(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
    {
        question = "Condolences about your wife.";
        answers = new List<string>();
        correctAnswers = new List<int>();
        answers.Add("I don't have a wife.");
        if (card.maritalStatus == MaritalStatus.single || card.maritalStatus==MaritalStatus.divorced)
        {
            correctAnswers.Add(0);
        }
        answers.Add("I'm still happily married.");
        if (card.maritalStatus == MaritalStatus.married)
        {
            correctAnswers.Add(1);
        }
        answers.Add("Thank you. It was hard to deal with.");
        if (card.maritalStatus==MaritalStatus.widower)
        {
            correctAnswers.Add(2);
            bouncerAOnSuccess = "I hope your pain of the loss goes away.";
        }
        else
        {
            bouncerAOnSuccess = "Sorry, I must have misread that.";
        }
    }
    private void GetQ2(IDCard card, out string question, out List<string> answers, out List<int> correctAnswers, out string bouncerAOnSuccess)
    {
        question = "Married? I hope I'm as lucky as you one day.";
        answers = new List<string>();
        correctAnswers = new List<int>();
        bouncerAOnSuccess = "";
        answers.Add("Nah, still looking for that special someone.");
        if (card.maritalStatus == MaritalStatus.single || card.maritalStatus == MaritalStatus.divorced)
        {
            correctAnswers.Add(0);
            bouncerAOnSuccess = "Well, good luck with that then.";
        }
        answers.Add("I have a great wife. Unlike most of my friends... It's not easy to find the one.");
        if (card.maritalStatus == MaritalStatus.married)
        {
            correctAnswers.Add(1);
            bouncerAOnSuccess = "Well, you are a lucky man.";
        }
        answers.Add("Please don't talk... About her. She's gone.");
        if (card.maritalStatus == MaritalStatus.widower)
        {
            correctAnswers.Add(2);
            bouncerAOnSuccess = "Sorry to hear that.";

        }
    }
}