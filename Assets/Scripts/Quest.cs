using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    public List<Que> quests = new List<Que>();
    public List<Texture> whos = new List<Texture>();
    //나래, 광부, 둘리, 연구원,
    void Awake()
    {

        #region 나래 돼지고기
        quests.Add(
            new Que(0, new string[] {
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
    new Que(0, new string[] {
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

        #region 광부 석탄탐사

        quests.Add(
    new Que(1, new string[] {
                "안녕하세요 대리자님!",
                "불이 참 편한데 나무는\n너무 일찍 꺼져버리는데,",
                "혹시 탐사하면\n다른 좋은 태울 게 나올까요?"
    }, new Que.Answer("찾아\n보세요.",
    new string[]
    {
                "넵, 가보도록 하겠습니다.",
                "그러고 보니 특이한\n검은 조각을 한 번\n본 것 같기도..",
    },
    new string[]
    {
                "인류는 석탄을 발견했다!",
                "하지만 잘 사용하지 못해\n아직 효과가 미미했다.",
                "인구수 13 증가\n석탄 1단계 발견"
    },
    () =>
    {
        GameManager.instance.topLayer.energy.people += 13;
        GameManager.instance.topLayer.energy.coal = 1;
        //GameManager.instance.topLayer.
    }),
    new Que.Answer("그냥\n쓰세요.",
    new string[]
    {
                "알겠습니다..",
    },
    new string[]
    {
                "불을 위한 많은 벌목으로\n환경오염이 심해졌다.",
                "인구수 20 감소, 환경 20 감소"
    },
    () =>
    {
        GameManager.instance.topLayer.energy.people -= 20;
        GameManager.instance.topLayer.energy.people -= 20;
    })
    ));
        #endregion

        #region 둘리 석탄을 버릴까?

        quests.Add(
    new Que(2, new string[] {
                "아, 대리자님. 다름이 아니고요,",
                "석탄이 창고를 너무\n많이 차지하는데..",
                "지금으로선 충분하니\n창고에서 좀 버릴까요?"
    }, new Que.Answer("그래요,\n버리세요.",
    new string[]
    {
                "본부대로 버리도록 하겠습니다.",
    },
    new string[]
    {
                "아무 일도 일어나지 않았다!",
    },
    () =>
    {
        GameManager.instance.currentIndex -= 1;
        //GameManager.instance.topLayer.
    }),
    new Que.Answer("버리지\n마세요.",
    new string[]
    {
                "맘에 썩 좋지는 않지만\n대리자님의 말씀대로.",
    },
    new string[]
    {
                "대리자의 의견에 대한 반발로\n몇 곳에서 소동이 일어났다.",
                "인구수 12 감소, 석탄 2단계 강화"
    },
    () =>
    {
        GameManager.instance.topLayer.energy.people -= 12;
        GameManager.instance.topLayer.energy.coal = 2;
    })
    ));
        #endregion

        #region 연구원 증기 기관 개발?

        quests.Add(
    new Que(3, new string[] {
                "안녕하세요! 저는\n연구원 이정태라고 합니다.",
                "석탄을 통해 혁신적인\n증기 기관이라는 기술을 발명해냈는데",
                "지구의 발전 차원에서\n지원 의사 표명을 부탁드립니다!"
    }, new Que.Answer("연구를\n지원하죠.",
    new string[]
    {
                "하하! 정말 감사합니다!",
    },
    new string[]
    {
                "증기 기관의 개발에 성공했다!",
                "공장이 보급되어\n전 세계에 혁명이 이루어졌다!",
                "환경 20 감소, 석탄 3단계, 산업 혁명 돌입"
    },
    () =>
    {
        GameManager.instance.topLayer.energy.environment -= 20;
        GameManager.instance.topLayer.energy.coal = 3;
        GameManager.instance.uiManager.picture.Next();
        //GameManager.instance.topLayer.
    }),
    new Que.Answer("잡상인\n안 받아요.",
    new string[]
    {
                "후회하실 겁니다.\n다음에 또 찾아오죠.",
    },
    new string[]
    {
                "아무 일도 일어나지 않았다.",
    },
    () =>
    {
        GameManager.instance.currentIndex -= 1;
    })
    ));
        #endregion

        #region 눈사람 석탄이 건강에 영향?

        quests.Add(
    new Que(4, new string[] {
                "안녕하세요, 저는\n환경 연구가 황승연입니다.",
                "석탄이 환경과 건강에\n영향을 미친다고 하는데",
                "인류의 생명을 위해\n공장 축소가 필요하지 않을까요?"
    }, new Que.Answer("그래요.\n줄이죠.",
    new string[]
    {
                "잘 선택하셨습니다.",
    },
    new string[]
    {
                "공장을 줄였다!",
                "평균 수명이 올라 인구가 증가했다.",
                "환경 20 증가, 인구 10 증가"
    },
    () =>
    {
        GameManager.instance.topLayer.energy.environment += 20;
        GameManager.instance.topLayer.energy.people -= 10;
        GameManager.instance.uiManager.picture.Next();
        //GameManager.instance.topLayer.
    }),
    new Que.Answer("잡상인\n안 받아요.",
    new string[]
    {
                "뒷 일은 책임 못 집니다.",
    },
    new string[]
    {
                "전염병으로 인구 전체가 사망했다.",
    },
    () =>
    {
        GameManager.instance.topLayer.energy.people -= 100;
    })
    ));
        #endregion

        #region 테스트 코드 개발 쑝쑝

        quests.Add(
    new Que(4, new string[] {
                "안녕하세요, 저는\n최고의 개발자 송정현입니다.",
                "여러분을 위해\n치트를 만들어 드렸습니다.",
                "빠르게 둘 중 하나\n선택하시면 됩니다."
    }, new Que.Answer("그래요.\n",
    new string[]
    {
                "잘 선택하셨습니다.",
    },
    new string[]
    {
                "치트를 썼다!",
                "원자력과 친환경 개발로\n인류가 마구 발전한다!",
                "환경 엄청 발전, 인류 엄청 발전"
    },
    () =>
    {
        GameManager.instance.topLayer.energy.environment += 200;
        GameManager.instance.topLayer.energy.people += 200;
        StartCoroutine(CheatCoroutine());

        //GameManager.instance.topLayer.
    }),
    new Que.Answer("싫어요.",
    new string[]
    {
                "뒷 일은 책임 못 집니다.",
    },
    new string[]
    {
                "전염병으로 인구 전체가 사망했다.",
    },
    () =>
    {
        GameManager.instance.topLayer.energy.people -= 100;
    })
    ));
        #endregion


        #region 연구원 증기 기관 개발?

        quests.Add(
    new Que(3, new string[] {
                "안녕하세요! 저는\n연구원 이정태라고 합니다.",
                "석탄을 통해 혁신적인\n증기 기관이라는 기술을 발명해냈는데",
                "지구의 발전 차원에서\n지원 의사 표명을 부탁드립니다!"
    }, new Que.Answer("연구를\n지원하죠.",
    new string[]
    {
                "하하! 정말 감사합니다!",
    },
    new string[]
    {
                "증기 기관의 개발에 성공했다!",
                "공장이 보급되어\n전 세계에 혁명이 이루어졌다!",
                "환경 20 감소, 석탄 3단계, 산업 혁명 돌입"
    },
    () =>
    {
        GameManager.instance.topLayer.energy.environment -= 20;
        GameManager.instance.topLayer.energy.coal = 3;
        GameManager.instance.uiManager.picture.Next();
        //GameManager.instance.topLayer.
    }),
    new Que.Answer("잡상인\n안 받아요.",
    new string[]
    {
                "후회하실 겁니다.\n다음에 또 찾아오죠.",
    },
    new string[]
    {
                "아무 일도 일어나지 않았다.",
    },
    () =>
    {
        GameManager.instance.currentIndex -= 1;
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

    IEnumerator CheatCoroutine()
    {
        yield return new WaitForSeconds(1);
        GameManager.instance.uiManager.picture.Next();
        yield return new WaitForSeconds(1);
        GameManager.instance.uiManager.picture.Next();
        yield return new WaitForSeconds(1);
        GameManager.instance.uiManager.picture.Next();
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

    public Que(int who, string[] words, Answer left, Answer right)
    {
        this.who = who;
        this.words = words;
        this.left = left;
        this.right = right;
    }
}
