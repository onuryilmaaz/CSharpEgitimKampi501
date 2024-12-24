using CSharpEgitimKampi501.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi501
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		SqlConnection connection = new SqlConnection("Data Source=ONUR\\SQLEXPRESS;Initial Catalog=EgitimKampi501Db;Integrated Security=True");

		private async void btnList_Click(object sender, EventArgs e)
		{
			string query = "SELECT * from TblProduct";
			var values = await connection.QueryAsync<ResultProductDto>(query);
			dataGridView1.DataSource = values;
		}

		private async void btnAdd_Click(object sender, EventArgs e)
		{
			string query = "INSERT INTO TblProduct (ProductName, ProductStock, ProductPrice, ProductCategory) VALUES (@productName, @productStock, @productPrice, @productCategory)";
			var parameters = new DynamicParameters();
			parameters.Add("@productName", txtProductName.Text);
			parameters.Add("@productStock", txtProductStock.Text);
			parameters.Add("@productPrice", txtProductPrice.Text);
			parameters.Add("@productCategory", txtProductCategory.Text);
			await connection.ExecuteAsync(query, parameters);
			MessageBox.Show("Yeni kitap eklendi.");
		}

		private async void btnDelete_Click(object sender, EventArgs e)
		{
			string query = "DELETE FROM TblProduct WHERE ProductId = @productId";
			var parameters = new DynamicParameters();
			parameters.Add("@productId", txtProductId.Text);
			await connection.ExecuteAsync(query, parameters);
			MessageBox.Show("Kitap silindi.");
		}

		private async void btnUpdate_Click(object sender, EventArgs e)
		{
			string query = "UPDATE TblProduct SET ProductName = @productName, ProductStock = @productStock, ProductPrice = @productPrice, ProductCategory = @productCategory WHERE ProductId = @productId";
			var parameters = new DynamicParameters();
			parameters.Add("@productId", txtProductId.Text);
			parameters.Add("@productName", txtProductName.Text);
			parameters.Add("@productStock", txtProductStock.Text);
			parameters.Add("@productPrice", txtProductPrice.Text);
			parameters.Add("@productCategory", txtProductCategory.Text);
			await connection.ExecuteAsync(query, parameters);
			MessageBox.Show("Kitap güncellendi.", "Güncelleme" , MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private async void Form1_Load(object sender, EventArgs e)
		{
			string query1 = "SELECT COUNT(*) FROM TblProduct";
			var productTotalCount = await connection.QueryFirstOrDefaultAsync<int>(query1);
			lblTotalProductCount.Text = productTotalCount.ToString();

			string query2 = "SELECT ProductName FROM TblProduct WHERE ProductPrice=(SELECT MAX(ProductPrice) FROM TblProduct)";
			var maxPriceProductName = await connection.QueryFirstOrDefaultAsync<string>(query2);
			lblMaxPriceProductName.Text = maxPriceProductName;

			string query3 = "SELECT Count(Distinct (ProductCategory)) From TblProduct";
			var distinctProductCount = await connection.QueryFirstOrDefaultAsync<int>(query3);
			lblDistinctProductCount.Text = distinctProductCount.ToString();
		}
	}
}
