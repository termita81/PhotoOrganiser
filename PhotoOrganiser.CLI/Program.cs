using System;

namespace PhotoOrganiser.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            new Worker.Worker().Do();
        }
    }
}
