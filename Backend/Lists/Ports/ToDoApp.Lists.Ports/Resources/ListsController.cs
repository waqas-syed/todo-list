using System;
using System.Globalization;
using System.Web.Http;
using Newtonsoft.Json;
using ToDoApp.Lists.Application.Lists;
using ToDoApp.Lists.Application.Lists.Commands;

namespace ToDoApp.Lists.Ports.Resources
{
    /// <summary>
    /// Acts as the RESTful interface for resolving requests related to ToDoList items
    /// </summary>
    [RoutePrefix("v1")]
    public class ListsController : ApiController
    {
        private IListApplicationService _listsApplicationService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="listsApplicationService"></param>
        public ListsController(IListApplicationService listsApplicationService)
        {
            _listsApplicationService = listsApplicationService;
        }
        
        /// <summary>
        /// Save a new ToDoItem in the ToDoList of the mentioned user
        /// </summary>
        /// <param name="toDoItem"></param>
        /// <returns></returns>
        [Route("todoitem")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post([FromBody] Object toDoItem)
        {
            try
            {
                if (toDoItem != null)
                {
                    var jsonString = toDoItem.ToString();
                    CreateNewToDoCommand toDoCommand = null;
                    // First try to convert it to CreateHouseCommand
                    toDoCommand = JsonConvert.DeserializeObject<CreateNewToDoCommand>(jsonString);
                    if (toDoCommand != null)
                    {
                        _listsApplicationService.AddNewToDoItem(toDoCommand);
                        return Ok();
                    }
                }
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
            return BadRequest();
        }

        /// <summary>
        /// Updates an existing ToDoItem in the ToDoList of the mentioned user
        /// </summary>
        /// <param name="toDoItem"></param>
        /// <returns></returns>
        [Route("todoitem")]
        [HttpPut]
        [Authorize]
        [AcceptVerbs(new string[] { "OPTIONS", "PUT" })]
        public IHttpActionResult Update([FromBody] Object toDoItem)
        {
            try
            {
                if (toDoItem != null)
                {
                    var jsonString = toDoItem.ToString();
                    UpdateToDoItemCommand toDoCommand = null;
                    // First try to convert it to CreateHouseCommand
                    toDoCommand = JsonConvert.DeserializeObject<UpdateToDoItemCommand>(jsonString);
                    if (toDoCommand != null)
                    {
                        _listsApplicationService.UpdateToDoItem(toDoCommand);
                        return Ok();
                    }
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return BadRequest();
        }

        /// <summary>
        /// Save a new ToDoItem in the ToDoList of the mentioned user
        /// </summary>
        /// <param name="toDoItem"></param>
        /// <returns></returns>
        [Route("todoitem")]
        [HttpPut]
        [Authorize]
        [AcceptVerbs(new string[] { "OPTIONS", "PUT" })]
        public IHttpActionResult Delete([FromBody] Object toDoItem)
        {
            try
            {
                if (toDoItem != null)
                {
                    var jsonString = toDoItem.ToString();
                    UpdateToDoItemCommand toDoCommand = null;
                    // First try to convert it to CreateHouseCommand
                    toDoCommand = JsonConvert.DeserializeObject<UpdateToDoItemCommand>(jsonString);
                    if (toDoCommand != null)
                    {
                        _listsApplicationService.UpdateToDoItem(toDoCommand);
                        return Ok();
                    }
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return BadRequest();
        }

        /// <summary>
        /// Gets one or multiple instances of ToDoItem by the given criteria
        /// </summary>
        /// <returns></returns>
        [Route("todoitem")]
        [HttpGet]
        public IHttpActionResult Get(string email = null, string id = null)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(email))
                {
                    return Ok(_listsApplicationService.GetToDoItemsByEmail(email));
                }
                else if (!string.IsNullOrWhiteSpace(id))
                {
                    return Ok(_listsApplicationService.GetToDoItemById(id));
                }
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
            return BadRequest();
        }
    }
}
