using UnityEngine;
using UnityEngine.EventSystems;

public class aimeScereen : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IPointerClickHandler
{


  
    public Vector2 TouchDist;


    float touchx1, touchy1;
    float touchx, touchy;

    bool Pressed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {

            TouchDist = new Vector2(( Input.mousePosition.x -touchx1) * Time.deltaTime, ( Input.mousePosition.y - touchy1 ) * Time.deltaTime);
            TouchDist.x = Mathf.Clamp(TouchDist.x, -1, 1);
            TouchDist.y = Mathf.Clamp(TouchDist.y, -1, 1);
        }
        else
        {
            TouchDist = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        touchx1 = Input.mousePosition.x;
        touchy1 = Input.mousePosition.y;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
    }
}
