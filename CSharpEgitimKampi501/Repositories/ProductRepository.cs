﻿using CSharpEgitimKampi501.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi501.Repositories
{
	public class ProductRepository : IProductRepository
	{
		public Task CreateProductAsync(CreateProductDto createProductDto)
		{
			throw new NotImplementedException();
		}

		public Task DeleteProductAsync(int productId)
		{
			throw new NotImplementedException();
		}

		public Task<List<ResultProductDto>> GetAllProductsAsync()
		{
			throw new NotImplementedException();
		}

		public Task GetByProductIdAsync(int productId)
		{
			throw new NotImplementedException();
		}

		public Task UpdateProductAsync(UpdateProductDto updateProductDto)
		{
			throw new NotImplementedException();
		}
	}
}
