﻿using System.Collections.Generic;
using System.Reflection;
using Binding.Portable;
using Binding.Portable.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace Binding
{
    public partial class DesignBootstrapper : WpfDesignBootstrapperBase
    {
        #region Methods

        protected override IMvvmApplication CreateApplication()
        {
            return new App();
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new MugenContainer();
        }

        protected override void UpdateAssemblies(HashSet<Assembly> assemblies)
        {
            base.UpdateAssemblies(assemblies);
            assemblies.Add(typeof(MainViewModel).GetTypeInfo().Assembly);
        }

        #endregion
    }
}