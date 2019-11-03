﻿using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace TNDataManager.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            //Adds a new route 
            // Добавя нов път
            //Taken from https://stackoverflow.com/questions/51117655/how-to-use-swagger-in-asp-net-webapi-2-0-with-token-based-authentication
            //  Взето от #
            swaggerDoc.paths.Add("/token", new PathItem 
            {
                post = new Operation //POST
                {                    
                    tags = new List<string> { "Auth" }, //"Auth" category //Категория                    
                    consumes = new List<string>
                    {
                        "application/x-www-form-urlencoded" //Параметрите идват оттук
                    },
                    parameters = new List<Parameter>
                    {
                        new Parameter 
                        {
                            type="string",
                            name="grant_type",
                            required=true,
                            @in="formData",
                            @default="password"
                        },
                        //Потребителско име
                        new Parameter
                        {
                            type="string",
                            name="username",
                            required=false,
                            @in="formData"
                        },
                        //Парола
                        new Parameter
                        {
                            type="string",
                            name="password",
                            required=false,
                            @in="formData"
                        }
                    }
                }
            }); 

        }
    }
}