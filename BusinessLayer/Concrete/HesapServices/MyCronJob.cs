using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.HesapServices
{
    public class MyCronJob : CronJobService
    {
        private readonly ILogger<MyCronJob> _logger;
        private readonly ShippingCalculator _shippingCalculator;

        public MyCronJob(ShippingCalculator shippingCalculator, IScheduleConfig<MyCronJob> config, ILogger<MyCronJob> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
            _shippingCalculator = shippingCalculator;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Cargo cron job is starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _shippingCalculator.updateCargos();
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Cargo cron job is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }


    public interface IScheduleConfig<T>
    {
        string CronExpression { get; set; }
        TimeZoneInfo TimeZoneInfo { get; set; }
    }

    public class ScheduleConfig<T> : IScheduleConfig<T>
    {
        public string CronExpression { get; set; }
        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
