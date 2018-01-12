namespace DataAccessLayer.Repositories
{
    using DataAccessLayer.Models;
    using DataAccessLayer.Repositories.Interfaces;
    using MyExceptions;
    using NLog;
    using System;
    using System.Text;

    public class SQLiteRepository : IProductItemRepository
    {
        private readonly ISqlExecutor<ProductItemModel> _productItemExecutor;
        private readonly ILogger _logger;

        public SQLiteRepository(ISqlExecutor<ProductItemModel> productItemExecutor, ILogger logger)
        {
            this._productItemExecutor = productItemExecutor;
            this._logger = logger;
        }

        public void AddProductItem(ProductItemModel item)
        {
            try
            {
                string countQuery = $@"SELECT count(*) FROM ProductItem WHERE Product_Name='{item.ProductName}'";
                int count = _productItemExecutor.GetCount(countQuery);

                if (count > 0)
                {
                    throw new RecordAlreadyExistsException("Product named " + item.ProductName + " already exists");
                }

                StringBuilder query = new StringBuilder();
                query.Append("INSERT INTO ProductItem ( Product_Item_Id,  Product_Name, Unit )");
                query.Append(" VALUES ( ");
                query.Append($"'{item.Id}', '{item.ProductName}', '{item.MeasurementUnit}' )");

                _productItemExecutor.Add(query.ToString());
            }
            catch (RecordAlreadyExistsException ex)
            {
                _logger.Error(ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}
