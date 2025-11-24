
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
        _services[typeof(TService)] = implementation;
    }

    public TService Resolve<TService>()
    {
        return (TService)_services[typeof(TService)];
    }
}
