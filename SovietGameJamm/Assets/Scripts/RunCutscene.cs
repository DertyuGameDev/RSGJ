using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunCutscene : MonoBehaviour
{
    public string Cutscene, Cutscene2;
    bool can = true;
    bool can2 = true;
    public Animator animator;
    Dictionary<string, string> map = new Dictionary<string, string>();
    private void Awake()
    {
        map.Add("(��� ������ �� ���� ��-�� ����, ��� ��� ���� ������� ������� ����� ��� ��������)", "GoTo");
        map.Add("������ �����, � � ����� ���� �� ��� �� ����������!", "Exam1");
        map.Add("������... ��, ����! �� �� ��������", "MiniGamePhone");
        map.Add("� ������ ��� ��������� � ������, ���� ��� ������������� � ����������� �� �����!", "Evil");
        map.Add("�� ��� � ������, ��� �������� �����", "Evil");
        map.Add("�������, �����, ���� �� ������ ������� ������, ���� � �� ���� ����� ���� ������������, ��� ���� ���� � ����� ����� �� �������� � ���� �� ������� ������� �����, ���� �� ���� ����-�� �������",
            "Quit");
        map.Add("� ������ ��� ��������� � ������, ���� ��� ������������� � ����������� �� �����!", "Evil");
        map.Add("������ ��� � ���� ���� �����, ���������", "True");
        map.Add("���, �� ������ ����?", "GeneralCome");
        map.Add("�� � ��� ��������������?", "Call");
        map.Add("���... �� �... �� ��� ��, ��� �������� �����, � ������ ���... �����, ���, ���, �� �� ������� ���, �� ���, �����",
            "True");
    }
    public void Line(string line1)
    {
        if (can)
        {
            CutsceneManager.Instance.StartCutscene(Cutscene);
            can = false;
        }
        else if (can == false && can2)
        {
            CutsceneManager.Instance.StartCutscene(Cutscene2);
            can2 = false;
        }
    }
    public void Anim(string line1)
    {
        if (line1 == "1")
        {
            animator.SetTrigger("Write");
        }
    }
    public void End(string line1)
    {
        if (line1 == "�� ��� �����, ������, �� ������ ������!")
        {
            CutsceneManager.Instance.StartCutscene("True");
        }
        else if (line1 == "���, �� ������ ����?")
        {
            CutsceneManager.Instance.StartCutscene("GeneralCome");
        }
        else if (line1 == "�� � ��� ��������������?")
        {
            CutsceneManager.Instance.StartCutscene("Call");
        }
        else if (line1 == "���... �� �... �� ��� ��, ��� �������� �����, � ������ ���... �����, ���, ���, �� �� ������� ���, �� ���, �����")
        {
            CutsceneManager.Instance.StartCutscene("True");
        }
        else if (line1 == "���, ���� � ������, �� ���, ����� ���������� ����, ������ ������� �������!")
        {
            CutsceneManager.Instance.StartCutscene("Trials");
        }
        else if (line1 == "���������...")
        {
            Relationship.relationship -= 1;
            CutsceneManager.Instance.StartCutscene("Ending1");
        }
        else if (line1 == "������!")
        {
            Relationship.relationship += 1;
            CutsceneManager.Instance.StartCutscene("Ending");
        }
        else if (line1 == "���� ���������! ����������!")
        {
            if (Relationship.relationship >= 0) 
            {
                CutsceneManager.Instance.StartCutscene("EvilEnd");
            }
            else
            {
                CutsceneManager.Instance.StartCutscene("GoodEnd");
            }
        }
        else
        {
            CutsceneManager.Instance.StartCutscene(map[line1]);
        }
    }
}
