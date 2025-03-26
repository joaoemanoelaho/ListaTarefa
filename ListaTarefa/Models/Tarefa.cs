using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaTarefa.Models
{
    public class Tarefa
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha a descrição!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Preencha a data de vencimento!")]
        public DateTime? DataVencimento { get; set; }
        public bool Concluido { get; set; } = false;
    }
}