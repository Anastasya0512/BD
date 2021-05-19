using ForumBusinessLogic.BusinessLogics;
using ForumBusinessLogic.Interfaces;
using ForumBusinessLogic.ViewModels;
using ForumDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ForumView
{
    static class Program
    {
        public static UsersViewModel User { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

      private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IForumStorage, ForumStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IUsersStorage, UsersStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IForumtypeStorage, ForumtypeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportsStorage, ReportsStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISpeakersStorage, SpeakersStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ForumLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ForumtypeBusinessLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportsBusinessLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<SpeakersBusinessLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<UsersBusinessLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
