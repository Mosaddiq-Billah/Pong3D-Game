using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class racketscript : MonoBehaviour
{

    public GameObject upArrow;
    public float speed = 4f;
    bool boolFlag = false;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        EventTrigger ArrowObj = upArrow.AddComponent<EventTrigger>();

        //we are creating an event object(pressedbtn) of class EventTrigger.Entry and we are setting the attribute of PointerDown event for the pressedbtn object . now the pressedbtn object will be created having arrtibute of PointerDown event... then we will assign a function to that event object,the object has the ability to listen to event by add attribute to it of eventListner now the function will be envoked when the event of object-event will occur.
        EventTrigger.Entry pressedbtn = new EventTrigger.Entry()
        {
            eventID = EventTriggerType.PointerDown
        };


        EventTrigger.Entry unpressed = new EventTrigger.Entry()
        {
            eventID = EventTriggerType.PointerUp
        };

        pressedbtn.callback.AddListener(setboolFlagTrue);
        unpressed.callback.AddListener(setboolFlagFalse);

        //now we are feeding event to the arrowObj so that arrow object could listen to those event and perform corresponding functionality according to the call back function
        ArrowObj.triggers.Add(pressedbtn);
        ArrowObj.triggers.Add(unpressed);
    }

    // Update is called once per frame
    void Update()
    {
        if (boolFlag) { 
        
            //rb.velocity = Vector3.forward * speed;
            //gameObject.transform.Translate(new Vector3(0, 0, speed*Time.deltaTime));
            gameObject.transform.Translate(Vector3.back*speed*Time.deltaTime);
        }
       

    }


    public void setboolFlagTrue(BaseEventData data)
    {
        boolFlag = true;
    }

    public void setboolFlagFalse(BaseEventData data)
    {
        boolFlag = false;
    }
}


