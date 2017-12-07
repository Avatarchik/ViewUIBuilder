using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ViewBuilderButton: ViewBuilderBaseComponent
{
	public delegate void MouseUp(string name);
	public static MouseUp OnMouseUp;

    private GameObject button;
    private ViewBuilderText text;

    private Sprite[] arraySprite = new Sprite[2];

    private Vector3 newScale;
    private Vector3 buttonPosition;
    private Vector3 newPosition;

    private bool radioButtonMode = false;
    private bool radioButtonClicked = true;

	#region Singleton
	static private ViewBuilderButton instance;
	static public ViewBuilderButton Instance { get { return instance; } }
	#endregion

    public ViewBuilderButton(Transform panel, ViewComponent _component) : base(panel, _component)
    {
		if (instance == null)
			instance = this;
        createButton();
        createText();
    }

    private void createButton()
    { 
        button = new GameObject();
        button.transform.parent = container.transform;
        button.name = "button";
        radioButtonMode = component.config.radioButtonMode;
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        ButtonEvent buttonEvent = button.AddComponent<ButtonEvent>();
        buttonEvent.myDelegateDown = onMouseDown;
        buttonEvent.myDelegateUp = onMouseUp;
        buttonEvent.myDelegateDeactivate = deactivate;
        MediaLoader.MediaModel mediaModel = MediaLoader.instance.getMediaById(component.imageArray[0].id);
        if(mediaModel.image != null)
        {
            button.GetComponent<Image>().sprite = mediaModel.image[0];
            arraySprite[0] = mediaModel.image[0];
        }
        if (component.imageArray.Length > 1)
        {
            mediaModel = MediaLoader.instance.getMediaById(component.imageArray[1].id);
            Debug.Log("mediaModel = " + mediaModel.id + " - " + mediaModel.image);
            if (mediaModel.image != null)
            {
                arraySprite[1] = mediaModel.image[0];
            }
        }
        RectTransform recTransform = button.GetComponent<RectTransform>();
        recTransform.pivot = Vector2.up;
        recTransform.localPosition = new Vector3(0, 0, 0);
        if ((component.objHeight != 0) && (component.objWidth != 0))
        {
            size = new Vector2(component.objWidth, component.objHeight);
        }
        else
        {
            size = new Vector2(arraySprite[0].rect.width, arraySprite[0].rect.height);
        }
        recTransform.sizeDelta = size;
        newScale = recTransform.localScale;
        buttonPosition = newPosition = recTransform.localPosition;
    }

    private void createText()
    {
        ViewComponent textComponent = new ViewComponent();
        textComponent.id = component.id + "_text";
        textComponent.groupId = "";
        textComponent.text = component.text;
        textComponent.textArray = component.textArray;
        textComponent.x = 0;
        textComponent.y = 0;
        text = new ViewBuilderText(button.transform, textComponent);
        text.hideText(1);
    }

    // Use this for initialization
    public void Update () {
        if(newScale != button.GetComponent<RectTransform>().localScale)
        {
            button.GetComponent<RectTransform>().localScale = Vector3.Lerp(button.GetComponent<RectTransform>().localScale, newScale, Time.deltaTime * 15f);
        }
        if (newPosition != button.GetComponent<RectTransform>().localPosition)
        {
            button.GetComponent<RectTransform>().localPosition = Vector3.Lerp(button.GetComponent<RectTransform>().localPosition, newPosition, Time.deltaTime * 15f);
        }
    }

    public void onMouseDown(PointerEventData data)
    {
        Debug.Log("onMouseDown Button");
        if(arraySprite.Length > 1)
        {
            button.GetComponent<Image>().sprite = arraySprite[1];
        }
        if(component.textArray.Length > 1)
        {
            text.hideText(0);
            text.showText(1);
        }
        Vector3 newSize = new Vector2(arraySprite[0].rect.width * component.config.increasePercent, arraySprite[0].rect.height * component.config.increasePercent);
        newScale = button.GetComponent<RectTransform>().localScale * component.config.increasePercent;
        newPosition = new Vector3(buttonPosition.x + (size.x - newSize.x)/2, buttonPosition.y - (size.y - newSize.y)/2, buttonPosition.z);

        if (radioButtonMode)
        {
            radioButtonClicked = !radioButtonClicked;
        } 
    }

    public void onMouseUp(PointerEventData data)
    {
        Debug.Log("onMouseUp Button = " + container.name);

        //Transform parentView = null;
        //while(parentView )
		//Debug.Log(container.name);
		if(ViewBuilderButton.OnMouseUp!=null) ViewBuilderButton.OnMouseUp(container.name);

        Transform broadcastObj = container.transform.parent;
        while(broadcastObj.parent.name.IndexOf("Canvas") == -1)
        {
            broadcastObj = broadcastObj.parent;
        }
        broadcastObj.BroadcastMessage("ButtonMouseUp", container.name, SendMessageOptions.DontRequireReceiver);
        
        if (radioButtonMode)
        {
            if(!radioButtonClicked)
            {
                return;
            }
        }
        deactivate(null);
    }

    public void deactivate(PointerEventData data)
    {
        Debug.Log("Deactivate = " + container.name);
        button.GetComponent<Image>().sprite = arraySprite[0];
        text.hideText(1);
        text.showText(0);
        newScale = Vector3.one;
        newPosition = buttonPosition;
        radioButtonClicked = true;
    }
}
