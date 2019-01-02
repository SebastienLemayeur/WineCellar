using Autofac;
using Prism.Events;

namespace WineGUI.Helpers
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<MainWindow>().AsSelf();
            return builder.Build();
        }
    }
}
