using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager SharedInstance = null;
    public TextMeshProUGUI textZombieDead;


    //public Animator bombAnim;

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        //bombAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

   /*  public void BombAnimation()
    {
        bombAnim.Play("BombAnimation");
    }

    public void TextPerfect()
     {
         textZombieDead.text = "Perfect!";
         textZombieDead.gameObject.SetActive(true);
     }
     public void TextGood()
     {
         textZombieDead.text = "Good";
         textZombieDead.gameObject.SetActive(true);
     }
     public void TextClose()
     {
         textZombieDead.text = "Perfect!";
         textZombieDead.gameObject.SetActive(true);
     }*/


}
