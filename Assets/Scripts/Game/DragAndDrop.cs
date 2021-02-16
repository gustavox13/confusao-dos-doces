using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private float startPosX;    // VARIAVEL AJUSTE DO MOUSE
    private float startPosY;    // VARIAVEL AJUSTE DO MOUSE
    private GameObject CorrectPlace;    //PEGA LUGAR CORRETO NA TELA
    private Vector3 initialPosition;    //POSICAO INICIAL DO OBJ NA TELA
    [SerializeField]
    private bool isCorrectLocal = false;    //VERIFICA SE ESTA NO LOCAL CORRETO
    private Color colorAlpha;   //TRANSPARENCIA DO OBJ
    [SerializeField]
    private string tagCorreta;  //TAG CORRETA PARA ENCONTRAR

    [SerializeField]
    private GameObject controllerGame;

    private void Start()
    {
        colorAlpha = GetComponent<SpriteRenderer>().color; //pega cor do obj

        initialPosition = this.gameObject.transform.position; // pega posicao inicial do obj

        CorrectPlace = GameObject.FindGameObjectWithTag(tagCorreta); //localiza o lugar correto pela tag
    }
    

    private void OnMouseDrag() //QUANDO ESTIVER ARRASTANTO
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0.0f);
      
    }


    private void OnMouseDown() //QUANDO CLICAR
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            colorAlpha.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = colorAlpha;
        }
    }

    private void OnMouseUp() //QUANDO SOLTAR
    {
        colorAlpha.a = 1f;
        gameObject.GetComponent<SpriteRenderer>().color = colorAlpha;

        if (isCorrectLocal)
        {
            this.gameObject.transform.localPosition = CorrectPlace.transform.localPosition; // CENTRALIZA O OBJ NO LUGAR CERTO
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            controllerGame.GetComponent<GameControler>().addItem();
        }
        else
        {
            this.gameObject.transform.localPosition = initialPosition; // VOLTA O OBJ PARA A POSICAO INICIAL
        }
    }



    private void OnTriggerEnter2D(Collider2D collision) //ESTA DENTRO DO LUGAR CORRETO
    {
        if(collision.tag == tagCorreta) 
        {
            isCorrectLocal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //ESTA FORA DO LUGAR CORRETO
    {
        if (collision.tag == tagCorreta)
        {
            isCorrectLocal = false;
        }
    }

}
