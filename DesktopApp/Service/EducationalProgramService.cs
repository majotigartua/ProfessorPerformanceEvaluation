﻿using Newtonsoft.Json;
using ProfessorPerformanceEvaluation.Model;
using System;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;

namespace ProfessorPerformanceEvaluation.Service
{
    public class EducationalProgramService
    {
        private static readonly string TOKEN = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).AppSettings.Settings["TOKEN"].Value;
        private static readonly string URL = string.Concat(Properties.Resources.BASE_URL, "educationalprograms/");

        public static async Task<Response> GetEducationalPrograms()
        {
            Response response = new Response();
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);
                    var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(URL));
                    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<Response>(json);
                        }
                        response.Code = (int)httpResponseMessage.StatusCode;
                    }
                }
                catch (Exception exception)
                {
                    response.Code = (int)HttpStatusCode.InternalServerError;
                    Console.WriteLine(exception.Message);
                }
            }
            return response;
        }

        public static async Task<Response> GetEducationalProgramsByFaculty(Faculty faculty)
        {
            Response response = new Response();
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);
                    var httpRequestMessage = new HttpRequestMessage()
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(faculty), Encoding.UTF8, "application/json"),
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(string.Concat(URL, "faculty"))
                    };
                    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<Response>(json);
                        }
                        response.Code = (int)httpResponseMessage.StatusCode;
                    }
                }
                catch (Exception exception)
                {
                    response.Code = (int)HttpStatusCode.InternalServerError;
                    Console.WriteLine(exception.Message);
                }
            }
            return response;
        }

        public static async Task<Response> Patch(EducationalProgram educationalProgram)
        {
            Response response = new Response();
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);
                    var httpRequestMessage = new HttpRequestMessage()
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(educationalProgram), Encoding.UTF8, "application/json"),
                        Method = new HttpMethod("PATCH"),
                        RequestUri = new Uri(URL)
                    };
                    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<Response>(json);
                        }
                        response.Code = (int)httpResponseMessage.StatusCode;
                    }
                }
                catch (Exception exception)
                {
                    response.Code = (int)HttpStatusCode.InternalServerError;
                    Console.WriteLine(exception.Message);
                }
            }
            return response;
        }

        public static async Task<Response> Post(EducationalProgram educationalProgram)
        {
            Response response = new Response();
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);
                    var httpRequestMessage = new HttpRequestMessage()
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(educationalProgram), Encoding.UTF8, "application/json"),
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(URL)
                    };
                    HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                    if (httpResponseMessage != null)
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            string json = await httpResponseMessage.Content.ReadAsStringAsync();
                            response = JsonConvert.DeserializeObject<Response>(json);
                        }
                        response.Code = (int)httpResponseMessage.StatusCode;
                    }
                }
                catch (Exception exception)
                {
                    response.Code = (int)HttpStatusCode.InternalServerError;
                    Console.WriteLine(exception.Message);
                }
            }
            return response;
        }
    }
}