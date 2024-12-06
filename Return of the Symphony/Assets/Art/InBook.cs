using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBook : MonoBehaviour
{
    public GameObject characterTab;
    public GameObject weaponsTab;
    public GameObject bestiaryTab;
    public GameObject goBackButton;
    public GameObject description;
    public GameObject mainButtons;
    public GameObject catalog;
    public GameObject leftPage1Button;
    public GameObject leftPage2Button;
    public GameObject rightPage2Button;
    public GameObject rightPage3Button;
    public Animator animator;

    //animation event zodat ui opent zodra het boek open gaat
    public void OpenUI()
    {
        if (gameObject.activeInHierarchy)
        {
            rightPage2Button.SetActive(true);
            rightPage3Button.SetActive(true);
            bestiaryTab.SetActive(true);
            goBackButton.SetActive(true);
            description.SetActive(true);
            Debug.Log("book opened");
            animator.SetInteger("Book", 0);
        }
    }
    //animaation event zodat het boek uitgaat en de main buttons weer tevoorschijn komen
    public void CloseBook()
    {
        animator.SetInteger("Book", 0);
        catalog.SetActive(false);
        mainButtons.SetActive(true);
    }
    //button functions
    public void PageOne()
    {
        animator.SetInteger("Book", 1);
    }
    public void PageTwo()
    {
        animator.SetInteger("Book", 2);
    }
    public void PageThree()
    {
        animator.SetInteger("Book", 3);
    }
    //close book ui button function
    public void CloseBookButton()
    {
        leftPage1Button.SetActive(false);
        leftPage2Button.SetActive(false);
        rightPage2Button.SetActive(false);
        rightPage3Button.SetActive(false);
        goBackButton.SetActive(false);
        description.SetActive(false);
        bestiaryTab.SetActive(false);
        weaponsTab.SetActive(false);
        characterTab.SetActive(false);
        animator.SetInteger("Book", 4);
    }
    //animation event zodat alle ui uit kan en als de animatie afspeelt dat er dan geen ui in de weg staat
    public void CloseAllUI()
    {
        leftPage1Button.SetActive(false);
        leftPage2Button.SetActive(false);
        rightPage2Button.SetActive(false);
        rightPage3Button.SetActive(false);
        goBackButton.SetActive(false);
        description.SetActive(false);
        bestiaryTab.SetActive(false);
        weaponsTab.SetActive(false);
        characterTab.SetActive(false);
    }
    //animation event zodat alle ui aan gaat op de goeie pagina
    public void PageOneUI()
    {
        rightPage2Button.SetActive(true);
        rightPage3Button.SetActive(true);
        bestiaryTab.SetActive(true);
        goBackButton.SetActive(true);
        description.SetActive(true);
    }
    public void PageTwoUI()
    {
        leftPage1Button.SetActive(true);
        rightPage3Button.SetActive(true);
        weaponsTab.SetActive(true);
        goBackButton.SetActive(true);
        description.SetActive(true);
    }
    public void PageThreeUI()
    {
        leftPage1Button.SetActive(true);
        leftPage2Button.SetActive(true);
        characterTab.SetActive(true);
        goBackButton.SetActive(true);
        description.SetActive(true);
    }
}
