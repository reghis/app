﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CEntidades;
using WebConsola.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebConsola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class articlesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public articlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/articles
        /// <summary>
        /// Get de todos los Articulos Zapatos
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<articles>>> Getarticles()
        {
            return await _context.articles.ToListAsync();
        }

        // GET: api/articles/5
        /// <summary>
        /// Get de un Articulo por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<articles>> Getarticles(int id)
        {
            var articles = await _context.articles.FindAsync(id);

            if (articles == null)
            {
                return NotFound();
            }

            return articles;
        }

        // PUT: api/articles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Actualiza un Articulo por ID y Objeto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="articles"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Putarticles(int id, articles articles)
        {
            if (id != articles.id)
            {
                return BadRequest();
            }

            _context.Entry(articles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!articlesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/articles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Inserta un articulo POST por objeto
        /// </summary>
        /// <param name="articles"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<articles>> Postarticles(articles articles)
        {
            _context.articles.Add(articles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getarticles", new { id = articles.id }, articles);
        }

        // DELETE: api/articles/5
        /// <summary>
        /// DETELE de algun Articulo por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<articles>> Deletearticles(int id)
        {
            var articles = await _context.articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }

            _context.articles.Remove(articles);
            await _context.SaveChangesAsync();

            return articles;
        }

        private bool articlesExists(int id)
        {
            return _context.articles.Any(e => e.id == id);
        }
    }
}