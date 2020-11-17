using Microsoft.AspNetCore.Mvc;
using PMA.Store_Framework.Commands;
using PMA.Store_Framework.Queries;
using PMA.Store_Framework.Resources.Interface;

namespace PMA.Store_Framework.Web
{
    public class BaseController : Controller
    {
        protected readonly CommandDispatcher _commandDispatcher;
        protected readonly IResourceManager _resourceManager;
        protected readonly QueryDispatcher _queryDispatcher;

        protected BaseController(IResourceManager resourceManager, CommandDispatcher commandDispatcher, QueryDispatcher queryDispatcher)
        {
            _resourceManager = resourceManager;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        protected BaseController()
        {
            ;
        }
    }
}