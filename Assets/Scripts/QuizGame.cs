using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizGame : MonoBehaviour
{
    public Question[] qArray;
    int questionIndex;

    public TextMeshProUGUI qBox1;
    public TextMeshProUGUI qBox2;
    public TextMeshProUGUI qBox3;
    public TextMeshProUGUI qBox4;
    public TextMeshProUGUI aBox;

    private void Start()
    {
        questionIndex = 0;
        NewQuestion();
    }

    private void OnEnable()
    {
        NewQuestion();
    }

    void NewQuestion() {
        int newIndex = questionIndex;
        if (qArray.Length == 1)
        {
            newIndex = 0;
        }
        else
        {
            while (newIndex == questionIndex)
            {
                newIndex = UnityEngine.Random.Range(0, qArray.Length);
            }
        }

        questionIndex = newIndex;
        qBox1.text = qArray[questionIndex].answer1;
        qBox2.text = qArray[questionIndex].answer2;
        qBox3.text = qArray[questionIndex].answer3;
        qBox4.text = qArray[questionIndex].answer4;
        aBox.text = qArray[questionIndex].question;
    }

}
