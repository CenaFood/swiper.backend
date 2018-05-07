using ch.cena.swiper.backend.data;
using ch.cena.swiper.backend.data.Models;
using McMaster.Extensions.CommandLineUtils;
using System;
using System.Linq;

namespace CenaPipelineExport
{
    class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandLineApplication();

            app.HelpOption();
            var trainRatioOption = app.Option("-t|--trainRatio <ratio>", "The ratio for train data", CommandOptionType.SingleValue);
            var overrideOption = app.Option("-o", "If set all outputs will be overwritten.", CommandOptionType.NoValue);

            app.OnExecute(() =>
            {
                var trainRatio = trainRatioOption.HasValue()
                    ? float.Parse(trainRatioOption.Value())
                    : 0.8;


                //TODO: Overrideoption
                Console.WriteLine($"Train ratio {trainRatio}!");



                var testRatio = 1 - trainRatio;




                return 0;
            });

            return app.Execute(args);
        }
    }
}
