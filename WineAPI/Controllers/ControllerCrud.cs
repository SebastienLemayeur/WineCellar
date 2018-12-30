using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineAPI.Models;
using WineAPI.Repositories;

namespace WineAPI.Controllers
{
    public class ControllerCrud<T,R> : ControllerBase where T : EntityBase where R : Repository<T>
    {
        protected R repository;

        public ControllerCrud(R repo)
        {
            repository = repo;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(await repository.ListAll());
        }
        
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetById(id));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.Id)
            {
                return BadRequest();
            }

            T e = await repository.Update(entity);
            if (e == null)
            {
                return NotFound();
            }

            return Ok(e);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostPublisher([FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            T e = await repository.Add(entity);
            if (e == null)
            {
                return NotFound();
            }

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }
    }
}
