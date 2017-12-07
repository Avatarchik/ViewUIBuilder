using UnityEngine;
using UnityEngine.UI;

public class ViewBuilderAnimation : ViewBuilderBaseComponent
{
    private GameObject image;
    private int posAnimation = 0;
    private float initTimer;

    public ViewBuilderAnimation(Transform panel, ViewComponent _component) : base(panel, _component)
    {
        createImage();
    }

    private void createImage()
    {
        image = new GameObject();
        image.transform.parent = container.transform;
        image.name = "image";
        //gameObject.transform.position = position;
        image.AddComponent<Image>();
        MediaLoader.MediaModel mediaModel = MediaLoader.instance.getMediaById(component.mediaId);
        if (mediaModel.image != null)
        {
            image.GetComponent<Image>().sprite = mediaModel.image[0];
        }
        RectTransform recTransform = image.GetComponent<RectTransform>();
        recTransform.pivot = new Vector2(0.5f, 0.5f);
        recTransform.localPosition = new Vector3(0, 0, 0);
        if ((component.objHeight != 0) && (component.objWidth != 0))
        {
            size = new Vector2(component.objWidth, component.objHeight);
        }
        else
        {
            size = new Vector2(mediaModel.image[0].rect.width, mediaModel.image[0].rect.height);
        }
        recTransform.sizeDelta = size;
        startAnimation();
    }

    public void Update()
    {
        MediaLoader.MediaModel mediaModel = MediaLoader.instance.getMediaById(component.mediaId);
        if (mediaModel.image != null)
        {
            if (Time.time >= initTimer + component.config.animationTime)
            {
                posAnimation += 1;
            }
            if (posAnimation >= mediaModel.image.Length)
            {
                if (component.config.loop)
                {
                    startAnimation();
                }
                Transform parentView = container.transform;
                while(parentView.parent.GetComponent<Canvas>() == null)
                {
                    parentView = parentView.parent;
                }
                parentView.gameObject.BroadcastMessage("AnimationFinish", container.name, SendMessageOptions.DontRequireReceiver);
            }
            //Debug.Log("posAnimation = " + posAnimation + " - lenght = " + mediaModel.image.Length);
            if(mediaModel.image[posAnimation] == null)
            {
                Debug.Log("animacao nula = " + posAnimation);
            }
            image.GetComponent<Image>().sprite = mediaModel.image[posAnimation];
        }
    }

    private void startAnimation()
    {
        initTimer = Time.time;
        posAnimation = 0;
    }
}
