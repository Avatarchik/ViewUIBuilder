using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ViewBuilderDropdown : ViewBuilderBaseComponent
{
    Vector2 center = new Vector2(0.5f, 0.5f);

    Text labelText;
    Text itemText;

    public ViewBuilderDropdown(Transform panel, ViewComponent _component) : base(panel, _component)
    {
        //createDropdown();
    }

    /*private void createDropdown()
    {
        GameObject dropdown = Instantiate(Resources.Load("Dropdown")) as GameObject;
        dropdown.transform.parent = container.transform;
        dropdown.transform.localPosition = Vector3.zero;
        dropdown.name = "Dropdown";

        RectTransform dropRect = dropdown.GetComponent<RectTransform>();
        dropRect.sizeDelta = new Vector2(component.objWidth, component.objHeight);

        Image dropImage = dropdown.GetComponent<Image>();
        dropImage.color = new Color(dropImage.color.r, dropImage.color.g, dropImage.color.b, 0f);

        Dropdown dropComponent = dropdown.GetComponent<Dropdown>();
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        for (int i = 0; i < component.imageArray.Length; i++)
        {
            ViewComponentImage image = component.imageArray[i];
            ViewComponentText1 text = component.textArray[i];
            Dropdown.OptionData option = new Dropdown.OptionData();
            MediaLoader.MediaModel mediaModel = MediaLoader.instance.getMediaById(image.id);
            if (mediaModel.image != null)
            {
                option.image = mediaModel.image[0];
            }
            MediaLoader.TextModel textModel = MediaLoader.instance.getTextById(text.textId);
            Match match = Regex.Match(textModel.text, @"<color=(.+?)><size=(.+?)>(.*?)</size></color>");
            option.text = match.Groups[3].Value;
            options.Add(option);
        }
        dropComponent.options = options;

        Transform label = dropdown.transform.Find("Label");
        Text labelText = label.GetComponent<Text>();
        MediaLoader.TextModel textModel2 = MediaLoader.instance.getTextById(component.textArray[0].textId);
        labelText.font = (Font)Resources.Load("Fonts/" + textModel2.font);
        Match match2 = Regex.Match(textModel2.text, @"<color=(.+?)><size=(.+?)>(.*?)</size></color>");
        string fontColor = match2.Groups[1].Value;
        int fontSize = int.Parse(match2.Groups[2].Value);
        Color color;
        ColorUtility.TryParseHtmlString(fontColor, out color);
        labelText.color = color;
        labelText.fontSize = fontSize;

        Transform itemLabel = dropdown.transform.Find("Template/Viewport/Content/Item/Item Label");
        labelText = itemLabel.GetComponent<Text>();
        labelText.color = color;
        labelText.fontSize = fontSize;

        Transform item = dropdown.transform.Find("Template/Viewport/Content/Item");
        RectTransform itemRect = item.GetComponent<RectTransform>();
        itemRect.sizeDelta = new Vector2(component.objWidth, component.objHeight);
        //itemRect.localPosition = new Vector3(0f, -component.objHeight/2, 0f);
        //item.localPosition = Vector3.zero;

        Transform content = dropdown.transform.Find("Template/Viewport/Content");
        RectTransform contentRect = item.GetComponent<RectTransform>();
        contentRect.sizeDelta = new Vector2(component.objWidth, component.objHeight);

        Transform itemBack = dropdown.transform.Find("Template/Viewport/Content/Item/Item Background");
        ColorUtility.TryParseHtmlString("#23a4cb", out color);
        itemBack.GetComponent<Image>().color = color;

        Transform template = dropdown.transform.Find("Template");
        template.GetComponent<Image>().color = color;

        Transform itemCheck = dropdown.transform.Find("Template/Viewport/Content/Item/Item Checkmark");
        itemCheck.GetComponent<Image>().color = new Color(itemCheck.GetComponent<Image>().color.r, itemCheck.GetComponent<Image>().color.g, itemCheck.GetComponent<Image>().color.b, 0f);
    }

    private GameObject createLabel(Transform father, string textId, string name)
    {
        GameObject text = new GameObject();
        text.transform.parent = father;
        text.name = name;
        RectTransform textRect = text.AddComponent<RectTransform>();
        textRect.position = Vector3.zero;// new Vector3(component.objWidth/2, 0, 0);
        textRect.sizeDelta = father.GetComponent<RectTransform>().sizeDelta;
        textRect.anchorMin = center;
        textRect.anchorMax = center;
        textRect.pivot = center;

        Text textComponent = text.AddComponent<Text>();
        MediaLoader.TextModel textModel = MediaLoader.instance.getTextById(textId);
        string font = textModel.font;
        if (font == "")
        {
            font = "Arial";
        }
        //textComponent.font = Font.CreateDynamicFontFromOSFont(font, 15);
        textComponent.font = (Font)Resources.Load("Fonts/" + font);
        textComponent.resizeTextForBestFit = true;
        textComponent.supportRichText = true;
        textComponent.text = textModel.text;
        textComponent.text = textComponent.text.Replace("<br>", "\n");
        textComponent.horizontalOverflow = HorizontalWrapMode.Overflow;
        textComponent.verticalOverflow = VerticalWrapMode.Overflow;

        if (textModel.autoSize != null)
        {
            if (textModel.autoSize.ToUpper() == "LEFT")
            {
                textComponent.alignment = TextAnchor.MiddleLeft;
            }
            else if (textModel.autoSize.ToUpper() == "CENTER")
            {
                textComponent.alignment = TextAnchor.MiddleCenter;
            }
            else if (textModel.autoSize.ToUpper() == "RIGHT")
            {
                textComponent.alignment = TextAnchor.MiddleRight;
            }
        }


        return text;
    }

    private GameObject createTemplate(GameObject dropdown)
    {
        GameObject dropdownTemplate = new GameObject();
        dropdownTemplate.transform.parent = dropdown.transform;
        dropdownTemplate.name = "Template";

        RectTransform dropRect = dropdownTemplate.AddComponent<RectTransform>();
        dropRect.position = Vector2.zero;
        dropRect.sizeDelta = new Vector2(component.objWidth, component.objHeight * component.imageArray.Length);
        dropRect.anchorMin = center;
        dropRect.anchorMax = center;
        dropRect.pivot = new Vector2(0.5f, 1f);

        Image dropImage = dropdownTemplate.AddComponent<Image>();
        dropImage.sprite = new Sprite();
        dropImage.color = new Color(dropImage.color.r, dropImage.color.g, dropImage.color.b, 0f);

        GameObject[] ret = createViewport(dropdownTemplate);

        ScrollRect dropScroll = dropdownTemplate.AddComponent<ScrollRect>();
        dropScroll.content = ret[1].GetComponent<RectTransform>();
        dropScroll.viewport = ret[0].GetComponent<RectTransform>();

        return dropdownTemplate;
    }

    private GameObject[] createViewport(GameObject dropdownTemplate)
    {
        GameObject viewport = new GameObject();
        viewport.transform.parent = dropdownTemplate.transform;
        viewport.name = "Viewport";

        RectTransform viewRect = viewport.AddComponent<RectTransform>();
        viewRect.anchorMin = center;
        viewRect.anchorMax = center;
        viewRect.pivot = new Vector2(0f, 1f);
        viewRect.sizeDelta = new Vector2(component.objWidth, component.objHeight * component.imageArray.Length);
        viewRect.position = new Vector3(-component.objWidth/2, 0, 0);

        Mask viewMask = viewport.AddComponent<Mask>();
        viewMask.showMaskGraphic = false;

        Image viewImage = viewport.AddComponent<Image>();
        viewImage.sprite = new Sprite();
        //viewImage.color = new Color(viewImage.color.r, viewImage.color.g, viewImage.color.b, 0f);

        GameObject content = createContent(viewport);

        return new GameObject[] { viewport, content };
    }

    private GameObject createContent(GameObject viewport)
    {
        GameObject content = new GameObject();
        content.transform.parent = viewport.transform;
        content.name = "Content";

        RectTransform contentRect = content.AddComponent<RectTransform>();
        contentRect.position = Vector3.zero;
        contentRect.anchorMin = center;
        contentRect.anchorMax = center;
        contentRect.pivot = new Vector2(0f, 1f);
        contentRect.sizeDelta = new Vector2(component.objWidth, component.objHeight * component.imageArray.Length);

        createItem(content);

        return content;
    }

    private GameObject createItem(GameObject template)
    {
        GameObject item = new GameObject();
        item.transform.parent = template.transform;
        item.name = "Item";

        RectTransform itemRect = item.AddComponent<RectTransform>();
        itemRect.position = Vector2.zero;
        itemRect.sizeDelta = Vector2.zero;// new Vector2(component.objWidth, component.objHeight/2);
        itemRect.anchorMin = center;
        itemRect.anchorMax = center;
        itemRect.pivot = center;

        Toggle itemToogle = item.AddComponent<Toggle>();

        createBackground(item);
        createCheckmark(item);
        GameObject label = createLabel(item.transform, component.textArray[0].textId, "Item Label");
        itemText = label.GetComponent<Text>();
        //label.GetComponent<RectTransform>().position = new Vector3(component.objWidth / 2, -component.objHeight, 0);

        return item;
    }

    private GameObject createBackground(GameObject item)
    {
        GameObject background = new GameObject();
        background.transform.parent = item.transform;
        background.name = "Item Background";

        RectTransform backRect = background.AddComponent<RectTransform>();
        backRect.position = Vector3.zero;
        backRect.anchorMin = center;
        backRect.anchorMax = center;
        backRect.pivot = center;

        Image backImage = background.AddComponent<Image>();
        backImage.sprite = new Sprite();
        backImage.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, 0f);

        return background;
    }

    private GameObject createCheckmark(GameObject item)
    {
        GameObject background = new GameObject();
        background.transform.parent = item.transform;
        background.name = "Item Checkmark";

        RectTransform backRect = background.AddComponent<RectTransform>();
        backRect.position = Vector3.zero;
        backRect.anchorMin = center;
        backRect.anchorMax = center;
        backRect.pivot = center;

        Image backImage = background.AddComponent<Image>();
        backImage.sprite = new Sprite();
        backImage.color = new Color(backImage.color.r, backImage.color.g, backImage.color.b, 0f);

        return background;
    }

    private void createDropdown()
    {
        GameObject dropdown = new GameObject();
        dropdown.transform.parent = container.transform;
        dropdown.name = "Dropdown";

        RectTransform dropRect = dropdown.AddComponent<RectTransform>();
        dropRect.position = Vector3.zero;
        dropRect.sizeDelta = new Vector2(component.objWidth, component.objHeight);

        Image dropImage = dropdown.AddComponent<Image>();
        MediaLoader.MediaModel mediaModel = MediaLoader.instance.getMediaById(component.imageId);
        if (mediaModel.image != null)
        {
            dropImage.sprite = mediaModel.image[0];
        }

        Dropdown dropComponent = dropdown.AddComponent<Dropdown>();
        dropComponent.targetGraphic = dropImage;
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        for(int i = 0; i < component.imageArray.Length; i++)
        {
            ViewComponentImage image = component.imageArray[i];
            ViewComponentText1 text = component.textArray[i];
            Dropdown.OptionData option = new Dropdown.OptionData();
            mediaModel = MediaLoader.instance.getMediaById(image.id);
            if (mediaModel.image != null)
            {
                option.image = mediaModel.image[0];
            }
            MediaLoader.TextModel textModel = MediaLoader.instance.getTextById(text.textId);
            Match match = Regex.Match(textModel.text, @"<color=(.+?)><size=(.+?)>(.*?)</size></color>");
            option.text = match.Groups[3].Value;
            options.Add(option);
        }
        dropComponent.options = options;

        GameObject label = createLabel(dropdown.transform, component.textArray[0].textId, "Label");
        dropComponent.captionText = label.GetComponent<Text>();

        GameObject template = createTemplate(dropdown);
        dropComponent.itemText = itemText;
        dropComponent.template = template.GetComponent<RectTransform>();

        dropdown.transform.localPosition = Vector3.zero;
    }*/
}
