﻿using System;
using System.Windows.Input;
using Messaging.Portable.Messages;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace Messaging.Portable.ViewModels
{
    public class LeftViewModel : ViewModelBase, IHandler<ViewModelMessage>
    {
        #region Constructors

        public LeftViewModel()
        {
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        #endregion

        #region Implementation of interfaces

        public void Handle(object sender, ViewModelMessage message)
        {
            // This handler will never invoked, because LeftViewModel does not listen the MainViewModel
            throw new NotSupportedException();
        }

        #endregion

        #region Commands

        public ICommand SendMessageCommand { get; }

        private void SendMessage()
        {
            Publish(new ViewModelMessage {IsLeftViewModel = true});
        }

        #endregion
    }
}