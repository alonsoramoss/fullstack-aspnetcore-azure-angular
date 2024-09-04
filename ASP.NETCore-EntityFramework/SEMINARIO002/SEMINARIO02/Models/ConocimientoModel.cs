using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEMINARIO02.Models
{
    public class ConocimientoModel
    {
        public int Id { get; set; }
        public string TituloConoc { get; set; }
        public string AreaConoc { get; set; }
    }
}