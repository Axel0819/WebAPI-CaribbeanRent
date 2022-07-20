using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Helpers;
using WebAPI.Models.DTO;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly caribbeanrentContext _context;
        private readonly IMapper _mapper;
        private readonly ServiceStorageBlobs _service;
        private string containerName = "imagesofrents";

        public ImagesController(caribbeanrentContext context, IMapper mapper, ServiceStorageBlobs service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
          if (_context.Images == null)
          {
              return NotFound();
          }
            return await _context.Images.ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(int id)
        {
          if (_context.Images == null)
          {
              return NotFound();
          }
            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // PUT: api/Images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage(int id, ImageDTO imageDTO)
        {
            Image image= _mapper.Map<ImageDTO,Image>(imageDTO);

            if (id != image.Idimage)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage([FromForm] ImageDTO imageDTO)
        {
            
            Image image = _mapper.Map<ImageDTO, Image>(imageDTO);
            
            if (_context.Images == null)
          {
              return Problem("Entity set 'caribbeanrentContext.Images'  is null.");
          }

            if (!RentPostsController.RentPostExists(_context,image.IdrentPost))
          {
                return NotFound("No existe una publicación de alquiler con este ID");
          }

            var uploadResult = await ImageHelper.UploadHelper(_service, containerName, imageDTO.File);
            image.Urlimage = uploadResult;

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new { id = image.Idimage }, image);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            if (_context.Images == null)
            {
                return NotFound();
            }
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            await _service.DeleteBlobAsync(containerName,image.Urlimage);

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageExists(int id)
        {
            return (_context.Images?.Any(e => e.Idimage == id)).GetValueOrDefault();
        }
    }
}
