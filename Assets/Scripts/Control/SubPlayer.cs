using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPlayer : MonoBehaviour{

    public int Speed;

    private Vector3 vec;
    private int count = 0;



    // Use this for initialization
    void Start(){

        Animation ani = gameObject.GetComponent<Animation>();
        ani.Play("walk");
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other){
        if (other.tag == "trigger"){
            count++;
            vec = transform.position;
            vec.x = vec.x + 60;

            if (count == 2){
                vec.x = 0;
                count = 0;
            }

            transform.position = vec;

        }
    }

}
