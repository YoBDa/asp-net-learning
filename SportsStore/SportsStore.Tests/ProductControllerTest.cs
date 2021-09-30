using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using Xunit;
using Moq;

namespace SportsStore.Tests
{
    public class ProductControllerTest
    {

        private Mock<IProductRepository> GetIProductRepository()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product{ProductID = 1, Name = "P1"},
                new Product{ProductID = 2, Name = "P2"},
                new Product{ProductID = 3, Name = "P3"},
                new Product{ProductID = 4, Name = "P4"},
                new Product{ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>);
            return mock;
        }
        [Fact]
        public void Can_Paginate()
        {
            var mock = GetIProductRepository();

            var controller = new ProductController(mock.Object) { PageSize = 3 };

            ProductListViewModel result = controller.List(2).ViewData.Model as ProductListViewModel;

           
            Product[] ProductArray = result.Products.ToArray();
            Assert.True(ProductArray.Length == 2);
            Assert.Equal("P4", ProductArray[0].Name);
            Assert.Equal("P5", ProductArray[1].Name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            var mock = GetIProductRepository();

            var controller = new ProductController(mock.Object) { PageSize = 3 };

            ProductListViewModel result = controller.List(2).ViewData.Model as ProductListViewModel;

            PagingInfo pagingInfo = result.PagingInfo;
            Assert.Equal(2, pagingInfo.CurrentPage);
            Assert.Equal(3, pagingInfo.ItemsPerPage);
            Assert.Equal(5, pagingInfo.TotalItems);
            Assert.Equal(2, pagingInfo.TotalPages);



        }
    }
}
