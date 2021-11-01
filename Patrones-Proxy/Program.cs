using System;

namespace Patrones_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IServicio servicio = new ServicioConcreto();
            IServicio proxy = new Proxy(servicio);

            servicio.Login(15);
            proxy.Login(15);
            servicio.Login(18);
            proxy.Login(18);

            Console.ReadKey();
        }
    }

    interface IServicio
    {
        void Login(int edad);
    }

    class ServicioConcreto : IServicio
    {
        public void Login(int edad)
        {
            Console.WriteLine($"loguedo. Tu edad es {edad}");
        }
    }

    class Proxy : IServicio
    {
        private IServicio service;

        public Proxy(IServicio service)
        {
            this.service = service;
        }

        public void Login(int edad)
        {
            if (edad < 18)
            {
                Console.WriteLine("Menor de edad");
            }
            else
            {
                this.service.Login(edad);
            }
            
        }
    }
}
