using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using ViewUIBuilder.Helpers.Components.Log;

public class MediaLoader {

    private MediaXML mediaXml;
    public MediaModel[] mediaModel;
    public TextModel[] textModel;
    public static MediaLoader instance = null;
    private string mediaPath;

    public struct MediaModel
    {
        public string id;
        public Sprite[] image;
        public string reference;
        public float width;
        public float height;
        public string url;

        public MediaModel(string _id, Sprite[] _image, string _reference, float _width, float _height, string _url)
        {
            id = _id;
            image = _image;
            reference = _reference;
            width = _width;
            height = _height;
            url = _url;
        }
    }

    public struct TextModel
    {
        public string id;
        public string reference;
        public string autoSize;
        public string font;
        public string text;
        public int fontSize;
        public string fontColor;

        public TextModel(string _id, string _reference, string _autosize, string _font, string _text, int _size, string _color)
        {
            id = _id;
            reference = _reference;
            autoSize = _autosize;
            font = _font;
            text = _text;
            fontSize = _size;
            fontColor = _color;
        }
    }

    public MediaLoader(string mediaPath)
    {
        this.mediaPath = mediaPath;

        if (MediaLoader.instance == null)
        {
            MediaLoader.instance = this;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(MediaXML));

        string path = mediaPath + "Media.xml";
        
        using (Stream reader = new FileStream(path, FileMode.Open))
        {
            // Call the Deserialize method to restore the object's state.
            mediaXml = (MediaXML)serializer.Deserialize(reader);
        }
        if (mediaXml == null)
        {
            Application.Quit();
        }
        mediaModel = new MediaModel[mediaXml.Images.Length];
        for(int i = 0; i < mediaXml.Images.Length; i++)
        {
            MediasMedia media = mediaXml.Images[i];
            if (media.url.Contains("."))
            {
                Sprite newImg = null;
                if (media.url.Contains(".png"))
                {
                    newImg = loadMedia(mediaPath + media.url);
                }
                MediaModel tempMediaModel = new MediaModel(media.id, new Sprite[] { newImg }, media.reference, media.width, media.height, media.url);
                Log.Instance.Info("tempMediaModel = " + tempMediaModel.id + " - " + tempMediaModel.image + " - " + tempMediaModel.url);
                mediaModel[i] = tempMediaModel;
            }
            else
            {
                string[] files = Directory.GetFiles(mediaPath + media.url);
                Sprite[] spriteArray = new Sprite[files.Length];
                int a = 0;
                foreach(string file in files)
                {
                    Log.Instance.Info("file = " + file);
                    Sprite newImg = loadMedia(file);
                    spriteArray[a] = newImg;
                    a += 1;
                }
                MediaModel tempMediaModel = new MediaModel(media.id, spriteArray, media.reference, media.width, media.height, media.url);
                mediaModel[i] = tempMediaModel;
            }
        }
        Log.Instance.Info("text xml lenght = " + mediaXml.Texts.Length);
        textModel = new TextModel[mediaXml.Texts.Length];
        for (int i = 0; i < mediaXml.Texts.Length; i++)
        {
            MediasText media = mediaXml.Texts[i];
            TextModel tempMediaText = new TextModel(media.id, media.reference, media.autoSize, media.font, media.Value, media.fontSize, media.fontColor);
            Log.Instance.Info("tempMediaText = " + tempMediaText.id + " - " + tempMediaText.reference + " - " + tempMediaText.autoSize + " - " + tempMediaText.text);
            textModel[i] = tempMediaText;
        }
    }

    private Sprite loadMedia(string url)
    {
        byte[] fileData = File.ReadAllBytes(url);
        Texture2D tex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
        tex.LoadImage(fileData);
        Sprite newImg = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        return newImg;
    }

    public MediaModel getMediaById(string id)
    {
        foreach(MediaModel model in mediaModel)
        {
            if(model.id == id)
            {
                return model;
            }
        }
        return new MediaModel();
    }

    public TextModel getTextById(string id)
    {
        foreach(TextModel model in textModel)
        {
            if(model.id == id)
            {
                return model;
            }
        }
        return new TextModel();
    }

    public string getUrlById(string id)
    {
        foreach (MediaModel model in mediaModel)
        {
            if (model.id == id)
            {
                return mediaPath + model.url;
            }
        }
        return "";
    }
}
