using UnityEngine;
using ViewUIBuilder.Helpers.Components.Movie;

public class ViewBuilderVideo: ViewBuilderBaseComponent
{
    private GameObject video;
    private ViewBuilderText text;

    public ViewBuilderVideo(Transform panel, ViewComponent _component) : base(panel, _component)
    {
        createVideo();
    }

    private void createVideo()
    {
        video = new GameObject();
        video.transform.parent = container.transform;
        video.name = "video";
        Movie movie = video.AddComponent<Movie>();
        RectTransform recTransform = video.GetComponent<RectTransform>();
        recTransform.sizeDelta = new Vector2(component.objWidth, component.objHeight);
        recTransform.localPosition = new Vector3(0, 0, 0);
        recTransform.localScale = Vector3.one;
        movie.path = MediaLoader.instance.getUrlById(component.mediaId);
        if (component.config != null)
        {
            //movie.autoStart = component.config.autoStart;
        }
    }
}
