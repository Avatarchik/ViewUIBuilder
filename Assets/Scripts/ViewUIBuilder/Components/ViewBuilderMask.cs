using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewBuilderMask: ViewBuilderBaseComponent
{

    public ViewBuilderMask(Transform panel, ViewComponent _component) : base(panel, _component)
    {
        createImage();
    }

    private void createImage()
    {
        //gameObject.transform.position = position;
        RectTransform recTransform = container.AddComponent<RectTransform>();
        //recTransform.pivot = Vector2.up;
        Vector2 size = Vector2.zero;
        recTransform.localScale = Vector3.one;
        if (component.config.maskType.ToLower() == "mask")
        {
            container.AddComponent<Image>();
            MediaLoader.MediaModel mediaModel = MediaLoader.instance.getMediaById(component.mediaId);
            if (mediaModel.image != null)
            {
                container.GetComponent<Image>().sprite = mediaModel.image[0];
            }
            if ((component.objHeight != 0) && (component.objWidth != 0))
            {
                size = new Vector2(component.objWidth, component.objHeight);
            }
            else
            {
                size = new Vector2(mediaModel.image[0].rect.width, mediaModel.image[0].rect.height);
            }
            container.AddComponent<Mask>();
        }
        else if(component.config.maskType.ToLower() == "rectmask")
        {
            if ((component.objHeight != 0) && (component.objWidth != 0))
            {
                size = new Vector2(component.objWidth, component.objHeight);
            }
            recTransform.pivot = new Vector2(0, 0.5f);
            container.AddComponent<RectMask2D>();
        }
        else
        {
            container.AddComponent<RectMask2D>();
        }
        recTransform.sizeDelta = size;
    }
}
