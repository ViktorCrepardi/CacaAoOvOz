using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjVoadores : MonoBehaviour
{

    Vector3 PositionLeft = new Vector3(-4, 7, -1.1f);
    Vector3 PositionMiddle = new Vector3(0, 7, -1.1f);
    Vector3 PositionRight = new Vector3(4, 7, -1.1f);

    Vector3 InitialSpeed = new Vector3(0, 0.09f, 0);
    Vector3 MiddleSpeed = new Vector3(0, 0.18f, 0);
    Vector3 LudicrousSpeed = new Vector3(0, 0.27f, 0);

    Vector3 CurrentSpeed;

    int positionNumber = 0;

    private void Awake()
    {
        CurrentSpeed = InitialSpeed;
    }
    private void Start()
    {

        positionNumber = Random.Range(0, 3);

        switch (positionNumber)
        {
            case 0: this.transform.position = PositionLeft; break;
            case 1: this.transform.position = PositionMiddle; break;
            case 2: this.transform.position = PositionRight; break;
        }
        
        
    }

    private void OnEnable()
    {
        positionNumber = Random.Range(0, 3);

        switch (positionNumber)
        {
            case 0: this.transform.position = PositionLeft; break;
            case 1: this.transform.position = PositionMiddle; break;
            case 2: this.transform.position = PositionRight; break;
        }

        if (GlobalVariables.Instance.score >= 20 && GlobalVariables.Instance.score <= 40)
        {
            if (CurrentSpeed != MiddleSpeed)
            {
                CurrentSpeed = MiddleSpeed;
            }
        } else if(GlobalVariables.Instance.score > 40)
        {
            if (CurrentSpeed != LudicrousSpeed)
            {
                CurrentSpeed = LudicrousSpeed;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= CurrentSpeed; //Mover para baixo
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.transform.position -= new Vector3(0, 4, 0) * Time.deltaTime;

        if(this.gameObject.tag == "Ponto" && collision.name != "Jogador")
        {
            if (GlobalVariables.Instance.score > 0 && GlobalVariables.Instance.score < 50)
            {
                GlobalVariables.Instance.score--;

            } else if (GlobalVariables.Instance.score > 50)
            {
                {
                    GlobalVariables.Instance.score -= 2;
                }
            }
        } 

        this.gameObject.SetActive(false);
    }

}
