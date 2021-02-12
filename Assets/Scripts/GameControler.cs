using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] questions = new GameObject[6];

    [SerializeField]
    private GameObject pacoca;

    private Animator pacocaAnim;

    [SerializeField]
    private GameObject tutorial;

    public int QuantPlay = 0;

    [SerializeField]
    private GameObject finalScreen;



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
        StartTurn();
    }

    private void StartTurn() //INICIA TURNO
    {

    }

    IEnumerator WrongAnswer() //RESPOSTA INCORRETA
    {
        pacocaAnim.SetTrigger("wrong");

        yield return new WaitForSeconds(1.5f);

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
