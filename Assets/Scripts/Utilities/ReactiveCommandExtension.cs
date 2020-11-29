using System;
using UniRx;
using UnityEngine.UI;

namespace Assets.Scripts.Utilities
{
    public static class ReactiveCommandExtension
    {

        public static ReactiveCommand Create(Action action, IObservable<bool> prop)
        {
            ReactiveCommand sourceCommand = prop.ToReactiveCommand();
            sourceCommand.Subscribe(_ => action());
            return sourceCommand;
        }

        public static ReactiveCommand CreateAndBind(Action action, IObservable<bool> prop, Button button)
        {
            ReactiveCommand sourceCommand = prop.ToReactiveCommand();
            sourceCommand.Subscribe(_ => action());
            sourceCommand.BindTo(button);
            return sourceCommand;
        }
    }
}
