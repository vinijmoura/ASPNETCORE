
using AppWeb.Models;
using AppWeb.Repositorio;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private List<ProdutoViewModel> listProduto;
        private readonly IConexao _conexao;

        //Construtor da classe produtoController
        public ProdutoController(IConexao conexao)
        {
            _conexao = conexao;
        }

        [HttpGet("Produto/Listar")]
        public IActionResult Index()
        {
            using (var conn = _conexao.AbrirConexao())
            {
                var querySQL = @"SELECT idProduto, nome, valor	FROM Produto;";
                listProduto = conn.Query<ProdutoViewModel>(querySQL).ToList();
            }
            return View(listProduto);
        }

        [HttpGet("Produto/Editar/{id}")]
        public IActionResult Edit(int id)
        {
            ProdutoViewModel produto;
            using (var conn = _conexao.AbrirConexao())
            {
                var querySQL = $"SELECT idProduto, nome, valor	FROM Produto where idProduto = {id};";
                produto = conn.QueryFirst<ProdutoViewModel>(querySQL);
            }
            return View(produto);
        }

        [HttpPost("Produto/Salvar")]
        public IActionResult Post([FromForm] ProdutoViewModel model)
        {
            string sql = "";
            if (model.IdProduto != 0)
            {
                sql = @"Update produto set 
                        nome = @nome, 
                        valor =  @valor
                        where idProduto = @idProduto";
            }
            else
            {
                sql = @"Insert into produto(nome, valor) values(@nome, @valor);";
            }

            using (var conn = _conexao.AbrirConexao())
            {
                conn.Execute(sql, model);
            }
            return RedirectToAction("Index");
        }

     
        public IActionResult Delete(int id)
        {
            using (var conn = _conexao.AbrirConexao())
            {
                var querySQL = $"Delete from produto where idProduto = {id};";
                conn.Execute(querySQL);
            }
            return RedirectToAction("Index");
        }

        public IActionResult New()
        {
            return View();
        }

    }
}