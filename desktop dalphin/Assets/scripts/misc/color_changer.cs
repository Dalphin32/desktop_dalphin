using UnityEngine;

public class color_changer : MonoBehaviour
{
    public void randomize_color(GameObject obj){
        float r = Random.Range(0f,0.99f);
        float g = Random.Range(0f,0.99f);
        float b = Random.Range(0f,0.99f);
        int full_color = Random.Range(0,3);
        switch(full_color){
            case 0:
                r = 1f;
            break;
            case 1:
                g = 1f;
            break;
            case 2:
                b = 1f;
            break;
        }
        obj.GetComponent<SpriteRenderer>().color = new Color(r,g,b);
    }
}
