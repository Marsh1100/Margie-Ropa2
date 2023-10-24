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

public class InsumoController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InsumoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<InsumoDto>>> Get()
    {
        var result = await _unitOfWork.Insumos.GetAllAsync();
        return _mapper.Map<List<InsumoDto>>(result);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<InsumoDto>>> GetPagination([FromQuery] Params p)
    {
        var result = await _unitOfWork.Insumos.GetAllAsync(p.PageIndex, p.PageSize, p.Search);
        var resultDto = _mapper.Map<List<InsumoDto>>(result.registros);
        return  new Pager<InsumoDto>(resultDto,result.totalRegistros, p.PageIndex, p.PageSize, p.Search);
    }


    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Insumo>> Post([FromBody] InsumoDto dto)
    {
        var result = _mapper.Map<Insumo>(dto);
        this._unitOfWork.Insumos.Add(result);
        await _unitOfWork.SaveAsync();


        if(result == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Post), new{id=result.Id}, result);
    }
    [HttpPost("addInsumoProveedor")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> PostAddTalla([FromBody] InsumoProveedorDto dto)
    {
        var result = await _unitOfWork.Insumos.AddInsumoProveedor(dto.InsumoId, dto.ProveedorId) ;
        return Ok(result);
    }

    [HttpPut()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Insumo>> put(InsumoDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Insumo>(dto);
        this._unitOfWork.Insumos.Update(result);
        Console.WriteLine(await this._unitOfWork.SaveAsync());
        return result;
    }

    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Insumos.GetByIdAsync(id);
        if(result == null)
        {
            return NotFound();
        }
        this._unitOfWork.Insumos.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }


    
}