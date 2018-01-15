using DataAccessLayer;
using DataAccessLayer.Executors;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using NLog;
using System;
using System.Windows;

namespace ProductsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISqlExecutor<ProductItemModel> _sqliteProductITemExecutor;
        private readonly SQLiteRepository _sqLiteRepository;
        private readonly ILogger _logger;

        public MainWindow()
        {
            InitializeComponent();

            this._logger = LogManager.GetCurrentClassLogger();
            this._sqliteProductITemExecutor = new SqlProductItemExecutor();
            this._sqLiteRepository = new SQLiteRepository(_sqliteProductITemExecutor, _logger);


            _sqLiteRepository.AddProductItem(new ProductItemModel()
            {
                Id = Guid.NewGuid()
            });
        }
    }
}
