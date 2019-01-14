using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Application.Builders
{
    public class GenericBuilder
    {
        public static Entity builderDTOEntity<Entity, DTO>(DTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO,Entity>();
            });
            IMapper iMapper = config.CreateMapper();
            Entity destination = iMapper.Map<DTO, Entity>(dto);
            return destination;
        }
        public static IList<DTO> builderListEntityDTO<DTO, Entity>(IQueryable<Entity> listaInput)
        {
            var listOutput = new List<DTO>();
            foreach (Entity entity in listaInput)
            {
                listOutput.Add(builderDTOEntity<DTO, Entity>(entity));
            }
            return listOutput;
        }
        public static DTO builderEntityDTO<DTO, Entity>(Entity entity)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Entity, DTO>();

            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<Entity, DTO>(entity);
            return destination;
        }
    }
}
