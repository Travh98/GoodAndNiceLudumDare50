using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameanimator : MonoBehaviour
{
    public GameObject mabel;
    public GameObject albert;

    private void Start()
    {
        mabel.GetComponent<Animator>().Play("MabelDie");
        albert.GetComponent<Animator>().Play("AlbertDeath");
    }
}
