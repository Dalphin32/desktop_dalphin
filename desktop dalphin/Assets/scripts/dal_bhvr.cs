using System.Threading;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;

public class dal_bhvr : MonoBehaviour
{
    private Animator animator;
    private float timer;
    private float evt_time;
    private dal_events events;
    [SerializeField] private GameObject[] objs_to_throw;
    public int current_evt, evt_chance, line_count;
    private string line_to_read;
    private int taunt_to_do;
    private float new_pos;
    private int stop_dizzy;

    private settings_data.DalSettings stgs;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     events = GetComponent<dal_events>();
     timer = 0.0f;   
     current_evt = -1;
     animator = GetComponent<Animator>();
     taunt_to_do = 0;
     stgs = GameObject.Find("manager").GetComponent<settings_data>().get_settings();
     evt_time = Random.Range(stgs.MinIdleTime,stgs.MaxIdleTime);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("anim_idx", current_evt);
        animator.SetInteger("taunt_idx", taunt_to_do);

        if (timer < evt_time && current_evt == -1) {
            timer += Time.deltaTime;
        }

        if(gameObject.GetComponent<Rigidbody2D>()!=null){
                Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
                if(rb.linearVelocity.x == 0 && rb.linearVelocity.y == 0 && stop_dizzy == 10){
                    transform.eulerAngles = Vector3.zero;
                    transform.position = new Vector3(transform.position.x, -1, 0);
                    Destroy(rb);
                    Destroy(GetComponent<CapsuleCollider2D>());
                    current_evt =-1;
                    stop_dizzy = 0;
                } 
                if (rb.linearVelocity.x == 0 && rb.linearVelocity.y == 0){
                    stop_dizzy++;
                } 
        }

        if (timer >= evt_time){
            timer = 0;
            evt_time = Random.Range(stgs.MinIdleTime,stgs.MaxIdleTime);
            //determines which event to do
            evt_chance = Random.Range(0,100);
            if (evt_chance >= 0 && evt_chance < 10) current_evt = 1;
            else if (evt_chance >= 10 && evt_chance < 20) current_evt = 2;
            else if (evt_chance >= 20 && evt_chance < 30 && stgs.Annoying) current_evt = 3;
            else if (evt_chance >= 30 && evt_chance < 40 && stgs.Annoying) current_evt = 4;
            else current_evt = 0;

            //testing specific event
            //.current_evt = 4;            

            switch(current_evt){
                case 0:
                    new_pos = Random.Range(-2.0f,2.0f);
                break;

                case 1:
                    taunt_to_do = Random.Range(0,3);
                break;

                case 2: 
                    line_count = File.ReadLines("Assets/StreamingAssets/text_pool.txt").Count();
                    int picked_line = Random.Range(1,line_count);
                    StreamReader reader = new StreamReader("Assets/StreamingAssets/text_pool.txt");
                    for(int l = 1; l < picked_line; l++){
                        reader.ReadLine();
                    }
                    line_to_read = reader.ReadLine();
                break;

                case 3:
                    
                break;

                case 4:
                    //throw
                break;
            }
        }

        switch(current_evt){
            case -1:
                //idle
            break;

            case 0:
                events.walk(new_pos);
            break;

            case 1:
                //animation
            break;

            case 2:
                //print(line_to_read);
                events.talk(line_to_read);
            break;

            case 3:
                //explote
            break;

            case 4:
                //throw obj
            break;
        }
    }

    public GameObject[] get_objs(){
        return objs_to_throw;
    }
}
