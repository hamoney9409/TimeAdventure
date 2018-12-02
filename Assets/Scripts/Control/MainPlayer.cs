using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour {

    public int Speed;
    public AnimationClip walk;
    public Animation anim;

    private Vector3 vec;
    private int count = 0;



    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        //anim.clip = walk;
        //anim.Play();
    }

    private void OnTriggerEnter(Collider other){

        if (other.tag == "trigger") {


            count++;
            vec = transform.position;
            vec.x = count * 100;


            if (count == 6){
                vec.x = 0;
                count = 0;
            }

            transform.position = vec;


        }
    }

}
