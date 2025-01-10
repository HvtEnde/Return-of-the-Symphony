//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using UnityEngine.UI;
//using Unity.VisualScripting;

//public class Interactor : MonoBehaviour
//{
//    public RaycastHit hit;
//    public float raycastMaxDistance;
//    public bool popupCheck = false;
//    public GameObject popup;
//    public LayerMask mask;


  

//    public void PopUp()
//    {
//        popupCheck = true;
//        popup.gameObject.SetActive(true);
//    }


//    public void PopUpInactive()
//    {
//        popupCheck = false;
//        popup.gameObject.SetActive(false);
//    }
    
//    void Update()
//    {
//        if(Physics.Raycast(transform.position, transform.forward,out hit, raycastMaxDistance, mask))
//        {
//            if (hit.collider.gameObject.GetComponent<Interactable>())
//            {
//                PopUp();

//                if (CompareTag("TrappedInstrument"))
//                {
//                    if (Input.GetButtonDown("Fire1"))
//                    {
//                        hit.collider.gameObject.GetComponent<Interactable>().InteractionWithCapturedInstrument();
//                    }
//                }
               
//            }
          
//        }
//        else
//        {
//            PopUpInactive();
//        }
//    }
//}
