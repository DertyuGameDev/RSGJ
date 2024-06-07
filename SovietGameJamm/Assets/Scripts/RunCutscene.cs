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
        map.Add("(Юра похоже не сдал из-за того, что его отец генерал приехал лично его завалить)", "GoTo");
        map.Add("Сейчас приду, а с тобой Юрий мы еще не договорили!", "Exam1");
        map.Add("Постой... Да, знаю! Ну ка побежали", "MiniGamePhone");
        map.Add("А теперь Юра собирайся с силами, тебе еще тренироваться и тренировать до сдачи!", "Evil");
        map.Add("Ну вот и хорошо, иди готовься лучше", "Evil");
        map.Add("Слышишь, щенок, либо ты сейчас уходишь отсюда, либо я на тебя такие дела распространю, что твои мама с папой потом по кабинету у меня на коленях ползать будут, лишь бы тебя куда-то приняли",
            "Quit");
        map.Add("А теперь Юра собирайся с силами, тебе еще тренироваться и тренировать до сдачи!", "Evil");
        map.Add("Уйдите уже с глаз моих долой, лоботрясы", "True");
        map.Add("Так, вы почему ушли?", "GeneralCome");
        map.Add("Ты с кем разговариваешь?", "Call");
        map.Add("Але... Да я... Ну как же, сын экзамены сдает, я должен был... Ладно, еду, еду, ну не ругайся так, ну все, давай",
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
        if (line1 == "Ну что бойцы, вперед, на службу Родине!")
        {
            CutsceneManager.Instance.StartCutscene("True");
        }
        else if (line1 == "Так, вы почему ушли?")
        {
            CutsceneManager.Instance.StartCutscene("GeneralCome");
        }
        else if (line1 == "Ты с кем разговариваешь?")
        {
            CutsceneManager.Instance.StartCutscene("Call");
        }
        else if (line1 == "Але... Да я... Ну как же, сын экзамены сдает, я должен был... Ладно, еду, еду, ну не ругайся так, ну все, давай")
        {
            CutsceneManager.Instance.StartCutscene("True");
        }
        else if (line1 == "Ага, есть в списке, ну что, добро пожаловать туда, откуда выходят героями!")
        {
            CutsceneManager.Instance.StartCutscene("Trials");
        }
        else if (line1 == "Посмотрим...")
        {
            Relationship.relationship -= 1;
            CutsceneManager.Instance.StartCutscene("Ending1");
        }
        else if (line1 == "Вперед!")
        {
            Relationship.relationship += 1;
            CutsceneManager.Instance.StartCutscene("Ending");
        }
        else if (line1 == "Юрий Подольцев! Поздравляю!")
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
