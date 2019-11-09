using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TNUserInterface.ViewModels;

namespace TNUserInterface
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            _container.Instance(_container);//when you ask for a SimpleContainer Instance, it returns this instance
            _container.Singleton<IWindowManager, WindowManager>()
                      .Singleton<IEventAggregator, EventAggregator>();//Allows for events to be used in all different parts (views) of the App
            GetType().Assembly.GetTypes()//get all types in the app, which:
                .Where(type => type.IsClass)//are Class-types
                .Where(type => type.Name.EndsWith("ViewModel"))//and the names of the Classes end in "ViewModel"
                .ToList() //Create a List of those classes
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));//For each "ViewModel" class does "_container.RegisterPerRequest"
        }
        //The following code applies Bootstrapper methods to our ViewModels through overriding
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();//Shows view in ShellViewModel
        }
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
