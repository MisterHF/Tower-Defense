using UnityEngine;
using UnityEngine.Events;


/// <summary>
///     For add an event call : EventManager.Instance.Event.AddListener(Function);
///     The function should have the shape : UnityEvent
///     <params>
///         take Function(params)
///         For call an event just add this line : EventManager.Instance.Event.Invoke(params);
///         this will call all function you have add to your event
/// </summary>
/// 

public class EventManager : MonoBehaviour
{
    public static EventManager instance { get; private set; }
    public UnityEvent onCrossfadeTransition { get; private set; } = new();

    public UnityEvent OnGameLosed { get; private set; } = new();
    public UnityEvent OnGameWin { get; private set; } = new();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }
}
