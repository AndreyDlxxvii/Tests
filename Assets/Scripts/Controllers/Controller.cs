using System.Collections.Generic;

public class Controller
{
    private const string StartMethod = "OnStart";
    private const string UpdateMethod = "OnUpdate";

    private readonly List<IOnStart> _onStarts = new List<IOnStart>();
    
    public Controller Add(IOnController controller)
    {
        if (controller is IOnStart onStart)
        {
            _onStarts.Add(onStart);
        }
        return this;
    }
    
    public void OnStart()
    {
        foreach (var ell in _onStarts)
        {
            if (ell.HasMethod(StartMethod))
            {
                ell.OnStart();
            }
        }
    }
}
