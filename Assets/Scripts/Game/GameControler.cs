using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] questions = new GameObject[3];

    [SerializeField]
    private GameObject pacoca;

    private Animator pacocaAnim;

    [SerializeField]
    private GameObject tutorial;

    public int QuantPlay = 0;

    [SerializeField]
    private GameObject finalScreen;

    private int currentStep = 0;

    private int quantItem;

    [SerializeField]
    private Animator sacolaAndAdelaide;
    [SerializeField]
    private Animator pincel;

    [SerializeField]
    private GameObject relogio;

    [SerializeField]
    private AudioSource pointAudio;

    private void Awake()
    {
        ShuffleQuestions();
    }

    private void Start()
    {
        pacocaAnim = pacoca.GetComponent<Animator>();

    }

    public void CloseTutoAndStart() //FECHA TUTORIAL E INICIA GAME
    {
        tutorial.SetActive(false);
        StartCoroutine(StartTurn());
    }

   IEnumerator StartTurn() //INICIA TURNO
    {
        //animacao inicial aqui
        yield return new WaitForSeconds(4f);

        questions[currentStep].SetActive(true);
    }


    IEnumerator StartLvl()
    {
        yield return new WaitForSeconds(2f);
        questions[currentStep].SetActive(true);
    }


    public void addItem()
    {
        pointAudio.Play();
        pincel.SetTrigger("point");
        sacolaAndAdelaide.SetTrigger("point");

        if (quantItem < 4)
        {
            quantItem++;
        }

        if(quantItem == 4) //sacola cheia
        {

            ChangeGroup();
        }
    }    

    private void ChangeGroup()
    {
        questions[currentStep].SetActive(false);

        if (currentStep < 2)
        {
            currentStep++;
            quantItem = 0;
            StartCoroutine(StartLvl());
        }
        else
        {
            relogio.SetActive(false);
            sacolaAndAdelaide.SetTrigger("win"); //anim final
            StartCoroutine(EndLvl());
        }


        }

    IEnumerator EndLvl()
    {

        yield return new WaitForSeconds(5f);
        finalScreen.SetActive(true);

    }

    private void ShuffleQuestions()     //EMBARALHAR FRASES
    {
        for (int i = 0; i < questions.Length; i++)
        {
            GameObject obj = questions[i];
            int randomizeArray = Random.Range(0, i);
            questions[i] = questions[randomizeArray];
            questions[randomizeArray] = obj;
        }
    }




}
