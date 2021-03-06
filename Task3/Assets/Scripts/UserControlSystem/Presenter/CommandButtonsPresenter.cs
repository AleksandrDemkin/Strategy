using System;
using System.Collections.Generic;
using Abstractions;
using Assets.Scripts.UserControlSystem;
using UnityEngine;
using UserControlSystem.Model;
using UserControlSystem.View;
using Utils.AssetsInjector;
using Zenject;

namespace UserControlSystem.Presenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [Inject] private CommandButtonsModel _model;

        private ISelectable _currentSelectable;
        
        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;
            
            _selectable.OnSelected += OnSelected;
            OnSelected(_selectable.CurrentValue);
        }
        private void OnSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            if (_currentSelectable != null)
            {
                _model.OnSelectionChanged();
            }
            _currentSelectable = selectable;
            
            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }
    }
}