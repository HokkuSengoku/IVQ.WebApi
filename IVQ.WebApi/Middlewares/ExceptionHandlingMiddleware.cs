﻿using System.Net;
using System.Text.Json;
using IVQ.WebApi.Exceptions;
using IVQ.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IVQ.WebApi.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (StandartException ex)
        {
            await HandleExpectedExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleUnexpectedExceptionAsync(context, ex);
        }
    }

    private async Task HandleExpectedExceptionAsync(HttpContext context, StandartException e)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode =  (int) HttpStatusCodeResolver.Resolve(e);
        
        var problemDetails = new ProblemDetails
        {
            Status = (int) HttpStatusCodeResolver.Resolve(e),
            Type = e.ErrorType,
            Title = e.Title,
            Detail = e.Message,
        };

        var json = JsonSerializer.Serialize(problemDetails);
        await context.Response.WriteAsync(json);
    }
    
    private async Task HandleUnexpectedExceptionAsync(HttpContext context, Exception e)
    {
        

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

        ProblemDetails problem = new()
        {
            Status = (int) HttpStatusCode.InternalServerError,
            Type = "InternalServerError",
            Title = "Internal server error",
            Detail = "A critical internal server error occurred"
        };

        var json = JsonSerializer.Serialize(problem);

        await context.Response.WriteAsync(json);
    }
}