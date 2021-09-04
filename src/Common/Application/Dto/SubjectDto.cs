using System.Collections.Generic;
using Domain.Entities;
using Mapster;

namespace Application.Dto
{
    public class SubjectDto : IRegister 
    {
        public SubjectDto()
        {
        }

        public int Id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string versao { get; set; }
        public int ano { get; set; }
        public string quilometragem { get; set; }
        public string observacao { get; set; }


        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Subject, SubjectDto>();
        }
    }
}
