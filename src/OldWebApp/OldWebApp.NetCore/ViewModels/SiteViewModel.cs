using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace OldWebApp.DotVVM.ViewModels
{
    public abstract class SiteViewModel : DotvvmViewModelBase
    {
        public abstract string Title { get; }
    }
}

