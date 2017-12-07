using UnityEngine;
using System.Collections;

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(ElementName = "App", DataType = "string", IsNullable = true)]
public partial class ConfigXML
{
    private AppCanvas[] canvasField;
    private ushort appHeightField;
    private ushort appWidthField;
    private string mediaPathField;
    private string viewPathField;
    private AppViewsView[] viewsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("Canva", typeof(AppCanvas), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public AppCanvas[] Canvas
    {
        get
        {
            return this.canvasField;
        }
        set
        {
            this.canvasField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort appHeight
    {
        get
        {
            return this.appHeightField;
        }
        set
        {
            this.appHeightField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort appWidth
    {
        get
        {
            return this.appWidthField;
        }
        set
        {
            this.appWidthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mediaPath
    {
        get
        {
            return this.mediaPathField;
        }
        set
        {
            this.mediaPathField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string viewPath
    {
        get
        {
            return this.viewPathField;
        }
        set
        {
            this.viewPathField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("View", typeof(AppViewsView), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
    public AppViewsView[] Views
    {
        get
        {
            return this.viewsField;
        }
        set
        {
            this.viewsField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AppCanvas
{

    private string renderModeField;

    private bool pixelPerfectField;

    private int planeDistanceField;

    private string idField;

    private int orderField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string renderMode
    {
        get
        {
            return this.renderModeField;
        }
        set
        {
            this.renderModeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool pixelPerfect
    {
        get
        {
            return this.pixelPerfectField;
        }
        set
        {
            this.pixelPerfectField = value;
        }
    }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int planeDistance
    {
        get
        {
            return this.planeDistanceField;
        }
        set
        {
            this.planeDistanceField = value;
        }
    }

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

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int order
    {
        get
        {
            return this.orderField;
        }
        set
        {
            this.orderField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AppViewsView
{

    private string idField;

    private string fileField;

    private string idCanvasField;

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
    public string file
    {
        get
        {
            return this.fileField;
        }
        set
        {
            this.fileField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string idCanvas
    {
        get
        {
            return this.idCanvasField;
        }
        set
        {
            this.idCanvasField = value;
        }
    }
}


