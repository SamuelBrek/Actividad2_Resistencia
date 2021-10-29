using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArduinoApi.Domain;
using ArduinoApi.Infraestructure;

/*
Nombre de la escuela: Universidad Tecnologica Metropolitana
Asignatura: Aplicaciones Web Orientadas a Servicios
Nombre del Maestro: Chuc Uc Joel Ivan
Nombre de la actividad: Actividad 2 (Resistencias)
Nombre del alumno: Brek Mejia Samuel Alexander
Cuatrimestre: 4
Grupo: B
Parcial: 2
*/
//He dejado evidencia de la otra manera que lo intenté hacer (todos los calculos en controller)
//Espero que no confunda. Los que me sirvieron al final es la capa infraestructura y mi ColorRecord
namespace ArduinoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArduinoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll(){
            var repository = new ColorRepository();
            var colorines = repository.GetAll();
            return Ok(colorines);
        }
        [HttpGet]
        [Route("EjecutarCalculo/{color1}/{color2}/{color3}/{color4}")]
        public IActionResult EjecutarCalculo(string color1, string color2, string color3, string color4){
            var Mensaje = "";
            var Tole = "";
            var repository = new ColorRepository();
            var validacion = repository.ObtenerOhms(color1, color2, color3, color4);
            //Validaciones por banda
            if (validacion == -100){
                Mensaje = ($"El primer color ingresado: {color1} es incorrecto.");
                return Ok(Mensaje);
            }
            else if (validacion == -200){
                Mensaje = ($"El segundo color ingresado: {color2} es incorrecto.");
                return Ok(Mensaje);
            }
            else if (validacion == -300){
                Mensaje = ($"El tercer color ingresado: {color3} es incorrecto. Asegurate de poner colores diferentes a violeta, blanco y gris.");
                return Ok(Mensaje);
            }
            else if (validacion == -400){
                Mensaje = ($"El cuarto color ingresado: {color4} es incorrecto. Asegurate de usar el color dorado o plata");
                return Ok(Mensaje);
            }
            
            if (color4.ToLower() == "dorado"){
                Tole = "5%";
            }
            else {
                Tole = "10%";
            }
            var MensajeFinal = ($"El valor es de: {validacion} Ohms y tiene una resistencia del {Tole}");
            return Ok(MensajeFinal);
            
        }
        
        /*
        [HttpGet]
        [Route("EjecutarCalculo/{color1}/{color2}/{color3}/{color4}")]
        public IActionResult EjecutarCalculo(string color1, string color2, string color3, string color4){
            ColoresBandas c = new ColoresBandas();
            c.nombre = color1.ToLower();
            var Mensaje = "";
            switch (c.nombre){
                case "negro":
                    c.valor = 0;
                    break;
                case "cafe":
                    c.valor = 1;
                    break;
                case "rojo":
                    c.valor = 2;
                    break;
                case "naranja":
                    c.valor = 3;
                    break;
                case "amarillo":
                    c.valor = 4;
                    break;
                case "verde":
                    c.valor = 5;
                    break;
                case "azul":
                    c.valor = 6;
                    break;
                case "violeta":
                    c.valor = 7;
                    break;
                case "gris":
                    c.valor = 8;
                    break;
                case "blanco":
                    c.valor = 9;
                    break;
                    default:
                    Mensaje = $"El primer color '{c.nombre}' es inválido, usa colores existentes para una resistencia";
                    return Ok(Mensaje);
            }
            var valor1 = c.valor;
            c.nombre = color2.ToLower();
            switch (c.nombre){
                case "negro":
                    c.valor = 0;
                    break;
                case "cafe":
                    c.valor = 1;
                    break;
                case "rojo":
                    c.valor = 2;
                    break;
                case "naranja":
                    c.valor = 3;
                    break;
                case "amarillo":
                    c.valor = 4;
                    break;
                case "verde":
                    c.valor = 5;
                    break;
                case "azul":
                    c.valor = 6;
                    break;
                case "violeta":
                    c.valor = 7;
                    break;
                case "gris":
                    c.valor = 8;
                    break;
                case "blanco":
                    c.valor = 9;
                    break;
                    default:
                    Mensaje = $"El segundo color '{c.nombre}' es inválido, usa colores existentes para una resistencia";
                    return Ok(Mensaje);
            }
            var valor2 = c.valor;
            c.nombre = color3.ToLower();
            switch (c.nombre){
                case "negro":
                    c.multiplicidad = 1;
                    break;
                case "cafe":
                    c.multiplicidad = 10;
                    break;
                case "rojo":
                    c.multiplicidad = 100;
                    break;
                case "naranja":
                    c.multiplicidad = 1000;
                    break;
                case "amarillo":
                    c.multiplicidad = 10000;
                    break;
                case "verde":
                    c.multiplicidad = 100000;
                    break;
                case "azul":
                    c.multiplicidad = 1000000;
                    break;
                case "dorado":
                    c.multiplicidad = 10;
                    break;
                case "plata":
                    c.multiplicidad = 100;
                    break;
                default:
                    Mensaje = $"El tercer color '{c.nombre}' es inválido, usa colores distintos a violeta, gris y blanco";
                    return Ok(Mensaje);
            }
            var valor3 = c.multiplicidad;
            c.nombre = color4.ToLower();
            switch (c.nombre){
                case "plata":
                    c.valor = 10;
                    break;
                case "dorado":
                    c.valor = 5;
                    break;
                default:
                    Mensaje = $"El cuarto color '{c.nombre}' es inválido, solo se acepta el color plata y dorado";
                    return Ok(Mensaje);
            }
            var valor4 = c.valor;
            float res = 0;
            var union = Int32.Parse($"{valor1}{valor2}");
            if (color3 == "dorado" || color3 == "plata"){
                res = (union/valor3);
            }
            else{
                res = (union * valor3);
            }
            Mensaje = $"El valor es de {res} omh y su tolerancia es de {valor4}%";
            return Ok(Mensaje);
        }*/
    }
}