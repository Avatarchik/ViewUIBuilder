using UnityEngine;
using System.Collections;

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "View", DataType = "string", IsNullable = true)]
public partial class ViewBuilderXML
{

    private ViewComponent[] componentsField;

    private string idField;

    private float widthField;

    private float heightField;

    private float xField;

    private float yField;

    private string origPositionField; 

    private string scriptField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Component", IsNullable = false)]
    public ViewComponent[] Components
    {
        get
        {
            return this.componentsField;
        }
        set
        {
            this.componentsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float width
    {
        get
        {
            return this.widthField;
        }
        set
        {
            this.widthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float height
    {
        get
        {
            return this.heightField;
        }
        set
        {
            this.heightField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x
    {
        get
        {
            return this.xField;
        }
        set
        {
            this.xField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y
    {
        get
        {
            return this.yField;
        }
        set
        {
            this.yField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string origPosition
    {
        get
        {
            return this.origPositionField;
        }
        set
        {
            this.origPositionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string script
    {
        get
        {
            return this.scriptField;
        }
        set
        {
            this.scriptField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ViewComponent
{

    private ViewComponentText textField;

    private ViewComponentConfig configField;

    private ViewComponentImage[] imageArrayField;

    private ViewComponentText1[] textArrayField;

    private string mediaIdField;

    private string typeField;

    private string idField;

    private string descriptionField;

    private float xField;

    private float yField;

    private float zField;

    private float objWidthField;

    private float objHeightField;

    private string groupIdField;

    private float _scale;

    private float scaleX;

    private float scaleY;

    private float scaleZ;

    private float xRotation;

    private float yRotation;

    private float zRotation;

    private int maxCharsField;

    /// <remarks/>
    public ViewComponentText text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }

    /// <remarks/>
    public ViewComponentConfig config
    {
        get
        {
            return this.configField;
        }
        set
        {
            this.configField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("image", IsNullable = false)]
    public ViewComponentImage[] imageArray
    {
        get
        {
            return this.imageArrayField;
        }
        set
        {
            this.imageArrayField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("text", IsNullable = false)]
    public ViewComponentText1[] textArray
    {
        get
        {
            return this.textArrayField;
        }
        set
        {
            this.textArrayField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mediaId
    {
        get
        {
            return this.mediaIdField;
        }
        set
        {
            this.mediaIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x
    {
        get
        {
            return this.xField;
        }
        set
        {
            this.xField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y
    {
        get
        {
            return this.yField;
        }
        set
        {
            this.yField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float z
    {
        get
        {
            return this.zField;
        }
        set
        {
            this.zField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float objWidth
    {
        get
        {
            return this.objWidthField;
        }
        set
        {
            this.objWidthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float objHeight
    {
        get
        {
            return this.objHeightField;
        }
        set
        {
            this.objHeightField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string groupId
    {
        get
        {
            return this.groupIdField;
        }
        set
        {
            this.groupIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float xRot
    {
        get
        {
            return this.xRotation;
        }
        set
        {
            this.xRotation = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float yRot
    {
        get
        {
            return this.yRotation;
        }
        set
        {
            this.yRotation = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float zRot
    {
        get
        {
            return this.zRotation;
        }
        set
        {
            this.zRotation = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float scale
    {
        get
        {
            return this._scale;
        }
        set
        {
            this._scale = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float xScale
    {
        get
        {
            return this.scaleX;
        }
        set
        {
            this.scaleX = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float yScale
    {
        get
        {
            return this.scaleY;
        }
        set
        {
            this.scaleY = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float zScale
    {
        get
        {
            return this.scaleZ;
        }
        set
        {
            this.scaleZ = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int maxChars
    {
        get
        {
            return this.maxCharsField;
        }
        set
        {
            this.maxCharsField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ViewComponentText
{

    private string textIdField;

    private float xField;

    private float yField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string textId
    {
        get
        {
            return this.textIdField;
        }
        set
        {
            this.textIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x
    {
        get
        {
            return this.xField;
        }
        set
        {
            this.xField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y
    {
        get
        {
            return this.yField;
        }
        set
        {
            this.yField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ViewComponentConfig
{

    private byte typeField;

    private string folderField;

    private float increasePercentField;

    private float angleField;

    private float gapTouchSizeField;

    private bool radioButtonModeField;

    private float animationTimeField;

    private int animationOrderField;

    private bool loopField;

    private bool autoStartField;

    private string maskTypeField;

    private bool typeWriterField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string folder
    {
        get
        {
            return this.folderField;
        }
        set
        {
            this.folderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float increasePercent
    {
        get
        {
            return this.increasePercentField;
        }
        set
        {
            this.increasePercentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float angle
    {
        get
        {
            return this.angleField;
        }
        set
        {
            this.angleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float gapTouchSize
    {
        get
        {
            return this.gapTouchSizeField;
        }
        set
        {
            this.gapTouchSizeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool radioButtonMode
    {
        get
        {
            return this.radioButtonModeField;
        }
        set
        {
            this.radioButtonModeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float animationTime
    {
        get
        {
            return this.animationTimeField;
        }
        set
        {
            this.animationTimeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int animationOrder
    {
        get
        {
            return this.animationOrderField;
        }
        set
        {
            this.animationOrderField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool loop
    {
        get
        {
            return this.loopField;
        }
        set
        {
            this.loopField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool autoStart
    {
        get
        {
            return this.autoStartField;
        }
        set
        {
            this.autoStartField = value;
        }
    }    

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string maskType
    {
        get
        {
            return this.maskTypeField;
        }
        set
        {
            this.maskTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool typeWriter
    {
        get
        {
            return this.typeWriterField;
        }
        set
        {
            this.typeWriterField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ViewComponentImage
{

    private string idField;

    private float xField;

    private float yField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x
    {
        get
        {
            return this.xField;
        }
        set
        {
            this.xField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y
    {
        get
        {
            return this.yField;
        }
        set
        {
            this.yField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ViewComponentText1
{

    private string textIdField;

    private float xField;

    private float yField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string textId
    {
        get
        {
            return this.textIdField;
        }
        set
        {
            this.textIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float x
    {
        get
        {
            return this.xField;
        }
        set
        {
            this.xField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public float y
    {
        get
        {
            return this.yField;
        }
        set
        {
            this.yField = value;
        }
    }
}

