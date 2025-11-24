
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Container for injections
/// </summary>
public class DIContainer 
{
    private readonly Dictionary<System.Type, object> _services
        = new Dictionary<System.Type, object>();

    public void Register<TService>(TService implementation)
    {
        Debug.Log("_uiManager 1:" + typeof(TService).Name);
        _services[typeof(TService)] = implementation;
    }

    public TService Resolve<TService>()
    {
        Debug.Log("_uiManager 2:" + typeof(TService).Name);

        for (int i = 0; i < _services.Count; i++)
        {
            Debug.Log("LIST _services 2:" + _services.Values.ToList()[i]);
        }
        return (TService)_services[typeof(TService)];
    }
}
