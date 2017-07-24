using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public List<Que> quests = new List<Que>();
    public List<Texture> whos = new List<Texture>();

    void Awake()
    {

        #region 나래 돼지고기
        quests.Add(
            new Que(new string[] {
                "대리자님, 배가 너무 고파요!" ,
                "저는 나래라고 해요.\n대리자님, 저 지나가는 돼지를\n돌로 잡아도 될까요?",
                "한 번도 돼지를 먹어보진 않았지만\n맛있을 것 같은데..."
            }, new Que.Answer("그렇게 하세요.",
            new string[]
            {
                "감사합니다!\n너무 배가 고팠어요..",
            },
            new string[]
            {
                "나래는 잡은 돼지를\n사람들에게 나누어 주었다!",
                "인류가 배불리 먹어 발전했다!",
                "인구수 10 증가\n발전도 50 증가"
            },
            () =>
            {
                GameManager.instance.topLayer.energy.people += 10;
                GameManager.instance.uiManager.picture.Next();
            }),
            new Que.Answer("채식을 하세요.",
            new string[]
            {
                "알겠어요.\n식물엔 다들 질렸는데..",
            },
            new string[]
            {
                "식물은 더 이상 먹기 싫다며\n굻주린 사람들이 싸웠다!",
                "인구수 50 감소"
            },
            () =>
            {
                GameManager.instance.topLayer.energy.people -= 50;
            })
            )
         );
        #endregion

        #region 나래 불
        quests.Add(
    new Que(new string[] {
                "대리자님, 도와주세요!",
                "생고기를 먹은 사람들이 죽어가요!",
                "어떻게 해야 하죠?"
    }, new Que.Answer("불을 \n줄 테니\n쓰세요.",
    new string[]
    {
                "불? 그게 뭔가요?",
                "우왁! 뜨겁네요.\n여기 음식을 잠시 넣으라고요?",
                "일단은 해 볼게요."
    },
    new string[]
    {
                "인류는 불을 발견해 널리 퍼뜨렸다!",
                "농업과 기술에 발전이 이루어졌다!",
                "인구수 10 증가\n불 사용하기 성공"
    },
    () =>
    {
        GameManager.instance.topLayer.energy.people += 10;
        GameManager.instance.uiManager.picture.Next();
        //GameManager.instance.topLayer.
    }),
    new Que.Answer("불은 \n만악의\n근원이에요.",
    new string[]
    {
                "대리자님도 방법이 없으시다니..",
    },
    new string[]
    {
                "식중독으로 인구 전체가 사망했다!",
                "인구수 60 감소"
    },
    () =>
    {
        GameManager.instance.topLayer.energy.people -= 60;
    })
    ));
        #endregion

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class Que
{
    public string[] words;
    public Answer left, right;
    public int who;

    public class Answer
    {
        public string answer;
        public string[] afterWords;
        public string[] resultWords;
        public Action result;
        public Answer(string answer, string[] afterWords, string[] resultWords, Action result)
        {
            this.answer = answer;
            this.afterWords = afterWords;
            this.resultWords = resultWords;
            this.result = result;

        }
    }

    public Que(string[] words, Answer left, Answer right)
    {
        this.words = words;
        this.left = left;
        this.right = right;
    }
}
