using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen_Display : MonoBehaviour
{
    public GameObject PlayerArea;
    public GameObject CPUArea;
    public GameObject BigBlocker;

    public GameObject EndScreen;

    public GameObject YouLose;
    public GameObject YouWin;

    public void DisplayWinScreen()
    {
        //PlayerArea.SetActive(false);
        //CPUArea.SetActive(false);
        BigBlocker.SetActive(true);

        EndScreen.SetActive(true);
        YouLose.SetActive(false);
        YouWin.SetActive(true);
    }

    public void DisplayLoseScreen()
    {
        //PlayerArea.SetActive(false);
        //CPUArea.SetActive(false);
        BigBlocker.SetActive(true);

        EndScreen.SetActive(true);
        YouLose.SetActive(true);
        YouWin.SetActive(false);
    }
}
