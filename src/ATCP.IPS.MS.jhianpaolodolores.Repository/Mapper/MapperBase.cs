using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCP.IPS.MS.jhianpaolodolores.Repository.Mapper
{
    public abstract class MapperBase<TEntity, TDto> : IMapperBase<TEntity, TDto>
 where TEntity : class
 where TDto : class
    {

        public virtual TDto ConvertToDto(TEntity entity)
        {
            return ConvertToDto(entity, null);
        }
        public abstract TDto ConvertToDto(TEntity entity, TDto dto);
        public virtual IList<TDto> ConvertToDtoList(IList<TEntity> entityList)
        {
            return entityList.Select(ConvertToDto).ToList();
        }
        public virtual TEntity ConvertToEntity(TDto dto)
        {
            return ConvertToEntity(dto, null);
        }
        public abstract TEntity ConvertToEntity(TDto dto, TEntity entity);
        public virtual IList<TEntity> ConvertToEntityList(IList<TDto> dtoList)
        {
            return dtoList.Select(ConvertToEntity).ToList();
        }
    }

}
