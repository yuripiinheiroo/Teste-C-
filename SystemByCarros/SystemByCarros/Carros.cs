using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemByCarros
{
    public class Carro
    {
        public string Modelo { get; set; }  // Define a propriedade Modelo para armazenar o modelo do carro.
        public string Marca { get; set; }  // Define a propriedade Marca para armazenar a marca do carro.
        public int Ano { get; set; }  // Define a propriedade Ano para armazenar o ano de fabricação do carro.
        public string Cor { get; set; }  // Define a propriedade Cor para armazenar a cor do carro.
        public double Valor { get; set; }  // Define a propriedade Valor para armazenar o valor do carro.
        public bool IsDisponivel { get; set; }  // Define a propriedade IsDisponivel para indicar se o carro está disponível para venda.
    }
}
