﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static class BQuestion_Check
{
    public static int Question_Num = 0; //第幾題
    public static string Choose_Ans = ""; //選項 ABC
    public static string Choose_Ans_Content = ""; //答案內容
    public static int Choose_Ans_n = 0; //選擇的選項

    public static int Question_total = 0; //共幾題

}

static class BQuestion_Data{
    
    //Battle Question
    private static string[] Question = new string[20] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
    private static string[] Answer_r_Content = new string[20] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

    private static string[] Button_Ans = new string[3] { "", "", "" };

    private static string[] Button_Ans_Check = new string[3] { "A", "B", "C" };

    private static BQuestion_Class[] question_temp = new BQuestion_Class[20];
    private static Vocabulary_Class[] vocabulary_temp = new Vocabulary_Class[20];

    public static void BQuestion_Init()
    {
        Random.InitState(System.Guid.NewGuid().GetHashCode());
        Vocabulary_Data.Vocabulary_Init();
        for (int i = 0; i < 20; i++)
        {
            vocabulary_temp[i] = Vocabulary_Data.Vocabulary_Get(i);
        }

        switch (Enemy.No)
        {
            case 1:
                BQuestion_Check.Question_total = 5;
                BQuestion_Vocabulary_Set();
                break;
            case 2:
                BQuestion_Check.Question_total = 10;
                BQuestion_Vocabulary_Set();
                break;
            case 3: 
                BQuestion_Check.Question_total = 15;
                BQuestion_Vocabulary_Set();
                break;
            default:
                break;
        }
    }

    public static void BQuestion_Vocabulary_Set() // 第n1~第n2題 共n3題
    {
        for (int i = 0; i < BQuestion_Check.Question_total + 5 ; i++)
        {
            Question[i] = vocabulary_temp[i].GetC_Name();
            Answer_r_Content[i] = vocabulary_temp[i].GetE_Name();
        }

        QaARandomSequence(BQuestion_Check.Question_total);

        for (int i = 0; i < BQuestion_Check.Question_total; i++)
        {
            question_temp[i] = new BQuestion_Class(i + 1, Question[i], "", Answer_r_Content[i], "", "", "");
        }
    }

    public static void Button_Ans_Set()
    {
        //選項設定START
        int r = 0;
        r = Random.Range(0, 3);
        //亂數陣列 START
        int[] rand = new int[20];
        int c = 0;
        rand = GetRandomSequence(20);
        //亂數陣列 END
        for (int i = 0; i < 3; i++)
        {
            if (r == i)
            {
                ChangeButton_Ans(question_temp[BQuestion_Check.Question_Num].GetAnswer_r_Content(), i);
                ChangeAnswer_r(Button_Ans_Check[r], BQuestion_Check.Question_Num); //設定正解ABC END
            }
            else
            {
                while (true)
                {
                    if (Question_Bank.Vocabulary_Ans[rand[c]] == (question_temp[BQuestion_Check.Question_Num].GetAnswer_r_Content()))
                    { c++; continue; }
                    else
                    {
                        ChangeButton_Ans(Question_Bank.Vocabulary_Ans[rand[c]], i);
                        c++;
                        break;
                    }
                }
            }
        }
        //選項設定 END
    }
    //Get
    public static BQuestion_Class BQuestion_Get(int n)
    {
        return question_temp[n];
    }
    public static string GetButton_Ans(int c)
    {
        return Button_Ans[c];
    }
    //Change
    public static void ChangeButton_Ans(string s, int c) //傳送到Battle的三個選項
    {
        Button b_temp;
        b_temp = GameObject.Find("Button_Ans_" + (c+1).ToString()).GetComponent<Button>();
        b_temp.GetComponentInChildren<Text>().text = s;
        Button_Ans[c] = s;
    }
    public static void ChangeAnswer_r(string s, int c)
    {
        question_temp[c].ChangeAnswer_r(s);
    }
    public static void ChangeAnswer_c(string s, int c)
    {
        question_temp[c].ChangeAnswer_c(s);
    }
    public static void ChangeAnswer_c_Content(string s, int c)
    {
        question_temp[c].ChangeAnswer_c_Content(s);
    }
    public static void ChangeFeedBack(string s, int c)
    {
        question_temp[c].ChangeFeedBack(s);
    }
    //亂數函式
    public static void QaARandomSequence(int total)
    {
        int r;
        for (int i = 0; i < total; i++)
        {
            r = Random.Range(0, total);
            string temp = "";
            temp = Question[i];
            Question[i] = Question[r];
            Question[r] = temp;

            temp = Answer_r_Content[i];
            Answer_r_Content[i] = Answer_r_Content[r];
            Answer_r_Content[r] = temp;
        }
    }
    public static int[] GetRandomSequence(int total)
    {
        int r;
        int[] output = new int[total];
        for (int i = 0; i < total; i++)
        {
            output[i] = i;
        }
        for (int i = 0; i < total; i++)
        {
            r = Random.Range(0, total);
            int temp = 0;
            temp = output[i];
            output[i] = output[r];
            output[r] = temp;
        }
        return output;
    }
}
