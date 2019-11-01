using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Commands;
using Aplication.Dto;
using Aplication.Exceptions;
using Aplication.Searches;
using Domain;
using EFDATAACCES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
       
    {

       
        private IAddCategoryCommand _addCommand;
        private IGetCategoriesCommand _getCommands;
        private IGetCategoryCommand _getCommand;
        private IDeleteCategoryCommand _deleteCommand;
        private IUpdateCategoryCommand _updateCommand;

        public CategoriesController(IAddCategoryCommand addCommand, IGetCategoriesCommand getCommands, IGetCategoryCommand getCommand, IDeleteCategoryCommand deleteCommand, IUpdateCategoryCommand updateCommand)
        {
            _addCommand = addCommand;
            _getCommands = getCommands;
            _getCommand = getCommand;
            _deleteCommand = deleteCommand;
            _updateCommand = updateCommand;
        }





        // GET: api/Categories
        [HttpGet]
        public IActionResult Get([FromQuery]CategoriesSearch query)
        {
            return Ok(_getCommands.Execute(query));
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var categoryDto = _getCommand.Execute(id);
                return Ok(categoryDto);
            }
            catch (EntityNotFoundException)
            {

                return NotFound();
            }
        }

        // POST: api/Categories
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto dto)
        {
           
           
            try
            {
               _addCommand.Execute(dto);
                return NoContent();

            }
            catch (EntityAlreadyExistsException)
            {

                return Conflict("Postoji vec sa takvim imenom");
            }
            catch(Exception)
            {
                return StatusCode(500, "An error has occured");
            }
            
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDto dto)
        {
            dto.Id = id;
            try
            {
                _updateCommand.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {

                return NotFound("Ne psotoji");
            }
            catch(EntityAlreadyExistsException)
            {
                return Conflict("Sa tim imenom postoji kategorija");
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske pokusajte kasnije");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {

                return NotFound("Ne psotoji objekat");
            }
            catch(Exception)
            {
                return StatusCode(500, "Doslo je do greske");
            }
        }
    }
}
