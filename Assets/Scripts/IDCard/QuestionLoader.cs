using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionLoader : ScriptableObject
{
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
