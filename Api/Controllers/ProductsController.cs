using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Commands;
using Aplication.Dto;
using Aplication.Exceptions;
using Aplication.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase

    {
        private IGetProductsCommand _getCommand;
        private IGetProductCommand _getOneCommand;
        private IAddProductCommand _addCommand;
        private IDeleteProductCommand _deleteCommand;
        private IUpdateProductCommand _updateCommand;

        public ProductsController(IGetProductsCommand getCommand, IGetProductCommand getOneCommand,IAddProductCommand addProductCommand,IDeleteProductCommand deleteProductCommand,IUpdateProductCommand updateProductCommand)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _addCommand = addProductCommand;
            _deleteCommand = deleteProductCommand;
            _updateCommand = updateProductCommand;
        }







        // GET: api/Products
        [HttpGet]
        public IActionResult Get([FromQuery]ProductSearch query)
        {
            return Ok(_getCommand.Execute(query));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _getOneCommand.Execute(id);
                return Ok(product);
            }
            catch (EntityNotFoundException)
            {

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Doslo je do greske");
            }
            
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto dto)
        {
            try
            {
               _addCommand.Execute(dto);
                return Ok("Uspesno kreiran proizvod");
            }
            catch (EntityNotFoundException)
            {

                return NotFound("Kategorija sa tim imenom ne postoji");
            }
            catch (EntityAlreadyExistsException)
            {
                return Conflict("Proizvod sa tim imenom vec postoji");
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto dto)
        {
            dto.Id = id;
            try
            {
                _updateCommand.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFoundException)
            {

                return NotFound("Ne postoji product ili ne postoji kategoriaj koju zelite da dodate");
            }
            catch (EntityAlreadyExistsException)
            {

                return Conflict("Sa tim imenom vec postoji product");
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

                return Conflict("Product ne postoji");
            }
            catch(Exception)
            {
                return StatusCode(500, "Doslo je do greske");
            }
        }
    }
}
