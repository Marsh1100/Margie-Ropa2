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

public class InventarioController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InventarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<InventarioDto>>> Get()
    {
        var result = await _unitOfWork.Inventarios.GetAllAsync();
        return _mapper.Map<List<InventarioDto>>(result);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<InventarioDto>>> GetPagination([FromQuery] Params p)
    {
        var result = await _unitOfWork.Inventarios.GetAllAsync(p.PageIndex, p.PageSize, p.Search);
        var resultDto = _mapper.Map<List<InventarioDto>>(result.registros);
        return  new Pager<InventarioDto>(resultDto,result.totalRegistros, p.PageIndex, p.PageSize, p.Search);
    }


    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Inventario>> Post([FromBody] InventarioDto dto)
    {
        var result = _mapper.Map<Inventario>(dto);
        this._unitOfWork.Inventarios.Add(result);
        await _unitOfWork.SaveAsync();


        if(result == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Post), new{id=result.Id}, result);
    }

    [HttpPost("addInventarioTalla")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> PostAddTalla([FromBody] InventarioTallaDto dto)
    {
        var result = await _unitOfWork.Inventarios.AddInventarioTalla(dto.InventarioId, dto.TallaId, dto.Cantidad) ;
        return Ok(result);
    }


    [HttpPut()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Inventario>> put(InventarioDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Inventario>(dto);
        this._unitOfWork.Inventarios.Update(result);
        Console.WriteLine(await this._unitOfWork.SaveAsync());
        return result;
    }


    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Inventarios.GetByIdAsync(id);
        if(result == null)
        {
            return NotFound();
        }
        this._unitOfWork.Inventarios.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }

   
}