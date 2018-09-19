using CMMC.Domain.Entities;

namespace CMMC.Domain.Interfaces.ViewModels
{
    public interface IBasicEntityViewModel<TEntity, TViewModel> : IBasicViewModel where TEntity : BasicEntity
    {
        int Id { get; set; }
        
        TEntity UpdateEntity(TEntity entity);
        TViewModel ToViewModel(TEntity entity);


    }
}