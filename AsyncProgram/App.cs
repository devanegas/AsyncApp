using AsyncProgram.Services;
using AsyncProgram.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncProgram
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IAsyncService, AsyncService>();
            RegisterAppStart<AsyncViewModel>();
        }
    }
}
