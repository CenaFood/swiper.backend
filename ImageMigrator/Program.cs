using ch.cena.swiper.backend.data;
using System;

namespace ImageMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            MigrationArguments arguments;

            if(MigrationArguments.TryParse(args,out arguments))
            {
                SwiperMigrator.Migrate(new SwiperContext(), arguments);
            }
            else
            {
                Console.WriteLine("Argument could not be parsed:");
                foreach (string error in arguments.GetErrors())
                {
                    Console.WriteLine(error);
                }
            }
        }        
    }
}
