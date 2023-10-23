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

public class DetalleVentaController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DetalleVentaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DetalleVentaDto>>> Get()
    {
        var result = await _unitOfWork.DetalleVentas.GetAllAsync();
        return _mapper.Map<List<DetalleVentaDto>>(result);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetalleVentaDto>>> GetPagination([FromQuery] Params p)
    {
        var result = await _unitOfWork.DetalleVentas.GetAllAsync(p.PageIndex, p.PageSize, p.Search);
        var resultDto = _mapper.Map<List<DetalleVentaDto>>(result.registros);
        return  new Pager<DetalleVentaDto>(resultDto,result.totalRegistros, p.PageIndex, p.PageSize, p.Search);
    }


    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] DetalleVentaDto dto)
    {
        var result = await _unitOfWork.DetalleVentas.RegisterAsync(dto.VentaId, dto.PrendaId, dto.TallaId, dto.Cantidad);
        return Ok(result);
    }


    [HttpPut()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleVenta>> put(DetalleVentaDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<DetalleVenta>(dto);
        this._unitOfWork.DetalleVentas.Update(result);
        Console.WriteLine(await this._unitOfWork.SaveAsync());
        return result;
    }


    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.DetalleVentas.GetByIdAsync(id);
        if(result == null)
        {
            return NotFound();
        }
        this._unitOfWork.DetalleVentas.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }

   
}