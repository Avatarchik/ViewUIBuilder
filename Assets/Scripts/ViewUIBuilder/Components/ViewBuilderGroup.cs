using UnityEngine;
using System.Collections;

public class ViewBuilderGroup: ViewBuilderBaseComponent
{

    public ViewBuilderGroup(Transform panel, ViewComponent _component) : base(panel, _component)
    {
        container.AddComponent<RectTransform>().sizeDelta = new Vector2(_component.objWidth, _component.objHeight);
    }
}
