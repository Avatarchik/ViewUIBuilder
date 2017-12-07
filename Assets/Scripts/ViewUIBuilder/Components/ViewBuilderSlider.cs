using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ViewBuilderSlider : ViewBuilderBaseComponent
{

    public ViewBuilderSlider(Transform panel, ViewComponent _component) : base(panel, _component)
    {
        createSlider();
    }

    private void createSlider()
    {
        GameObject sliderGO = new GameObject();
        sliderGO.transform.parent = container.transform;
        sliderGO.name = "Slider";

        // add rect transform
        RectTransform sliderRect = sliderGO.AddComponent<RectTransform>();
        sliderRect.position = Vector3.zero;
        sliderRect.sizeDelta = new Vector2(component.objWidth, component.objHeight);
        sliderRect.anchorMax = new Vector2(0.5f, 0.5f);
        sliderRect.anchorMin = new Vector2(0.5f, 0.5f);
        sliderRect.pivot = new Vector2(0.5f, 0.5f);

        // add slider component
        Slider sliderComponent = sliderGO.AddComponent<Slider>();
        sliderComponent.minValue = 0;
        sliderComponent.maxValue = 255;

        // create background
        GameObject sliderBackground = new GameObject();
        sliderBackground.name = "Background";
        sliderBackground.transform.parent = sliderGO.transform;
        RectTransform sliderBackRect = sliderBackground.AddComponent<RectTransform>();
        sliderBackRect.anchorMax = new Vector2(0.5f, 0.5f);
        sliderBackRect.anchorMin = new Vector2(0.5f, 0.5f);
        sliderBackRect.pivot = new Vector2(0.5f, 0.5f);
        Image sliderBackImage = sliderBackground.AddComponent<Image>();
        MediaLoader.MediaModel mediaModel = MediaLoader.instance.getMediaById(component.imageArray[0].id);
        if (mediaModel.image != null)
        {
            sliderBackImage.sprite = mediaModel.image[0];
            sliderBackRect.sizeDelta = new Vector2(mediaModel.image[0].rect.width, mediaModel.image[0].rect.height);
        }

        // create fill area
        GameObject sliderFillArea = new GameObject();
        sliderFillArea.name = "Fill Area";
        sliderFillArea.transform.parent = sliderGO.transform;
        RectTransform sliderFillAreaRect = sliderFillArea.AddComponent<RectTransform>();
        sliderFillAreaRect.position = Vector3.zero;
        sliderFillAreaRect.sizeDelta = Vector2.one;
        sliderFillAreaRect.anchorMin = new Vector2(0.5f, 0.5f);
        sliderFillAreaRect.anchorMax = new Vector2(0.5f, 0.5f);
        sliderFillAreaRect.pivot = Vector2.zero;

        // create Fill
        GameObject sliderFill = new GameObject();
        sliderFill.name = "Fill";
        sliderFill.transform.parent = sliderFillArea.transform;
        RectTransform sliderFillRect = sliderFill.AddComponent<RectTransform>();
        sliderFillRect.position = Vector3.zero;
        sliderFillRect.anchorMin = new Vector2(0.5f, 0.5f);
        sliderFillRect.anchorMax = new Vector2(0.5f, 0.5f);
        sliderFillRect.pivot = new Vector2(0.5f, 0.5f);
        sliderFillRect.sizeDelta = new Vector2(296f, 50);
        Image sliderFillImage = sliderFill.AddComponent<Image>();
        mediaModel = MediaLoader.instance.getMediaById(component.imageArray[1].id);
        if (mediaModel.image != null)
        {
            sliderFillImage.sprite = mediaModel.image[0];
        }
        sliderFillImage.type = Image.Type.Filled;
        sliderFillImage.fillMethod = Image.FillMethod.Horizontal;
        sliderFillImage.fillOrigin = 0;
        sliderFillImage.preserveAspect = true;
        sliderComponent.fillRect = sliderFillRect;

        // create handle slide area
        GameObject sliderHandleArea = new GameObject();
        sliderHandleArea.name = "Handle Slide Area";
        sliderHandleArea.transform.parent = sliderGO.transform;
        RectTransform sliderHandleAreaRect = sliderHandleArea.AddComponent<RectTransform>();
        sliderHandleAreaRect.anchorMin = new Vector2(0.5f, 0.5f);
        sliderHandleAreaRect.anchorMax = new Vector2(0.5f, 0.5f);
        sliderHandleAreaRect.pivot = new Vector2(0.5f, 0.5f);
        sliderHandleAreaRect.sizeDelta = new Vector2(236.6f, 50);

        // create handle
        GameObject sliderHandle = new GameObject();
        sliderHandle.name = "Handle";
        sliderHandle.transform.parent = sliderHandleArea.transform;
        RectTransform sliderHandleRect = sliderHandle.AddComponent<RectTransform>();
        sliderHandleRect.anchorMin = new Vector2(0.5f, 0.5f);
        sliderHandleRect.anchorMax = new Vector2(0.5f, 0.5f);
        sliderHandleRect.pivot = new Vector2(0.5f, 0.5f);
        Image sliderHandleImage = sliderHandle.AddComponent<Image>();
        mediaModel = MediaLoader.instance.getMediaById(component.imageArray[2].id);
        if (mediaModel.image != null)
        {
            sliderHandleImage.sprite = mediaModel.image[0];
            sliderHandleRect.sizeDelta = new Vector2(mediaModel.image[0].rect.width, mediaModel.image[0].rect.height);
        }
        sliderHandleImage.preserveAspect = true;
        sliderComponent.handleRect = sliderHandleRect;
        sliderComponent.targetGraphic = sliderHandleImage;

        sliderGO.transform.localPosition = Vector3.zero;
    }
}
