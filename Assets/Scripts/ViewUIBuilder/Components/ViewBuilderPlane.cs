using UnityEngine;

public class ViewBuilderPlane: ViewBuilderBaseComponent
{
    private GameObject video;
    private ViewBuilderText text;

    public ViewBuilderPlane(Transform panel, ViewComponent _component) : base(panel, _component)
    {
        createPlane();
    }

    private void createPlane()
    {
        
    }
}
