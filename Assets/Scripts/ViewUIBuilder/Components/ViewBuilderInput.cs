using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ViewBuilderInput : ViewBuilderBaseComponent
{

    public ViewBuilderInput(Transform panel, ViewComponent _component) : base(panel, _component)
    {
        createInput();
    }

    private void createInput()
    {
        foreach (ViewComponentText1 xmlText in component.textArray)
        {
            GameObject inputField = CreateInputField("Input", new Font("Arial"), new Sprite()).gameObject;//Instantiate(Resources.Load("InputField")) as GameObject;
            inputField.transform.parent = container.transform;
            inputField.transform.localPosition = Vector3.zero;
            InputField input = inputField.GetComponent<InputField>();
            input.characterLimit = component.maxChars;
            input.selectionColor = new Color(input.selectionColor.r, input.selectionColor.g, input.selectionColor.b, 0f);
            RectTransform inputFieldRect = inputField.GetComponent<RectTransform>();
            inputFieldRect.sizeDelta = new Vector2(component.objWidth, component.objHeight);
            inputField.GetComponent<Image>().color = new Color(inputField.GetComponent<Image>().color.r, inputField.GetComponent<Image>().color.g, inputField.GetComponent<Image>().color.b, 0);

            MediaLoader.TextModel textModel = MediaLoader.instance.getTextById(xmlText.textId);
            string font = textModel.font;
            if (font == "")
            {
                font = "Arial";
            }
            Text textComponent = inputField.transform.Find("Text").GetComponent<Text>();
            textComponent.font = (Font)Resources.Load("Fonts/" + font);
            textComponent.resizeTextForBestFit = true;
            textComponent.supportRichText = true;
            Match match = Regex.Match(textModel.text, @"<color=(.+?)><size=(.+?)>(.*?)</size></color>");
            string fontColor = match.Groups[1].Value;
            int fontSize = int.Parse(match.Groups[2].Value);
            textComponent.text = match.Groups[3].Value;
            textComponent.fontSize = fontSize;
            Color color;
            ColorUtility.TryParseHtmlString(fontColor, out color);
            textComponent.color = color;
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

            Text placeholderTextComponent = inputField.transform.Find("Placeholder").GetComponent<Text>();
            placeholderTextComponent.font = (Font)Resources.Load("Fonts/" + font);
            placeholderTextComponent.resizeTextForBestFit = true;
            placeholderTextComponent.supportRichText = true;
            placeholderTextComponent.text = match.Groups[3].Value;
            placeholderTextComponent.fontSize = fontSize;
            ColorUtility.TryParseHtmlString(fontColor, out color);
            placeholderTextComponent.color = color;
            placeholderTextComponent.text = textComponent.text.Replace("<br>", "\n");
            placeholderTextComponent.horizontalOverflow = HorizontalWrapMode.Overflow;
            placeholderTextComponent.verticalOverflow = VerticalWrapMode.Overflow;
            if (textModel.autoSize != null)
            {
                if (textModel.autoSize.ToUpper() == "LEFT")
                {
                    placeholderTextComponent.alignment = TextAnchor.MiddleLeft;
                }
                else if (textModel.autoSize.ToUpper() == "CENTER")
                {
                    placeholderTextComponent.alignment = TextAnchor.MiddleCenter;
                }
                else if (textModel.autoSize.ToUpper() == "RIGHT")
                {
                    placeholderTextComponent.alignment = TextAnchor.MiddleRight;
                }
            }


            /*GameObject input = new GameObject();
            input.name = "Input";
            input.transform.parent = container.transform;
            input.transform.localPosition = Vector3.zero;
            RectTransform inputRect = input.AddComponent<RectTransform>();
            inputRect.localPosition = Vector3.zero;
            inputRect.pivot = Vector2.zero;
            InputField inputComponent = input.AddComponent<InputField>();
            MediaLoader.TextModel textModel = MediaLoader.instance.getTextById(xmlText.textId);
            string font = textModel.font;
            if (font == "")
            {
                font = "Arial";
            }
            GameObject text = new GameObject();
            text.name = "Text";
            text.transform.parent = input.transform;
            Text textComponent = text.AddComponent<Text>();
            //textComponent.font = Font.CreateDynamicFontFromOSFont(font, 15);
            textComponent.font = (Font)Resources.Load("Fonts/" + font);
            textComponent.resizeTextForBestFit = true;
            textComponent.supportRichText = true;
            textComponent.text = textModel.text;
            textComponent.text = textComponent.text.Replace("<br>", "\n");
            textComponent.horizontalOverflow = HorizontalWrapMode.Overflow;
            textComponent.verticalOverflow = VerticalWrapMode.Overflow;
            RectTransform textRect = text.GetComponent<RectTransform>();
            textRect.localPosition = new Vector3(xmlText.x, -xmlText.y);
            textRect.pivot = new Vector2(0f, 0f);

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

            inputComponent.textComponent = textComponent;

            GameObject placeholder = new GameObject();
            placeholder.name = "Placeholder";
            placeholder.transform.parent = input.transform;
            placeholder.transform.localPosition = Vector3.zero;
            Text placeholderTextComponent = placeholder.AddComponent<Text>();
            placeholderTextComponent.font = (Font)Resources.Load("Fonts/" + font);
            placeholderTextComponent.resizeTextForBestFit = true;
            placeholderTextComponent.supportRichText = true;
            placeholderTextComponent.text = textModel.text;
            placeholderTextComponent.text = textComponent.text.Replace("<br>", "\n");
            placeholderTextComponent.horizontalOverflow = HorizontalWrapMode.Overflow;
            placeholderTextComponent.verticalOverflow = VerticalWrapMode.Overflow;
            RectTransform textRectPlaceholder = text.GetComponent<RectTransform>();
            textRectPlaceholder.localPosition = new Vector3(xmlText.x, -xmlText.y);
            textRectPlaceholder.pivot = new Vector2(0f, 0f);

            inputComponent.placeholder = placeholderTextComponent;*/
        }
    }

    static public InputField CreateInputField(string name, Font font, Sprite background)
    {
        GameObject inputFieldGo = new GameObject(name);

        RectTransform rectTransform = inputFieldGo.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(300, 60);
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        CanvasRenderer canvasRender = inputFieldGo.AddComponent<CanvasRenderer>();

        Image image = inputFieldGo.AddComponent<Image>();
        image.sprite = background;
        image.type = Image.Type.Sliced;

        InputField inputField = inputFieldGo.AddComponent<InputField>();

        GameObject placeholderGo = new GameObject("Placeholder");
        placeholderGo.transform.parent = inputFieldGo.transform;

        rectTransform = placeholderGo.AddComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.offsetMin = new Vector2(10, 7);
        rectTransform.offsetMax = new Vector2(-10, -6);

        canvasRender = placeholderGo.AddComponent<CanvasRenderer>();

        Text text = placeholderGo.AddComponent<Text>();
        text.font = font;
        text.color = new Color32(50, 50, 50, 128);
        text.fontStyle = FontStyle.Italic;
        text.text = "Enter text...";

        inputField.placeholder = text;

        GameObject textGo = new GameObject("Text");
        textGo.transform.parent = inputFieldGo.transform;

        rectTransform = textGo.AddComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.offsetMin = new Vector2(10, 7);
        rectTransform.offsetMax = new Vector2(-10, -6);

        canvasRender = textGo.AddComponent<CanvasRenderer>();

        text = textGo.AddComponent<Text>();
        text.font = font;
        text.fontSize = 25;
        text.color = new Color32(50, 50, 50, 255);
        text.supportRichText = false;

        inputField.textComponent = text;

        return inputField;
    }
}
