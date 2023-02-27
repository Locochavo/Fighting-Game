using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour

{


    public GameObject LookRight()

    {
       RaycastHit2D hit = Physics2D.Raycast(transform.localPosition,  Vector2.right);
   




        return hit.collider.gameObject;

    }


    public GameObject LookLeft()


    {
        RaycastHit2D hit = Physics2D.Raycast(transform.localPosition, Vector2.left);





        return hit.collider.gameObject;

    }









}
