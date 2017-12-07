using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ViewBuilderText : ViewBuilderBaseComponent
{
    public GameObject[] textArray;

    public ViewBuilderText(Transform panel, ViewComponent _component) : base(panel, _component)
    {
        createText();
    }

    private void createText()
    {
        textArray = new GameObject[component.textArray.Length];
        int num = 0;
        foreach (ViewComponentText1 xmlText in component.textArray)
        {
            GameObject text = new GameObject();
            text.AddComponent<CanvasGroup>().blocksRaycasts = false;
            //text.AddComponent<LetterSpacing>();
            text.name = "text";
            text.transform.parent = container.transform;
            Text textComponent = text.AddComponent<Text>();
            MediaLoader.TextModel textModel = MediaLoader.instance.getTextById(xmlText.textId);
            string font = textModel.font;
            if (font == "")
            {
                font = "Arial";
            }
            Font textFont = null;
            string[] fonts = Font.GetOSInstalledFontNames();
            foreach (string fontName in fonts)
            {
                if(fontName == font)
                {
                    textFont = Font.CreateDynamicFontFromOSFont(font, 15);
                }
            }
            if (textFont == null)
            {
                textFont = (Font)Resources.Load("Fonts/" + font);
            }
            textComponent.font = textFont;
            textComponent.resizeTextForBestFit = true;
            textComponent.supportRichText = true;
            textComponent.text = textModel.text;
            textComponent.text = textComponent.text.Replace("<br>", "\n");
            textComponent.horizontalOverflow = HorizontalWrapMode.Overflow;
            textComponent.verticalOverflow = VerticalWrapMode.Overflow;
            Color fontColor;
            ColorUtility.TryParseHtmlString(textModel.fontColor, out fontColor);
            textComponent.color = fontColor;
            textComponent.fontSize = textModel.fontSize;
            RectTransform textRect = text.GetComponent<RectTransform>();
            textRect.localPosition = new Vector3(xmlText.x, -xmlText.y);
            textRect.pivot = new Vector2(0.5f, 0.5f);

            if (textModel.autoSize != null)
            {
                if (textModel.autoSize.ToUpper() == "LEFT")
                {
                    textRect.pivot = new Vector2(0f, 0.5f);
                    textComponent.alignment = TextAnchor.MiddleLeft;
                }
                else if (textModel.autoSize.ToUpper() == "CENTER")
                {
                    textRect.pivot = new Vector2(0.5f, 0.5f);
                    textComponent.alignment = TextAnchor.MiddleCenter;
                }
                else if (textModel.autoSize.ToUpper() == "RIGHT")
                {
                    textRect.pivot = new Vector2(1f, 0.5f);
                    textComponent.alignment = TextAnchor.MiddleRight;
                }
            }

            textArray[num] = text;
            num += 1;

            if (component.config != null)
            {
                
            }
        }
    }
    
    public void hideText(int num)
    {
        textArray[num].SetActive(false);
    }

    public void showText(int num)
    {
        textArray[num].SetActive(true);
    }

    public void changeText(int num, string newText)
    {
        textArray[num].GetComponent<Text>().text = newText;
    }
}
