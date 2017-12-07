using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ViewUIBuilder.Helpers.Components.Log;

public class ViewBuilderImage: ViewBuilderBaseComponent
{

    private GameObject image;
    private ViewBuilderText text;

    public ViewBuilderImage(Transform panel, ViewComponent _component) : base(panel, _component)
    {
        createImage();
        createText();
    }

    private void createText()
    { 
        ViewComponent textComponent = new ViewComponent();
        textComponent.id = component.id + "_text";
        textComponent.groupId = component.id;
        textComponent.text = component.text;
        textComponent.textArray = component.textArray;
        textComponent.x = 0;
        textComponent.y = 0;
        text = new ViewBuilderText(container.transform, textComponent);
    }

    private void createImage()
    {
        MediaLoader.MediaModel mediaModel = MediaLoader.instance.getMediaById(component.mediaId);
        if (mediaModel.image == null)
        {
            Log.Instance.Error("Imagem com id " + component.mediaId + " não existe.");
            return;
        }
        image = new GameObject();
        image.transform.parent = container.transform;
        image.name = "image";
        image.AddComponent<Image>();
        if (mediaModel.image != null)
        {
            image.GetComponent<Image>().sprite = mediaModel.image[0];
        }
        RectTransform recTransform = image.GetComponent<RectTransform>();
        //recTransform.pivot = Vector2.up;
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
        recTransform.localScale = Vector3.one;
    }
}
