using System;
using System.Linq;
using smo_sharp.Models.DTO;
using smo_sharp.Models.Workers;
using System.Collections.Generic;

namespace smo_sharp.Models.Service
{
    public class HandlerService
    {
        private readonly List<Handler> _handlers;

        public HandlerService(int handlerAmount, int minArg, int maxArg)
        {
            _handlers = CreateHandlerList(handlerAmount, minArg, maxArg);
        }

        public bool CanHandle(long handleTime)
        {
            return _handlers.Any(request => request.CanHandle(handleTime));
        }

        public Request Handle(Request request, long time)
        {
            var handler = _handlers.Find((h) => h.CanHandle(time));

            if (handler == null)
            {
                throw new Exception("All handlers are busy");
            }

            return handler.Handle(request, time);
        }

        public Request Handle(Request request)
        {
            var handler = _handlers.Aggregate(_handlers[0],
                (handlerWithMinTime, h) => handlerWithMinTime.Timeline > h.Timeline ? h : handlerWithMinTime);

            return handler.Handle(request);
        }

        private static List<Handler> CreateHandlerList(int amount, int minArg, int maxArg)
        {
            var list = new List<Handler>();
            for (var i = 0; i < amount; ++i)
            {
                list.Add(new Handler(i, minArg, maxArg));
            }

            return list;
        }
    }
}