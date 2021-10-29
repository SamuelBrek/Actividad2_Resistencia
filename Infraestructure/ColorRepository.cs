using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArduinoApi.Domain;
using System.Text.Json;
using System.IO;

namespace ArduinoApi.Infraestructure
{
    public class ColorRepository
    {
        List<ColorRecord> _colores;
        public ColorRepository()
        {
            var fileName = "dummy.data.json"; //Hago referencia a mi dummy.data
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _colores = JsonSerializer.Deserialize<IEnumerable<ColorRecord>>(json).ToList();
            }
        }
        public IEnumerable<ColorRecord> GetAll() //Opción extra para ver todos los colores
        {
            var query = _colores.Select(col => col);
            return query;
        }
        public double ObtenerOhms(string banda1, string banda2, string banda3, string banda4){
            double res = 0; //variable resultado (Ohms) que se va a retornar
            double numero1 = 0;
            double numero2 = 0;
            double numero3 = 0;
            double numero4 = 0;
            var primerColor = _colores.FirstOrDefault(col => col.ColorName == banda1.ToLower());
            if (primerColor == null || banda1.ToLower() == "dorado" || banda1.ToLower() == "plata"){
                res = -100;
                return res;
            }
            else{
                numero1 = primerColor.ValorBanda;
            }
            var segundoColor = _colores.FirstOrDefault(col => col.ColorName == banda2.ToLower());
            if (segundoColor == null || banda2.ToLower() == "dorado" || banda2.ToLower() == "plata"){
                res = -200;
                return res;
            }
            else{
                numero2 = segundoColor.ValorBanda;
            }
            
            
            var tercerValor = _colores.FirstOrDefault(col => col.ColorName == banda3.ToLower());
            if (tercerValor == null || banda3.ToLower() == "violeta" || banda3.ToLower() == "gris" || banda3.ToLower() == "blanco"){
                res = -300;
                return res;
            }
            else{
                numero3 = tercerValor.TerceraBanda;
            } 
            var cuartoValor = _colores.FirstOrDefault(col => col.ColorName == banda4.ToLower());
            if (cuartoValor == null || banda4.ToLower() == "violeta" || banda4.ToLower() == "gris" || banda4.ToLower() == "blanco"
                || banda4.ToLower() == "negro" || banda4.ToLower() == "cafe" || banda4.ToLower() == "rojo"
                || banda4.ToLower() == "naranja" || banda4.ToLower() == "amarillo" || banda4.ToLower() == "verde"
                || banda4.ToLower() == "azul"){ //Intente por obvias razones mejor poner que sea diferente de dorado y plata
                                                //Sin embargo me fallaba y terminé citando a todos los colores.
                res = -400;
                return res;
            }
            else{
                numero4 = cuartoValor.ValorBanda;
            }
            
            var union = Int32.Parse($"{numero1}{numero2}");
            if (banda3.ToLower() == "dorado" || banda3.ToLower() == "plata"){
                res = (union/numero3);
            }
            else{
                res = (union * numero3);
            }
            return res;
        }
    }
}