/*
Script with all the actions that the MegaMan X character can perform

Gilberto Echeverria
2023-02-20
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XActions : MonoBehaviour
{
    [SerializeField] GameObject xShot;
    [SerializeField] Transform shotSpawn;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Fire()
    {
        anim.SetTrigger("Shoot");
        Instantiate(xShot, shotSpawn.position, Quaternion.identity);
    }

    public void Celebrate()
    {
        anim.SetTrigger("Celebrate");
    }

    public void Damage()
    {
        anim.SetTrigger("Hit");
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }

    public void Run()
    {
        anim.SetBool("Run", true);
        Invoke("StopRunning", 2.0f);
    }

    public void StopRunning()
    {
        anim.SetBool("Run", false);
    }
}
