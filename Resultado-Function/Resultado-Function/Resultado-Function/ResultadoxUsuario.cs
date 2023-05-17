using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using Resultado_Function.Models;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace Resultado_Function
{
    public static class ResultadoxUsuario
    {
        [FunctionName("GetResultadoUsuario")] /*Nombre de la Function*/
        public static async Task<IActionResult> GetResultadoUsuario(
            /*Se declara la Function como método GET en la ruta USER*/ /*Por ejemplo: http://www.ejemplo.com/api/userId/resultados/*/
            [HttpTrigger(AuthorizationLevel.Anonymous, "get" , Route = "resultado")] HttpRequest req,
            ILogger log)
        {
            List<ListResultadoModel> taskList = new List<ListResultadoModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    /*Abre la conexión*/
                    connection.Open();

                    /*Declara Query*/
                    var query = @"Select ID,idUser,velocidad,tiempo,distancia,fechaActual from UserResults";

                    /*Establece la estructura del comando (Sentencia + conexión)*/
                    SqlCommand command = new SqlCommand(query, connection);
                    var reader = await command.ExecuteReaderAsync();

                    /*Leer los resultados y crea lista de resultado por usuario*/
                    while (reader.Read())
                    {
                        ListResultadoModel user = new ListResultadoModel()
                        {
                            ID = new BigInteger((Int64)reader["ID"]),
                            idUser = new BigInteger((Int64)reader["IdUser"]),
                            tiempo = new BigInteger((Int64)reader["tiempo"]),
                            velocidad = (int)Convert.ToSingle(reader["velocidad"]),
                            distancia = (int)Convert.ToSingle(reader["distancia"]),
                            fechaActual = (DateTime)reader["fechaActual"]
                        };
                        taskList.Add(user);
                    }
                }
            }

            /*Si es que algo sale mal, se retorna un mensaje indicando el error*/
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
            /*Si todo sale bien, se carga la lista de usuarios*/
            if (taskList.Count > 0)
            {
                return new OkObjectResult(taskList);
            }
            else  /*Si no sale bien, no carga la lista de usuarios*/
            {
                return new NotFoundResult();
            }
        }
    }
}

