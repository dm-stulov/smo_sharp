using System;
using System.Linq;
using smo_sharp.Models.DTO;
using smo_sharp.Models.Repository;
using smo_sharp.Models.Service;
using Buffer = smo_sharp.Models.Workers.Buffer;

namespace smo_sharp.Test
{
    public static class Test
    {
        public static void Test1()
        {
            var amount = 100;
            var handlerIntensity = 1000;
            var sourceIntensity = 2;
            var requestRepo = new RequestRepositoryIml();
            var buffer = new Buffer(1);

            var handlerService = new HandlerService(10, handlerIntensity, 100000);

            var sourceService = new SourceService(amount, 100, sourceIntensity, 1000);
            var dispatcher = new RequestDispatcher(buffer, sourceService, handlerService, requestRepo);

            dispatcher.Start();

            Console.WriteLine(
                "HANDLED " + requestRepo.FindAll().Count(r => r.Status == Request.RequestStatus.HANDLED) +
                " REJECTED " +
                requestRepo.FindAll().Count(r => r.Status == Request.RequestStatus.REJECTED));
        }
    }
}