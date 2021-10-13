using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparecedor : MonoBehaviour
{

    public GameObject Vida;
    public GameObject Dano;
    public GameObject Escudo;
    public GameObject Ponto;

    public GameObject[] UI_Objects;

    int Chance = 0;
    int Chance2 = 0;
    Player P1;


    private void Awake()
    {
        P1 = FindObjectOfType<Player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UI_Objects[0].SetActive(false);
        UI_Objects[1].SetActive(false);
        UI_Objects[2].SetActive(true);
    }

    private void LateUpdate()
    {

        if (!GlobalVariables.Instance.jogando)
        {

            if (UI_Objects[0].activeSelf) UI_Objects[0].SetActive(false);
            if (UI_Objects[1].activeSelf) UI_Objects[1].SetActive(false);
            if (!UI_Objects[2].activeSelf) UI_Objects[2].SetActive(true);

            return;

        }
        else
        {
            if (!UI_Objects[0].activeSelf) UI_Objects[0].SetActive(true);
            if (!UI_Objects[1].activeSelf) UI_Objects[1].SetActive(true);
            if (UI_Objects[2].activeSelf) UI_Objects[2].SetActive(false);
        }

        if(!Vida.activeSelf && !Dano.activeSelf && !Escudo.activeSelf && !Ponto.activeSelf)
        {
            if(P1.Health == 3  || P1.Escudo_Shield.activeSelf)
            {
                Chance2 = Random.Range(0, 3);
            } else
            {
                Chance2 = 0;
            }

            Chance = Random.Range(0, 4);

            switch (Chance)
            {
                case 0:
                    Ponto.SetActive(true);
                    break;     
                    
                case 1:
                    Dano.SetActive(true);
                    break;

                case 2:

                    switch (Chance2)
                    {
                        case 0: Escudo.SetActive(true); break;
                        case 1: Ponto.SetActive(true); break;
                        default: Dano.SetActive(true); break;
                    }

                    break;

                case 3:

                    switch (Chance2)
                    {
                        case 0: Vida.SetActive(true); break;
                        case 1: Ponto.SetActive(true); break;
                        default: Dano.SetActive(true); break;
                    }

                    break;

            }


        }


    }
}
