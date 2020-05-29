using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMenager : MonoBehaviour
{
    [SerializeField] public Text text;
    [SerializeField] private int tutorialNumer = 0;
    [SerializeField] GameObject tutorialCanvas;
    [SerializeField] float timeScale;

    private enum States {T1,T2, T3, T4, T5, T6, T7, T8 };


    States St;

    void Tutorial_1()
    {
        text.text = "Witaj Optymisto w Świecie Polinjurii.\n Jestem GZEB.\n Będe podpowiadał ci czasem co powinieneś zrobić.\n" +
            "Na pewno nie znalazłeś sie tu przypadkowo.\n A jak tak to żadna róznica. Nie jesteś pierwszy.\n" +
                    "I tak nam pomożesz. Zresztą jak każdy bohater twojego pokroju.\n";
        if (Input.GetKeyDown(KeyCode.E))
        {
            St = States.T2;
            tutorialNumer += 1;
        }
    }
    void Tutorial_2()
    {
        text.text = "Nie ważne. Dobrze, że jesteś.\n Większość mieszkańców już dawno straciło sens życia i potrzebują cię.\n" +
                    "Ta niebezpieczna kraina wiele wieków temu została zaatakowana przez szarość i pozostawiona przez wszystkich Optymistów. \n" +
                    "Zarazić wszystko swoją magią Optymismu, by mieszkańcy Polinjurii mogli znowu cieszyć się życiem\n";
                    
        if (Input.GetKeyDown(KeyCode.E))
        {
            St = States.T3;
            tutorialNumer += 1;
        }
    }
    void Tutorial_3()
    {
        text.text = "Wierzę, że proroctwo się wypełni.\n Zaraz zaprowadzę cię do ostatniego istniejącego żródła optymizmu" +
                    ", ale zanim pójdziemy dam ci coś szybko" +
                    "Nie wiem dlaczego\n , ale każdy bohater na początku nie wie jak używać swoich umiejętności\n";
        if (Input.GetKeyDown(KeyCode.E))
        {
            St = States.T4;
            tutorialNumer += 1;
        }
    }
    void Tutorial_4()
    {
        text.text = "Dlatego dam ci tą pradawną księge w pradawnym języku. Tam powinieneś znależć wszstko co potrzebne.\n"+
                    " Poruszasz się na \n\n W S A D\nCeluj myszą i strzelaj jej lewym przyciskiem\n" +
                    "Wszelkich interakcji dokonuje sie za pomocą E\n Ten duży kolcek przesówa się za pomocą SPACE";
        if (Input.GetKeyDown(KeyCode.E))
        {
            St = States.T5;
            tutorialNumer += 1;
            Time.timeScale = 1;
        }
    }
    void Tutorial_5()
    {
        text.text = "Na początek, żeby się stąd wydostać musisz zestrzelić fioletowe blokady kreatywności\n" +
                    "To te fioletowe klocki. Prznajmnie tak wyglądają dla Optymistów. Z resztą musisz poradzić sobie sam";
        if (Input.GetKeyDown(KeyCode.E))
        {
            tutorialCanvas.SetActive(false);
            tutorialNumer += 1;
            Time.timeScale = 1;
        }
    }
    void Tutorial_6()
    {

    }
    void Tutorial_7()
    {

    }
    void Tutorial_8()
    {

    }

    void Start()
    {
        St = States.T1;
        tutorialNumer += 1;
        Time.timeScale = timeScale;
        
    }

    void Update()
    {
        if(St == States.T1) { Tutorial_1(); }
        else if (St == States.T2) { Tutorial_2(); }
        else if (St == States.T3)  { Tutorial_3(); }
        else if (St == States.T4) { Tutorial_4(); }
        else if (St == States.T5) { Tutorial_5(); }

    }
}
