using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class AndroidControler : MonoBehaviour, TDragHandler, IPointerUpHandler, IPointerDownHandler {

    private Image bgImg;
    private Image joysticImg;
    private Vector3 inputVector;

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if()
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {

    }

    // Use this for initialization
    void Start () {
        bgImg = GetComponent<Image>();
        joysticImg = transform.GetChild(0).GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
