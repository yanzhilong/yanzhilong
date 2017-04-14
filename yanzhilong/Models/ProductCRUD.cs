using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Helper;
using yanzhilong.Models;

namespace yanzhilong.Models
{
    public class ProductCRUD
    {
        private SqlMapper sqlMapper = null;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ProductCRUD()
        {
            ISqlMapper mapper = Mapper.Instance();
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            sqlMapper = builder.Configure() as SqlMapper;
        }
        
         
        public bool Create(Product product)
        {
            string connectionString = sqlMapper.DataSource.ConnectionString;
            Console.WriteLine(connectionString);
            try
            {
                sqlMapper.Insert("InsertProduct", product);
                return true;
            }
            catch (Exception e) {
                logger.Error("add Product Fail");
                Console.WriteLine(  e.Message.ToString());
            }
            return false;
        }
         
        public Product GetProductById(string productID)
        {
            Product product = sqlMapper.QueryForObject<Product>("SelectProductById", productID);
            return product;
        }


        public IList<Product> GetProducts()
        {
            IList<Product> products = sqlMapper.QueryForList<Product>("SelectAllProduct", null);
            return products;
        }

        public IList<Product> GetStarProducts()
        {
            IList<Product> products = sqlMapper.QueryForList<Product>("SelectStarProduct", ResourceType.PRODUCT);
            return products;
        }

        public IList<Product> GetProducts(int index, int size)
        {
            IList<Product> productList = sqlMapper.QueryForList<Product>("SelectAllProduct", null, index, size);
            return productList;
        }

        public IList<Product> GetProducts(int pageCount)
        {
            Page page = PageHelper.makePage(pageCount);
            IList<Product> productList = sqlMapper.QueryForList<Product>("SelectAllProduct", null, page.PageSkip, page.PageSize);
            return productList;
        }

        public PagingViewModel GetPagingViewModel(int currentPage, int pageSize)
        {
            PagingViewModel pvm = new PagingViewModel();
            pvm.CurrentPage = currentPage;
            int count = sqlMapper.QueryForObject<int>("SelecProductCount", null);
            int pagecount = count / pageSize;
            if (count % pageSize == 0 && pagecount > 0)
            {
                pagecount--;
            }
            pvm.PageCount = pagecount;
            return pvm;
        }

        public bool Update(Product product)
        {
            int result = sqlMapper.Update("UpdateProduct", product);
            return result > 0;
        }
        

        public bool Delete(string productID)
        {
            int result = sqlMapper.Delete("DeleteProduct", productID);
            return result > 0;
        }
    }
}