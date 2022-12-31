using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuizManager : MonoBehaviour
{
    public List<SoalDanJawab> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Panel;
    public GameObject gameover;

    public Text QuestionTxt;
    public Text nilaiTxt;
    //int totalQuestion = 0;
    int score = 0;

    private void Start()
    {
        int score = 0;
        //panelbutton.SetActive(false);
        generateQuestion();
    }
    void GameOver()
    {
        Panel.SetActive(true);
        gameover.SetActive(false);
        nilaiTxt.text = score + " / 100";
    }
    public void correct()
    {
        Debug.Log(score);
        score += 20;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of Question");
            GameOver();
        }
        
        
    }
}
