using UnityEngine;
using System.Collections;

public class ViewBuilderBaseComponent
{
    public GameObject container;

    public ViewComponent component { get; set; }

    public Vector3 position { get; set; }

    public Vector2 size { get; set; }

    public ViewBuilderBaseComponent()
    {

    }

    public ViewBuilderBaseComponent(Transform panel, ViewComponent _component)
    {
        component = _component;

        container = new GameObject();
        container.name = component.id;
        if ((component.groupId != null) && (component.groupId != ""))
        {
            Transform fatherGO = FindRecursively(panel, component.groupId);
            if (fatherGO != null)
            {
                container.transform.parent = fatherGO;
            }
            else
            {
                container.transform.parent = panel;
            }
        }
        else
        {
            container.transform.parent = panel;
        }
        position = new Vector3(component.x, component.y);
        container.transform.localPosition = position;
        if (component.scale == 0f && component.xScale == 0f && component.yScale == 0f && component.zScale == 0f)
        {
            container.transform.localScale = Vector3.one;
        }
        else if(component.scale != 0f)
        {
            container.transform.localScale = new Vector3(component.scale, component.scale, component.scale);
        }
        else
        {
            container.transform.localScale = new Vector3(component.xScale, component.yScale, component.zScale);
        }
    }

    private Transform FindRecursively(Transform panel, string groupId)
    {
        for (int i = 0; i < panel.childCount; i++)
        {
            Transform child = panel.GetChild(i);
            if(child.name == groupId)
            {
                return child;
            }
            else
            {
                Transform found = FindRecursively(child, groupId);
                if(found != null)
                {
                    return found;
                }
            }
        }

        return null;
    }
}
