using System.Threading;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;

public class dal_events : MonoBehaviour
{
    [SerializeField] private int evt_len;
    private int text_idx;
    private bool add_letter;

    private Animator animator;
    private dal_bhvr behavior;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        behavior = GetComponent<dal_bhvr>();
        animator = GetComponent<Animator>();
        text_idx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int get_len(){
        return evt_len;
    }

    public void walk(float pos){
        if (transform.position.x < pos){
            transform.position = transform.position + new Vector3(0.5f*Time.deltaTime, 0,0);
            GetComponent<SpriteRenderer>().flipX = true;
        } 
        else if (transform.position.x > pos){
            transform.position = transform.position + new Vector3(-0.5f*Time.deltaTime, 0,0);
            GetComponent<SpriteRenderer>().flipX = false;
        } 
        
        if (transform.position.x > pos-0.2 && transform.position.x < pos+0.2){
            behavior.current_evt = -1;
        }
    }

    public void talk(string thing_to_say){
        add_letter = !add_letter;
        if (text_idx < thing_to_say.Length){
            if (add_letter){
                GetComponentInChildren<TextMeshProUGUI>().text += thing_to_say[text_idx];
                text_idx++;
            }
        }
        else{
            behavior.current_evt = -1;
            text_idx = 0;
            Invoke("reset_text",3.0f);
        }
    }
    public void reset_text(){
        GetComponentInChildren<TextMeshProUGUI>().text = "";
    }

    public void explode(){
        Object.Instantiate(Resources.Load<GameObject>("splosion"), transform.position, Quaternion.identity);

        Rigidbody2D rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        CapsuleCollider2D bc = gameObject.AddComponent(typeof(CapsuleCollider2D)) as CapsuleCollider2D;

        bc.direction = CapsuleDirection2D.Horizontal;
        bc.size = new Vector2(0.3f,0.165f);
        bc.offset = new Vector2(-0.02f,-0.04f);

        rb.gravityScale = 0.15f;
        float forceX = Random.Range(-150.0f, 150.0f);
        float forceY = Random.Range(100.0f, 120.0f);

        float angle = Mathf.Atan(forceY/forceX)*(180/3.14159f);
        rb.AddForce(new Vector2(forceX,forceY));
        rb.SetRotation((angle>=0)? angle-90:angle+90);
    }

    public void throw_obj(GameObject throwable){
        Object.Instantiate(throwable, transform.position, Quaternion.identity);
        behavior.current_evt = -1;
    }
}
