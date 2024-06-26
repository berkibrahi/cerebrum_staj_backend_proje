﻿using Contracts;
using Entities.ErrorModel;
using Entities.Exceptionn;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace WebMenagement_2.Extensions
{
	public static class ExceptionMiddlleWareExtensionscs
	{
		public static void ConfigureExceptionHandler(this WebApplication app,
			ILoggerMenager logger)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					//context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
					context.Response.ContentType = "application/json";
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						context.Response.StatusCode = contextFeature.Error switch
						{
							NotFounException => StatusCodes.Status404NotFound,
							_ => StatusCodes.Status500InternalServerError,

						};
						logger.LogError("bir problem var" + contextFeature.Error);
						await context.Response.WriteAsync(new ErrorDetails
						{
							StatusCode = context.Response.StatusCode,
							Message=contextFeature.Error.Message,
						}.ToString()) ;
					}
				});
			});
		}
	}
}
