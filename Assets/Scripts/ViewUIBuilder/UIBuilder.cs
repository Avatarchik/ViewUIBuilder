using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using System.Collections.Generic;
using ViewUIBuilder.Helpers.Components.Log;

public class UIBuilder : MonoBehaviour {

    #region Singleton
    static private UIBuilder instance;
    static public UIBuilder Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }
    #endregion

    #region Initialize
    static private GameObject go;
    
    static public void Initialize(GameObject gameObject, GameObject views)
    {
        go = gameObject;
        go.AddComponent<UIBuilder>();

        instance.Init(views);
    }
    #endregion
    
    private string configPath = "/resources/configUIBuilder.xml";

    private Canvas canvas;
    private ConfigXML config;

    public static ViewBuilderXML viewXML;

    private ArrayList arrayOfComponents = new ArrayList();

    private List<GameObject> canvasList = new List<GameObject>();

    // Use this for initialization
    public void Init(GameObject views) {
        XmlSerializer serializer = new XmlSerializer(typeof(ConfigXML));

        using (Stream reader = new FileStream(Application.dataPath + "/../" + configPath, FileMode.Open))
        {
            // Call the Deserialize method to restore the object's state.
            config = (ConfigXML)serializer.Deserialize(reader);
        }
        if(config == null)
        {
            Application.Quit();
        }
        
        // Load image
        MediaLoader mediaLoader = new MediaLoader(config.mediaPath);

        // TEST LOAD FONT
        /*WWW fontwww = new WWW(Application.dataPath + "../../resources/NewJune-Bold.otf");
        //Font font = fontwww.bytes as Font;
        Font font = new Font();

        string[] fonts = Font.GetOSInstalledFontNames();
        foreach (string fontName in fonts)
        {
            Debug.Log("fonts = " + fontName);
        }*/

        // Create Canvas
        createCanvas(config, views);

        init();

        BroadcastMessage("UiFinishedLoading", SendMessageOptions.DontRequireReceiver);
    }

    private void createCanvas(ConfigXML config, GameObject views)
    {
        foreach (var canva in config.Canvas)
        {
            GameObject gameObjectParent = new GameObject();
            gameObjectParent.name = canva.id;
            gameObjectParent.transform.SetParent(views.transform);
            gameObjectParent.AddComponent<RectTransform>();

            GameObject gameObjectCanvas = new GameObject();
            gameObjectCanvas.name = "UIContainer";
            gameObjectCanvas.transform.SetParent(gameObjectParent.transform);
            Canvas cv = gameObjectCanvas.AddComponent<Canvas>();
            cv.planeDistance = canva.planeDistance;
            cv.sortingOrder = canva.order;
            canvas = gameObjectCanvas.GetComponent<Canvas>();
            gameObjectCanvas.AddComponent<CanvasScaler>();
            gameObjectCanvas.AddComponent<GraphicRaycaster>();

            if (canva.renderMode == "ScreenSpaceOverlay")
            {
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }
            else if (canva.renderMode == "ScreenSpaceCamera")
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = Camera.main;
            }
            else if (canva.renderMode == "WorldSpace")
            {
                canvas.renderMode = RenderMode.WorldSpace;
            }

            CanvasScaler canvasScaler = gameObjectCanvas.GetComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;

            RectTransform rectCanvas = gameObjectCanvas.GetComponent<RectTransform>();
            rectCanvas.localScale = Vector2.one;
            rectCanvas.pivot = Vector2.zero;

            canvasList.Add(gameObjectCanvas);
        }
        // Create eventSystem
        GameObject eventSystemObject = new GameObject();
        eventSystemObject.name = "EventSystem";
        eventSystemObject.AddComponent<EventSystem>();
        eventSystemObject.AddComponent<StandaloneInputModule>();
    }

    private void init()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ViewBuilderXML));
        print(Application.dataPath);
        foreach (AppViewsView appView in config.Views)
        {
            string path = config.viewPath + appView.file;
            Log.Instance.Info("Loading view = " + path);
            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                GameObject gameObjectParent = GameObject.Find(appView.idCanvas);

                viewXML = (ViewBuilderXML)serializer.Deserialize(reader);
                // Create game object da view
                GameObject view = new GameObject();
                view.name = viewXML.id;
                GameObject gameObjectCanvas = gameObjectParent.transform.Find("UIContainer").gameObject;
                view.transform.parent = gameObjectCanvas.transform;
                view.transform.SetSiblingIndex(0);
                RectTransform rectTransform = view.AddComponent<RectTransform>();
                rectTransform.localScale = Vector3.one;
                if ((viewXML.width != 0) && (viewXML.height != 0))
                {
                    Vector2 size = new Vector2(viewXML.width, viewXML.height);
                    rectTransform.sizeDelta = size;
                }
                if (viewXML.origPosition.ToLower() == "lowerleft")
                {
                    rectTransform.localPosition = new Vector3(viewXML.x - viewXML.width/2, viewXML.y - viewXML.height/2);
                }
                else
                {
                    rectTransform.localPosition = new Vector3(viewXML.x, viewXML.y);
                }

                foreach (ViewComponent component in viewXML.Components)
                {
                    ViewBuilderBaseComponent baseComponent;
                    if (component.type == "GROUP")
                    {
                        baseComponent = new ViewBuilderGroup(view.transform, component);
                    }
                    else if (component.type == "BUTTON")
                    {
                        baseComponent = new ViewBuilderButton(view.transform, component);
                    }
                    else if (component.type == "IMAGE")
                    {
                        baseComponent = new ViewBuilderImage(view.transform, component);
                    }
                    else if (component.type == "TEXTAREA")
                    {
                        baseComponent = new ViewBuilderText(view.transform, component);
                    }
                    else if (component.type == "ANIMATION")
                    {
                        baseComponent = new ViewBuilderAnimation(view.transform, component);
                    }
                    else if (component.type == "INPUT")
                    {
                        baseComponent = new ViewBuilderInput(view.transform, component);
                    }
                    else if (component.type == "SLIDER")
                    {
                        baseComponent = new ViewBuilderSlider(view.transform, component);
                    }
                    else if (component.type == "DROPDOWN")
                    {
                        baseComponent = new ViewBuilderDropdown(view.transform, component);
                    }
                    else if (component.type == "VIDEO")
                    {
                        baseComponent = new ViewBuilderVideo(view.transform, component);
                    }
                    else if (component.type == "MASK")
                    {
                        baseComponent = new ViewBuilderMask(view.transform, component);
                    }
                    else if (component.type == "PLANE")
                    {
                        baseComponent = new ViewBuilderPlane(view.transform, component);
                    }
                    else
                    {
                        baseComponent = new ViewBuilderBaseComponent();
                    }
                    arrayOfComponents.Add(baseComponent);
                }

                if(viewXML.script != null)
                {
                    view.AddComponent(Type.GetType("Assets.Scripts." + viewXML.script));
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	    foreach(var component in arrayOfComponents)
        {
            ViewBuilderButton button = component as ViewBuilderButton;
            if(button != null)
            {
                button.Update();
            }
            ViewBuilderAnimation animation = component as ViewBuilderAnimation;
            if (animation != null)
            {
                animation.Update();
            }
        }
	}

    public ViewBuilderBaseComponent getObjectById(string id)
    {
        ViewBuilderBaseComponent obj = null;
        foreach (ViewBuilderBaseComponent component in arrayOfComponents)
        {
            if(component.component.id == id)
            {
                obj = component;
                break;
            }
        }
        return obj;
    }
}
