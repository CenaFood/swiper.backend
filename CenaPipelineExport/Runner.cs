using ch.cena.swiper.backend.service.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CenaPipelineExport
{
    class Runner
    {
        private readonly ILogger<Runner> _logger;
        private readonly ExportService _service;

        public Runner(ILogger<Runner> logger, ExportService exportService)
        {
            _logger = logger;
            _service = exportService;
        }

        public void Export()
        {
            _logger.LogDebug(20, "Stated export");
        }

    }
}
