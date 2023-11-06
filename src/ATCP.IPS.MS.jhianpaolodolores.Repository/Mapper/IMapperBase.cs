using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCP.IPS.MS.jhianpaolodolores.Repository.Mapper
{
    public interface IMapperBase<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        TDto ConvertToDto(TEntity entity);
        TDto ConvertToDto(TEntity entity, TDto dto);
        IList<TDto> ConvertToDtoList(IList<TEntity> entityList);
        TEntity ConvertToEntity(TDto dto);
        TEntity ConvertToEntity(TDto dto, TEntity entity);
        IList<TEntity> ConvertToEntityList(IList<TDto> dtoList);
    }

}
