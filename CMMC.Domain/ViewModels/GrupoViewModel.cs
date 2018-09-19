using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CMMC.Domain.Entities.Geral;
using CMMC.Domain.Interfaces.ViewModels;

namespace CMMC.Domain.ViewModels
{
    public class GrupoViewModel : IBasicViewModel, IBasicEntityViewModel<Grupo, GrupoViewModel>
    {
        public GrupoViewModel()
        {
            
        }

        public Grupo UpdateEntity(Grupo entity)
        {
            entity.Nome = this.nome;
            return entity;
        }

        public GrupoViewModel ToViewModel(Grupo entity)
        {
            this.Id = entity.Id;
            this.nome = entity.Nome;
            return this;
        }

        public GrupoViewModel(int id, string nome)
        {
            this.Id = id;
            this.nome = nome;
        }


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("Nome")]
        public string nome { get; set; }

    }
}