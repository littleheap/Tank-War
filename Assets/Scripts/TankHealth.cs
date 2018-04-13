using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour{

    public int hp = 100;
    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;

    public Slider hpSlider;
    public Slider attackSlider;
    public KeyCode fireKey;

    private int hpTotal;
    private float deltaTotal;
    private float time1 = 0;
    private float time2 = 0;

    // Use this for initialization
    void Start(){
        hpTotal = hp;
        deltaTotal = 30.0f;
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(fireKey)) {
            time1 = Time.time;
        }

        if (Input.GetKey(fireKey)) {

            time2 = Time.time;

            float delta = time2 - time1;

            this.attackSlider.value = (float)delta * 10 / deltaTotal;
        }
            
    }

    void TankDamage(){
        if (hp <= 0){
            return;
        }

        hp -= Random.Range(10,20);

        hpSlider.value = (float)hp / hpTotal;

        if (hp <= 0) {
            AudioSource.PlayClipAtPoint(tankExplosionAudio,transform.position);

            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);

            GameObject.Destroy(this.gameObject);

            if (this.name.Equals("Tank2")){
                FollowTarget.green += 1;
                FollowTarget.round += 1;
            }
            else {
                FollowTarget.red += 1;
                FollowTarget.round += 1;
            }

            //重新开始
            SceneManager.LoadScene(0);
        }
    }


}
