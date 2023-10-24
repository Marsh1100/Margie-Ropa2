using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class PrendaController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PrendaController( IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PrendaDto>>> Get()
    {
        var result = await _unitOfWork.Prendas.GetAllAsync();
        return _mapper.Map<List<PrendaDto>>(result);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PrendaDto>>> GetPagination([FromQuery] Params p)
    {
        var result = await _unitOfWork.Prendas.GetAllAsync(p.PageIndex, p.PageSize, p.Search);
        var resultDto = _mapper.Map<List<PrendaDto>>(result.registros);
        return  new Pager<PrendaDto>(resultDto,result.totalRegistros, p.PageIndex, p.PageSize, p.Search);
    }


    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Prenda>> Post([FromBody] PrendaDto dto)
    {
        var result = _mapper.Map<Prenda>(dto);
        this._unitOfWork.Prendas.Add(result);
        await _unitOfWork.SaveAsync();

        if(result == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new{id=result.Id}, result);
    }


    [HttpPut()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Prenda>> put(PrendaDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Prenda>(dto);
        this._unitOfWork.Prendas.Update(result);
        Console.WriteLine(await this._unitOfWork.SaveAsync());
        return result;
    }


    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Prendas.GetByIdAsync(id);
        if(result == null)
        {
            return NotFound();
        }
        this._unitOfWork.Prendas.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }

    [HttpGet("prendasProteccion")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> GetPrendas()
    {
        var result = await _unitOfWork.Prendas.GetPrendas();
        return Ok(result);
    }

    [HttpGet("insumos/{idPrenda}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetInsumos(int idPrenda)
    {
        var result = await _unitOfWork.Prendas.GetInsumos(idPrenda);
        return Ok(result);
    }
    
}