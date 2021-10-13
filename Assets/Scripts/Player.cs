using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    GlobalVariables GV;

    public int Health = 3;
    public GameObject[] Posicoes = new GameObject[3]; // 0-Esquerda, 1-Meio, 2-Direita
    public GameObject Escudo_Shield;

    public GameObject[] Vidas = new GameObject[3];
    public AudioSource AS_Sounds;
    public AudioClip[] SFXs;

    // Start is called before the first frame update
    void Start()
    {
        GV = FindObjectOfType<GlobalVariables>();

        this.transform.position = Posicoes[1].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PularEsquerda()
    {
        if (this.transform.position == Posicoes[1].transform.position)
        {
            this.transform.position = Posicoes[0].transform.position;
            Debug.Log("Foi para esquerda, do meio para esquerda.");

        } else if (this.transform.position == Posicoes[2].transform.position)
        {
            this.transform.position = Posicoes[1].transform.position;
            Debug.Log("Foi para esquerda, da direita para o meio.");

        }
        
    }

    public void PularDireita()
    {
        if (this.transform.position == Posicoes[1].transform.position)
        {
            this.transform.position = Posicoes[2].transform.position;
            Debug.Log("Foi para direita, do meio para direita.");

        }
        else if (this.transform.position == Posicoes[0].transform.position)
        {
            this.transform.position = Posicoes[1].transform.position;
            Debug.Log("Foi para direita, da esquerda para o meio.");

        }
    }

    void VisualLife()
    {

        switch (Health)
        {
            case 3:
                if (!Vidas[2].activeSelf)
                {
                    Vidas[2].SetActive(true);
                }
                if (!Vidas[1].activeSelf)
                {
                    Vidas[1].SetActive(true);
                }
                if (!Vidas[0].activeSelf)
                {
                    Vidas[0].SetActive(true);
                }
                break;

            case 2:
                if (Vidas[2].activeSelf)
                {
                    Vidas[2].SetActive(false);
                }
                if (!Vidas[1].activeSelf)
                {
                    Vidas[1].SetActive(true);
                }
                if (!Vidas[0].activeSelf)
                {
                    Vidas[0].SetActive(true);
                }
                break;

            case 1:
                if (Vidas[1].activeSelf)
                {
                    Vidas[1].SetActive(false);
                }
                if (Vidas[2].activeSelf)
                {
                    Vidas[2].SetActive(false);
                }
                if (!Vidas[0].activeSelf)
                {
                    Vidas[0].SetActive(true);
                }
                break;

            case 0:

                if (Vidas[2].activeSelf)
                {
                    Vidas[2].SetActive(false);
                }
                if (Vidas[1].activeSelf)
                {
                    Vidas[1].SetActive(false);
                }
                if (Vidas[0].activeSelf)
                {
                    Vidas[0].SetActive(false);
                }
                GV.Ended();
                Debug.Log("Died");
                break;

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dano")
        {
            if (Escudo_Shield.activeSelf)
            {
                Escudo_Shield.SetActive(false);
                Debug.Log("Destruiu escudo");
                AS_Sounds.clip = SFXs[9]; AS_Sounds.Play();
            }
            else
            {
                Health--;

                if (Health == 0)
                {
                    AS_Sounds.clip = SFXs[4]; AS_Sounds.Play();
                }
                else
                {
                    int numba = Random.Range(0, 3);

                    switch (numba)
                    {
                        case 0: AS_Sounds.clip = SFXs[0]; AS_Sounds.Play(); break;
                        case 1: AS_Sounds.clip = SFXs[1]; AS_Sounds.Play(); break;
                        case 2: AS_Sounds.clip = SFXs[2]; AS_Sounds.Play(); break;
                    }
                }
                

                VisualLife();

                Debug.Log("Tomei dano - Health: " + Health);
            }

        }
        if (collision.gameObject.tag == "Vida")
        {
            if (Health < 3)
            {
                Health++;
                AS_Sounds.clip = SFXs[3]; AS_Sounds.Play();
                VisualLife();
                Debug.Log("Curei vida - Health: " + Health);
            } else
            {
                GV.score += 2;
            }
        }
        if (collision.gameObject.tag == "Escudo")
        {
            if (!Escudo_Shield.activeSelf)
            {
                AS_Sounds.clip = SFXs[5]; AS_Sounds.Play();
                Escudo_Shield.SetActive(true);
                Debug.Log("Peguei escudo");
            } else
            {
                GV.score += 1;
            }

        }

        if (collision.gameObject.tag == "Ponto")
        {
            GV.score += 2;

            int numba = Random.Range(0, 3);

            switch (numba)
            {
                case 0: AS_Sounds.clip = SFXs[6]; AS_Sounds.Play(); break;
                case 1: AS_Sounds.clip = SFXs[7]; AS_Sounds.Play(); break;
                case 2: AS_Sounds.clip = SFXs[8]; AS_Sounds.Play(); break;
            }

            Debug.Log("Peguei ponto");

        }
    }


}
