namespace DataAccessLayer.Repositories.Interfaces
{
    using DataAccessLayer.Models;

    public interface IProductItemRepository
    {
        void AddProductItem(ProductItemModel item);
        int ExistingItemsCount();
    }
}
