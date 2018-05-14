using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CenaPipelineExport
{
    class Runner
    {
        private readonly ILogger<Runner> _logger;

        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }

        public void Export()
        {
            _logger.LogDebug(20, "Stated export");
        }

    }
}
