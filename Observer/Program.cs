using Autofac;
using Observer.Constants;
using Observer.Events;
using Observer.Implementations;
using Observer.Interfaces;
using Observer.Models;
using Observer.ObservableEntities;
using Observer.Repos;
using Observer.Subscribers;
using System;

namespace Observer
{
    class Program
    {
        static ISubscriber<MessageSent> _emailNotifications;
        static ISubscriber<MessageSent> _smsNotifications;
        static ISubscriber<MessageSent> _uiNotifications;
        static MessageBox _messageBox;

        static void Main(string[] args)
        {
            RegisterDependencies();
            InitaliseUserRepo();

            using (var scope = Container.BeginLifetimeScope())
            {
                _messageBox = scope.Resolve<MessageBox>();

                _emailNotifications
                    = scope.ResolveNamed<ISubscriber<MessageSent>>(SubscribersTypes.EMAIL_SUBSCRIBER);
                _smsNotifications
                    = scope.ResolveNamed<ISubscriber<MessageSent>>(SubscribersTypes.SMS_SUBSCRIBER);
                _uiNotifications
                    = scope.ResolveNamed<ISubscriber<MessageSent>>(SubscribersTypes.UI_SUBSCRIBER);

                DisplayMenu();

                while (true)
                {
                    var key = Console.ReadKey().Key;
                    Console.WriteLine();

                    if (key == ConsoleKey.Q)
                        break;

                    HandleUserInput(key);
                }
            }
        }

        private static void InitaliseUserRepo()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var userRepo = scope.Resolve<IRepo<User>>();

                var user1 = new User(Guid.NewGuid(), "Александр", "sasha@gmail.com", "111-222-333");
                user1.IsLoggedIn = true;
                userRepo.Add(user1);

                var user2 = new User(Guid.NewGuid(), "Михаил", "mike@hotmail.com", "444-555-666");
                user2.IsLoggedIn = false;
                userRepo.Add(user2);

                var user3 = new User(Guid.NewGuid(), "Татьяна", "tanyuha@mail.ru", "777-888-999");
                user3.IsLoggedIn = true;
                userRepo.Add(user3);
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Отправка сообщений:");
            Console.WriteLine("\t - нажмите А чтобы отправить сообщение Александру");
            Console.WriteLine("\t - нажмите М чтобы отправить сообщение Михаилу");
            Console.WriteLine("\t - нажмите Т чтобы отправить сообщение Татьяне");
            Console.WriteLine("");
            Console.WriteLine("Подписка поставщиков уведомлений:");
            Console.WriteLine($"\t - нажмите G чтобы подписать {SubscribersTypes.EMAIL_SUBSCRIBER}");
            Console.WriteLine($"\t - нажмите H чтобы подписать {SubscribersTypes.SMS_SUBSCRIBER}");
            Console.WriteLine($"\t - нажмите J чтобы подписать {SubscribersTypes.UI_SUBSCRIBER}");
            Console.WriteLine("");
            Console.WriteLine("Подписка поставщиков уведомлений:");
            Console.WriteLine($"\t - нажмите V чтобы отписать {SubscribersTypes.EMAIL_SUBSCRIBER}");
            Console.WriteLine($"\t - нажмите B чтобы отписать {SubscribersTypes.SMS_SUBSCRIBER}");
            Console.WriteLine($"\t - нажмите N чтобы отписать {SubscribersTypes.UI_SUBSCRIBER}");
            Console.WriteLine("");
            Console.WriteLine("Нажмите Q чтобы выйти из приложения");
            Console.WriteLine("");
        }

        private static void HandleUserInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    _messageBox.SendMessage(new Message("Андрей", "Александр", "Привет!"));
                    break;
                case ConsoleKey.M:
                    _messageBox.SendMessage(new Message("Андрей", "Михаил", "Привет!"));
                    break;
                case ConsoleKey.T:
                    _messageBox.SendMessage(new Message("Андрей", "Татьяна", "Привет!"));
                    break;
                case ConsoleKey.G:
                    _messageBox.Subscribe(_emailNotifications);
                    break;
                case ConsoleKey.H:
                    _messageBox.Subscribe(_smsNotifications);
                    break;
                case ConsoleKey.J:
                    _messageBox.Subscribe(_uiNotifications);
                    break;
                case ConsoleKey.V:
                    _messageBox.Unsubscribe(_emailNotifications);
                    break;
                case ConsoleKey.B:
                    _messageBox.Unsubscribe(_smsNotifications);
                    break;
                case ConsoleKey.N:
                    _messageBox.Unsubscribe(_uiNotifications);
                    break;
            }
        }

        private static void RegisterDependencies()
        {
            Builder.RegisterType<GenericRepo<User>>().As<IRepo<User>>().SingleInstance();
            Builder.RegisterType<GenericRepo<ISubscriber<MessageSent>>>()
                .As<IRepo<ISubscriber<MessageSent>>>()
                .SingleInstance();

            Builder.RegisterType<GoogleMessageSender>().As<IMessageSender<Message>>();

            Builder.RegisterType<MessageBox>().AsSelf().SingleInstance();

            Builder.RegisterType<EmailNotificationDispatcher>()
                .Named<ISubscriber<MessageSent>>(SubscribersTypes.EMAIL_SUBSCRIBER);
            Builder.RegisterType<SmsNotificationDispatcher>()
                .Named<ISubscriber<MessageSent>>(SubscribersTypes.SMS_SUBSCRIBER);
            Builder.RegisterType<UiNotificationDispatcher>()
                .Named<ISubscriber<MessageSent>>(SubscribersTypes.UI_SUBSCRIBER);
        }

        private static IContainer _container;
        public static IContainer Container => _container ?? (_container = Builder.Build());

        private static ContainerBuilder _builder;
        public static ContainerBuilder Builder => _builder ?? (_builder = new ContainerBuilder());
    }
}
